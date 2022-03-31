using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions
{
    internal class AdminUserGroupPermissionsCalculationLogic : IAdminUserGroupPermissionsCalculationLogic
    {
        private readonly IAdminUserGroupMembershipRepository adminUserGroupMembershipRepository;

        public AdminUserGroupPermissionsCalculationLogic(
            IAdminUserGroupMembershipRepository adminUserGroupMembershipRepository)
        {
            this.adminUserGroupMembershipRepository = adminUserGroupMembershipRepository;
        }

        public IDictionary<string, PermissionStatus> CalculatePermissionsForAdminUserGroups(IEnumerable<IDbAdminUserGroup> adminUserGroups)
        {
            var permissions = adminUserGroups.SelectMany(adminUserGroup => this.GetAllPermissionsOfAdminUserGroupParents(adminUserGroup));
            return PermissionsCalculation.Aggregate(permissions);
        }

        private List<IDictionary<string, PermissionStatus>> GetAllPermissionsOfAdminUserGroupParents(IDbAdminUserGroup adminUserGroup)
        {
            List<IDictionary<string, PermissionStatus>> permissions = new List<IDictionary<string, PermissionStatus>>
            {
                adminUserGroup.Permissions
            };

            var directParents = this.adminUserGroupMembershipRepository.GetAdminUserGroupParentsOfAdminUserGroup(adminUserGroup.Id).ToList();
            var allParentsPermissions = directParents.SelectMany(parent => this.GetAllPermissionsOfAdminUserGroupParents(parent));
            permissions.AddRange(allParentsPermissions);

            return permissions;
        }
    }
}