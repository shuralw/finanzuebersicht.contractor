using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    internal class DbAdminUserGroup : IDbAdminUserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminUserGroup FromEfAdminUserGroup(EfAdminUserGroup adminUserGroup)
        {
            if (adminUserGroup == null)
            {
                return null;
            }

            return new DbAdminUserGroup()
            {
                Id = adminUserGroup.Id,
                Name = adminUserGroup.Name,
                Permissions = DbPermissionsEntry.FromEfPermissionsEntry(adminUserGroup.Permissions)
            };
        }

        public static EfAdminUserGroup ToEfAdminUserGroup(IDbAdminUserGroup adminUserGroup)
        {
            return new EfAdminUserGroup()
            {
                Id = adminUserGroup.Id,
                Name = adminUserGroup.Name
            };
        }

        public static void UpdateEfAdminUserGroup(EfAdminUserGroup efAdminUserGroup, IDbAdminUserGroup adminUserGroup)
        {
            efAdminUserGroup.Name = adminUserGroup.Name;
        }
    }
}