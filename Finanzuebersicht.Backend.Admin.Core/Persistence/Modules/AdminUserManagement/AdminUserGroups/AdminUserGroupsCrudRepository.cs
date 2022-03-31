using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    internal class AdminUserGroupsCrudRepository : IAdminUserGroupsCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        private readonly IPaginationContext paginationContext;

        public AdminUserGroupsCrudRepository(
            IPaginationContext paginationContext,
            PersistenceDbContext context)
        {
            this.dbContext = context;

            this.paginationContext = paginationContext;
        }

        public void CreateAdminUserGroup(IDbAdminUserGroup adminUserGroup)
        {
            // AdminUserGroup
            this.dbContext.AdminUserGroups.Add(DbAdminUserGroup.ToEfAdminUserGroup(adminUserGroup));

            // AdminUserGroupPermissions
            EfAdminUserGroupPermissionsEntry adminUserGroupPermissionEntry = DbPermissionsEntry
                .ToEfAdminUserGroupPermissionsEntry(adminUserGroup.Id, adminUserGroup.Permissions);
            this.dbContext.AdminUserGroupPermissions.Add(adminUserGroupPermissionEntry);

            this.dbContext.SaveChanges();
        }

        public bool DoesAdminUserGroupExist(string name)
        {
            return this.dbContext.AdminUserGroups
                .Include(adminUserGroup => adminUserGroup.Permissions)
                .Any(u => u.Name.ToLower() == name.ToLower());
        }

        public void DeleteAdminUserGroup(Guid adminUserGroupId)
        {
            EfAdminUserGroup efAdminUserGroup = this.dbContext.AdminUserGroups
                .Where(efAdminUserGroup => efAdminUserGroup.Id == adminUserGroupId)
                .FirstOrDefault();

            this.dbContext.AdminUserGroups.Remove(efAdminUserGroup);
            this.dbContext.SaveChanges();
        }

        public IDbAdminUserGroup GetAdminUserGroup(Guid adminUserGroupId)
        {
            EfAdminUserGroup efAdminUserGroup = this.dbContext.AdminUserGroups
                .Include(adminUserGroup => adminUserGroup.Permissions)
                .Where(u => u.Id == adminUserGroupId)
                .FirstOrDefault();

            return DbAdminUserGroup.FromEfAdminUserGroup(efAdminUserGroup);
        }

        public IDbPagedResult<IDbAdminUserGroup> GetPagedAdminUserGroups()
        {
            // Query
            IQueryable<EfAdminUserGroup> efAdminUserGroups = this.dbContext.AdminUserGroups
                .Include(adminUserGroup => adminUserGroup.Permissions);

            // Paged Result
            return Pagination.Filter(
                efAdminUserGroups,
                this.paginationContext,
                (efAdminUserGroup) => DbAdminUserGroup.FromEfAdminUserGroup(efAdminUserGroup));
        }

        public void UpdateAdminUserGroup(IDbAdminUserGroup adminUserGroup)
        {
            // AdminUserGroup
            var efAdminUserGroup = this.dbContext.AdminUserGroups
                .Where(efAdminUserGroup => efAdminUserGroup.Id == adminUserGroup.Id)
                .FirstOrDefault();

            DbAdminUserGroup.UpdateEfAdminUserGroup(efAdminUserGroup, adminUserGroup);
            this.dbContext.AdminUserGroups.Update(efAdminUserGroup);

            // AdminUserGroupPermissions
            EfAdminUserGroupPermissionsEntry efAdminUserGroupPermissionsEntry = this.dbContext.AdminUserGroupPermissions.Find(adminUserGroup.Id);
            DbPermissionsEntry.UpdateEfPermissionsEntry(efAdminUserGroupPermissionsEntry, adminUserGroup.Permissions);
            this.dbContext.AdminUserGroupPermissions.Update(efAdminUserGroupPermissionsEntry);

            this.dbContext.SaveChanges();
        }
    }
}