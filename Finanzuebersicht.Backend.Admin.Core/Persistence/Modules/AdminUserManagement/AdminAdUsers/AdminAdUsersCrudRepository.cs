using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    internal class AdminAdUsersCrudRepository : IAdminAdUsersCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        private readonly IPaginationContext paginationContext;

        public AdminAdUsersCrudRepository(
            IPaginationContext paginationContext,
            PersistenceDbContext context)
        {
            this.dbContext = context;

            this.paginationContext = paginationContext;
        }

        public void CreateAdminAdUser(IDbAdminAdUser adminAdUser)
        {
            // AdminAdUsers
            this.dbContext.AdminAdUsers.Add(DbAdminAdUser.ToEfAdminAdUser(adminAdUser));

            // AdminAdUserPermissions
            EfAdminAdUserPermissionsEntry adminAdUserPermissionEntry =
                DbPermissionsEntry.ToEfAdminAdUserPermissionsEntry(adminAdUser.Id, adminAdUser.Permissions);
            this.dbContext.AdminAdUserPermissions.Add(adminAdUserPermissionEntry);
            this.dbContext.SaveChanges();
        }

        public void DeleteAdminAdUser(Guid adminAdUserId)
        {
            EfAdminAdUser efAdminAdUser = this.dbContext.AdminAdUsers
                .Where(efAdminAdUser => efAdminAdUser.Id == adminAdUserId)
                .FirstOrDefault();

            this.dbContext.AdminAdUsers.Remove(efAdminAdUser);
            this.dbContext.SaveChanges();
        }

        public bool DoesAdminAdUserExist(string dn)
        {
            bool doesAdminAdUserExist = this.dbContext.AdminAdUsers
                .Where(u => u.Dn == dn)
                .Any();

            return doesAdminAdUserExist;
        }

        public IDbAdminAdUser GetAdminAdUser(Guid adminAdUserId)
        {
            EfAdminAdUser efAdminAdUser = this.dbContext.AdminAdUsers
                .Include(adminAdUser => adminAdUser.Permissions)
                .Where(u => u.Id == adminAdUserId)
                .FirstOrDefault();

            return DbAdminAdUser.FromEfAdminAdUser(efAdminAdUser);
        }

        public IDbAdminAdUser GetGlobalAdminAdUser(Guid adminAdUserId)
        {
            EfAdminAdUser efAdminAdUser = this.dbContext.AdminAdUsers
                .Include(adminAdUser => adminAdUser.Permissions)
                .Where(u => u.Id == adminAdUserId)
                .FirstOrDefault();

            return DbAdminAdUser.FromEfAdminAdUser(efAdminAdUser);
        }

        public IDbPagedResult<IDbAdminAdUser> GetPagedAdminAdUsers()
        {
            // Query
            IQueryable<EfAdminAdUser> efAdminAdUsers = this.dbContext.AdminAdUsers
                .Include(adminAdUser => adminAdUser.Permissions)
                .Where(m => m.Id != Guid.Empty);

            // Paged Result
            return Pagination.Filter(
                efAdminAdUsers,
                this.paginationContext,
                (efAdminAdUser) => DbAdminAdUser.FromEfAdminAdUser(efAdminAdUser));
        }

        public IEnumerable<IDbAdminAdUser> GetGlobalAdminAdUsers(string dn)
        {
            return this.dbContext.AdminAdUsers
                .Include(adminAdUser => adminAdUser.Permissions)
                .Where(adminAdUser => adminAdUser.Dn == dn)
                .OrderBy(adminAdUser => adminAdUser.Dn)
                .Select(efAdminAdUser => DbAdminAdUser.FromEfAdminAdUser(efAdminAdUser));
        }

        public void UpdateAdminAdUser(IDbAdminAdUser dbAdminAdUser)
        {
            // AdminAdUser
            var efAdminAdUser = this.dbContext.AdminAdUsers
                .Where(efAdminAdUser => efAdminAdUser.Id == dbAdminAdUser.Id)
                .FirstOrDefault();

            DbAdminAdUser.UpdateEfAdminAdUser(efAdminAdUser, dbAdminAdUser);
            this.dbContext.AdminAdUsers.Update(efAdminAdUser);

            // AdminAdUserPermissions
            EfAdminAdUserPermissionsEntry efAdminAdUserPermissionsEntry = this.dbContext.AdminAdUserPermissions.Find(dbAdminAdUser.Id);
            DbPermissionsEntry.UpdateEfPermissionsEntry(efAdminAdUserPermissionsEntry, dbAdminAdUser.Permissions);
            this.dbContext.AdminAdUserPermissions.Update(efAdminAdUserPermissionsEntry);

            this.dbContext.SaveChanges();
        }
    }
}