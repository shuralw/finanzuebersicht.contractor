using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens
{
    public class AdminRefreshTokensCrudRepository : IAdminRefreshTokensCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        public AdminRefreshTokensCrudRepository(PersistenceDbContext context)
        {
            this.dbContext = context;
        }

        public void CreateAdminRefreshToken(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            // Add AdminRefreshToken
            EfAdminRefreshToken entity = DbAdminRefreshToken.ToEfAdminRefreshToken(dbAdminRefreshToken);
            this.dbContext.AdminRefreshTokens.Add(entity);

            // Add AdminRefreshToken-AdminAdGroup-Relations
            this.dbContext.AdminRefreshTokenAdminAdGroupRelations.AddRange(dbAdminRefreshToken.AdminAdGroupIds.Select(adminAdGroupId =>
            {
                return new EfAdminRefreshTokenAdminAdGroupRelation()
                {
                    AdminAdGroupId = adminAdGroupId,
                    AdminRefreshTokenId = dbAdminRefreshToken.Id
                };
            }));

            this.dbContext.SaveChanges();

            var test = this.dbContext.AdminRefreshTokens.ToList();
        }

        public void DeleteExpiredAdminRefreshTokens(DateTime now)
        {
            var adminRefreshTokensToDelete = this.dbContext.AdminRefreshTokens
                .Where(adminRefreshToken => adminRefreshToken.ExpiresOn <= now);

            this.dbContext.AdminRefreshTokens.RemoveRange(adminRefreshTokensToDelete);

            this.dbContext.SaveChanges();
        }

        public void DeleteAdminRefreshToken(Guid id)
        {
            var adminRefreshTokenToRemove = this.dbContext.AdminRefreshTokens.Find(id);
            this.dbContext.AdminRefreshTokens.Remove(adminRefreshTokenToRemove);
            this.dbContext.SaveChanges();
        }

        public void DeleteAdminRefreshTokensOfAdminEmailUser(Guid adminEmailUserId)
        {
            var adminRefreshTokensToDelete = this.dbContext.AdminRefreshTokens
                .Where(session => session.AdminEmailUserId == adminEmailUserId);

            this.dbContext.AdminRefreshTokens.RemoveRange(adminRefreshTokensToDelete);

            this.dbContext.SaveChanges();
        }

        public bool DoesAdminRefreshTokenExist(Guid adminRefreshTokenId)
        {
            return this.dbContext.AdminRefreshTokens
                .Any(efAdminRefreshToken => efAdminRefreshToken.Id == adminRefreshTokenId);
        }

        public IDbAdminRefreshToken GetAdminRefreshToken(Guid id)
        {
            var dbAdminRefreshToken = this.dbContext.AdminRefreshTokens
                .Include(efAdminRefreshToken => efAdminRefreshToken.AdminRefreshTokenAdminAdGroupRelations)
                .Where(efAdminRefreshToken => efAdminRefreshToken.Id == id)
                .FirstOrDefault();

            return DbAdminRefreshToken.FromEfAdminRefreshToken(dbAdminRefreshToken);
        }
    }
}