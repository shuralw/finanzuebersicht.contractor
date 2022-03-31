using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups
{
    internal class AdminUserGroup : IAdminUserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static IAdminUserGroup FromDbAdminUserGroup(IDbAdminUserGroup adminUserGroup)
        {
            return new AdminUserGroup()
            {
                Id = adminUserGroup.Id,
                Name = adminUserGroup.Name
            };
        }
    }
}