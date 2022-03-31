using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class AdminEmailUsersCrudRepository : IAdminEmailUsersCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        private readonly IPaginationContext paginationContext;

        public AdminEmailUsersCrudRepository(
            IPaginationContext paginationContext,
            PersistenceDbContext dbContext)
        {
            this.dbContext = dbContext;

            this.paginationContext = paginationContext;
        }

        public void CreateAdminEmailUser(IDbAdminEmailUser adminEmailUser)
        {
            // AdminEmailUsers
            this.dbContext.AdminEmailUsers.Add(DbAdminEmailUser.ToEfAdminEmailUser(adminEmailUser));

            // AdminEmailUserPermissions
            EfAdminEmailUserPermissionsEntry adminEmailUserPermissionEntry =
                DbPermissionsEntry.ToEfAdminEmailUserPermissionsEntry(adminEmailUser.Id, adminEmailUser.Permissions);
            this.dbContext.AdminEmailUserPermissions.Add(adminEmailUserPermissionEntry);
            this.dbContext.SaveChanges();
        }

        public void DeleteAdminEmailUser(Guid adminEmailUserId)
        {
            EfAdminEmailUser efAdminEmailUser = this.dbContext.AdminEmailUsers
                .Where(efAdminEmailUser => efAdminEmailUser.Id == adminEmailUserId)
                .FirstOrDefault();

            this.dbContext.AdminEmailUsers.Remove(efAdminEmailUser);
            this.dbContext.SaveChanges();
        }

        public bool DoesAdminEmailUserExist(Guid adminEmailUserId)
        {
            return this.dbContext.AdminEmailUsers.Any(efAdminEmailUser => efAdminEmailUser.Id == adminEmailUserId);
        }

        public bool DoesAdminEmailUserExist(string mail)
        {
            return this.dbContext.AdminEmailUsers.Any(efAdminEmailUser => efAdminEmailUser.Email == mail);
        }

        public IDbAdminEmailUser GetAdminEmailUser(Guid adminEmailUserId)
        {
            EfAdminEmailUser efAdminEmailUser = this.dbContext.AdminEmailUsers
                .Include(adminEmailUser => adminEmailUser.Permissions)
                .Where(u => u.Id == adminEmailUserId)
                .FirstOrDefault();

            return DbAdminEmailUser.FromEfAdminEmailUser(efAdminEmailUser);
        }

        public IDbAdminEmailUser GetGlobalAdminEmailUser(Guid adminEmailUserId)
        {
            EfAdminEmailUser efAdminEmailUser = this.dbContext.AdminEmailUsers
                .Include(adminEmailUser => adminEmailUser.Permissions)
                .Where(u => u.Id == adminEmailUserId)
                .FirstOrDefault();

            return DbAdminEmailUser.FromEfAdminEmailUser(efAdminEmailUser);
        }

        public IDbAdminEmailUser GetAdminEmailUser(string mail)
        {
            EfAdminEmailUser efAdminEmailUser = this.dbContext.AdminEmailUsers
                .Include(adminEmailUser => adminEmailUser.Permissions)
                .Where(u => u.Email == mail)
                .FirstOrDefault();

            return DbAdminEmailUser.FromEfAdminEmailUser(efAdminEmailUser);
        }

        public IDbPagedResult<IDbAdminEmailUser> GetPagedAdminEmailUsers()
        {
            // Query
            IQueryable<EfAdminEmailUser> efAdminEmailUsers = this.dbContext.AdminEmailUsers
                .Include(adminEmailUser => adminEmailUser.Permissions);

            // Paged Result
            return Pagination.Filter(
                efAdminEmailUsers,
                this.paginationContext,
                (efAdminEmailUser) => DbAdminEmailUser.FromEfAdminEmailUser(efAdminEmailUser));
        }

        public void UpdateAdminEmailUser(IDbAdminEmailUser dbAdminEmailUser)
        {
            // AdminEmailUser
            var efAdminEmailUser = this.dbContext.AdminEmailUsers
                .Where(efAdminEmailUser => efAdminEmailUser.Id == dbAdminEmailUser.Id)
                .FirstOrDefault();

            DbAdminEmailUser.UpdateEfAdminEmailUser(efAdminEmailUser, dbAdminEmailUser);
            this.dbContext.AdminEmailUsers.Update(efAdminEmailUser);

            // AdminEmailUserPermissions
            EfAdminEmailUserPermissionsEntry efAdminEmailUserPermissionsEntry = this.dbContext.AdminEmailUserPermissions.Find(dbAdminEmailUser.Id);
            DbPermissionsEntry.UpdateEfPermissionsEntry(efAdminEmailUserPermissionsEntry, dbAdminEmailUser.Permissions);
            this.dbContext.AdminEmailUserPermissions.Update(efAdminEmailUserPermissionsEntry);

            this.dbContext.SaveChanges();
        }

        public void UpdateGlobalAdminEmailUser(IDbAdminEmailUser dbAdminEmailUser)
        {
            // AdminEmailUser
            var efAdminEmailUser = this.dbContext.AdminEmailUsers
                .Where(efAdminEmailUser => efAdminEmailUser.Id == dbAdminEmailUser.Id)
                .FirstOrDefault();

            DbAdminEmailUser.UpdateEfAdminEmailUser(efAdminEmailUser, dbAdminEmailUser);
            this.dbContext.AdminEmailUsers.Update(efAdminEmailUser);

            // AdminEmailUserPermissions
            EfAdminEmailUserPermissionsEntry efAdminEmailUserPermissionsEntry = this.dbContext.AdminEmailUserPermissions.Find(dbAdminEmailUser.Id);
            DbPermissionsEntry.UpdateEfPermissionsEntry(efAdminEmailUserPermissionsEntry, dbAdminEmailUser.Permissions);
            this.dbContext.AdminEmailUserPermissions.Update(efAdminEmailUserPermissionsEntry);

            this.dbContext.SaveChanges();
        }
    }
}