using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    internal class AdminAdGroupsCrudRepository : IAdminAdGroupsCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        private readonly IPaginationContext paginationContext;

        public AdminAdGroupsCrudRepository(
            IPaginationContext paginationContext,
            PersistenceDbContext context)
        {
            this.dbContext = context;

            this.paginationContext = paginationContext;
        }

        public void CreateAdminAdGroup(IDbAdminAdGroup adminAdGroup)
        {
            // AdminAdGroups
            this.dbContext.AdminAdGroups.Add(DbAdminAdGroup.ToEfAdminAdGroup(adminAdGroup));

            // AdminAdGroupPermissions
            EfAdminAdGroupPermissionsEntry adminAdGroupPermissionEntry =
                DbPermissionsEntry.ToEfAdminAdGroupPermissionsEntry(adminAdGroup.Id, adminAdGroup.Permissions);
            this.dbContext.AdminAdGroupPermissions.Add(adminAdGroupPermissionEntry);
            this.dbContext.SaveChanges();
        }

        public void DeleteAdminAdGroup(Guid adminAdGroupId)
        {
            this.dbContext.AdminAdGroups.Remove(this.dbContext.AdminAdGroups.Find(adminAdGroupId));
            this.dbContext.SaveChanges();
        }

        public bool DoesAdminAdGroupExist(string dn)
        {
            bool doesAdminAdGroupExist = this.dbContext.AdminAdGroups
                .Where(u => u.Dn == dn)
                .Any();

            return doesAdminAdGroupExist;
        }

        public IDbAdminAdGroup GetAdminAdGroup(Guid adminAdGroupId)
        {
            EfAdminAdGroup efAdminAdGroup = this.dbContext.AdminAdGroups
                .Include(adminAdGroup => adminAdGroup.Permissions)
                .Where(adminAdGroup => adminAdGroup.Id == adminAdGroupId)
                .FirstOrDefault();

            return DbAdminAdGroup.FromEfAdminAdGroup(efAdminAdGroup);
        }

        public IDbAdminAdGroup GetGlobalAdminAdGroup(Guid adminAdGroupId)
        {
            EfAdminAdGroup efAdminAdGroup = this.dbContext.AdminAdGroups
                .Include(adminAdGroup => adminAdGroup.Permissions)
                .Where(adminAdGroup => adminAdGroup.Id == adminAdGroupId)
                .FirstOrDefault();

            return DbAdminAdGroup.FromEfAdminAdGroup(efAdminAdGroup);
        }

        public IDbPagedResult<IDbAdminAdGroup> GetPagedAdminAdGroups()
        {
            // Query
            IQueryable<EfAdminAdGroup> efAdminAdGroups = this.dbContext.AdminAdGroups
                .Include(adminAdGroup => adminAdGroup.Permissions);

            // Paged Result
            return Pagination.Filter(
                efAdminAdGroups,
                this.paginationContext,
                (efAdminAdGroup) => DbAdminAdGroup.FromEfAdminAdGroup(efAdminAdGroup));
        }

        public IEnumerable<IDbAdminAdGroup> GetGlobalAdminAdGroups()
        {
            return this.dbContext.AdminAdGroups
                .Include(adminAdGroup => adminAdGroup.Permissions)
                .OrderBy(adminAdGroup => adminAdGroup.Dn)
                .Select(efAdminAdGroup => DbAdminAdGroup.FromEfAdminAdGroup(efAdminAdGroup));
        }

        public IEnumerable<IDbAdminAdGroup> GetGlobalAdminAdGroups(string dn)
        {
            return this.dbContext.AdminAdGroups
                .Include(adminAdGroup => adminAdGroup.Permissions)
                .Where(u => u.Dn == dn)
                .OrderBy(adminAdGroup => adminAdGroup.Dn)
                .Select(efAdminAdGroup => DbAdminAdGroup.FromEfAdminAdGroup(efAdminAdGroup));
        }

        public void UpdateAdminAdGroup(IDbAdminAdGroup dbAdminAdGroup)
        {
            // AdminAdGroup
            var efAdminAdGroup = this.dbContext.AdminAdGroups
                .Where(efAdminAdGroup => efAdminAdGroup.Id == dbAdminAdGroup.Id)
                .FirstOrDefault();

            DbAdminAdGroup.UpdateEfAdminAdGroup(efAdminAdGroup, dbAdminAdGroup);
            this.dbContext.AdminAdGroups.Update(efAdminAdGroup);

            // AdminAdGroupPermissions
            EfAdminAdGroupPermissionsEntry efAdminAdGroupPermissionsEntry = this.dbContext.AdminAdGroupPermissions.Find(dbAdminAdGroup.Id);
            DbPermissionsEntry.UpdateEfPermissionsEntry(efAdminAdGroupPermissionsEntry, dbAdminAdGroup.Permissions);
            this.dbContext.AdminAdGroupPermissions.Update(efAdminAdGroupPermissionsEntry);

            this.dbContext.SaveChanges();
        }
    }
}