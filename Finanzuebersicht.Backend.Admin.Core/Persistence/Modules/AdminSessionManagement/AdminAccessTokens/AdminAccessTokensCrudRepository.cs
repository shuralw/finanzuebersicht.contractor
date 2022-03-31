using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens
{
    public class AdminAccessTokensCrudRepository : IAdminAccessTokensCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        public AdminAccessTokensCrudRepository(
            PersistenceDbContext context)
        {
            this.dbContext = context;
        }

        public void CreateAdminAccessToken(IDbAdminAccessToken dbAdminAccessToken)
        {
            // Add AdminAccessToken
            this.dbContext.AdminAccessTokens.Add(DbAdminAccessToken.ToEfAdminAccessToken(dbAdminAccessToken));

            // Add AdminAccessToken-AdminAdGroup-Relations
            this.dbContext.AdminAccessTokenAdminAdGroupRelations.AddRange(dbAdminAccessToken.AdminAdGroupIds.Select(adminAdGroupId =>
            {
                return new EfAdminAccessTokenAdminAdGroupRelation()
                {
                    AdminAdGroupId = adminAdGroupId,
                    AdminAccessTokenId = dbAdminAccessToken.Id
                };
            }));

            // Add AdminAccessToken-Cached-Permissions
            EfAdminAccessTokenCachedPermissionsEntry permissionsEntry = DbPermissionsEntry
                .ToEfAdminAccessTokenCachedPermissions(dbAdminAccessToken.Id, dbAdminAccessToken.CachedPermissions);
            this.dbContext.AdminAccessTokenCachedPermissions.Add(permissionsEntry);

            this.dbContext.SaveChanges();
        }

        public void DeleteAllAdminAccessTokens()
        {
            var adminAccessTokensToDelete = this.dbContext.AdminAccessTokens;

            this.dbContext.AdminAccessTokens.RemoveRange(adminAccessTokensToDelete);

            this.dbContext.SaveChanges();
        }

        public void DeleteExpiredAdminAccessTokens(DateTime now)
        {
            var adminAccessTokensToDelete = this.dbContext.AdminAccessTokens
                .Where(adminAccessToken => adminAccessToken.ExpiresOn <= now);

            this.dbContext.AdminAccessTokens.RemoveRange(adminAccessTokensToDelete);

            this.dbContext.SaveChanges();
        }

        public void DeleteAdminAccessToken(Guid id)
        {
            var adminAccessTokenToRemove = this.dbContext.AdminAccessTokens.Find(id);
            this.dbContext.AdminAccessTokens.Remove(adminAccessTokenToRemove);
            this.dbContext.SaveChanges();
        }

        public void DeleteAdminAccessTokensOfAdminEmailUser(Guid adminEmailUserId)
        {
            var adminAccessTokensToDelete = this.dbContext.AdminAccessTokens
                .Where(session => session.AdminEmailUserId == adminEmailUserId);

            this.dbContext.AdminAccessTokens.RemoveRange(adminAccessTokensToDelete);

            this.dbContext.SaveChanges();
        }

        public void DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups()
        {
            var adminAccessTokensToDelete = this.dbContext.AdminAccessTokens
                .Include(session => session.AdminAccessTokenAdminAdGroupRelations)
                .Where(session => session.AdminAdUserId != null || session.AdminAccessTokenAdminAdGroupRelations.Count > 0);

            this.dbContext.AdminAccessTokens.RemoveRange(adminAccessTokensToDelete);

            this.dbContext.SaveChanges();
        }

        public bool DoesAdminAccessTokenExist(Guid adminAccessTokenId)
        {
            return this.dbContext.AdminAccessTokens
                .Any(efAdminAccessToken => efAdminAccessToken.Id == adminAccessTokenId);
        }

        public IDbAdminAccessToken GetAdminAccessToken(Guid id)
        {
            var dbAdminAccessToken = this.dbContext.AdminAccessTokens
                .Include(efAdminAccessToken => efAdminAccessToken.AdminAccessTokenAdminAdGroupRelations)
                .Include(efAdminAccessToken => efAdminAccessToken.AdminAccessTokenCachedPermissions)
                .Where(efAdminAccessToken => efAdminAccessToken.Id == id)
                .FirstOrDefault();

            return DbAdminAccessToken.FromEfAdminAccessToken(dbAdminAccessToken);
        }
    }
}