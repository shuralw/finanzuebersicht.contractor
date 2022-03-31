using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions
{
    internal class AdminEmailUserPermissionsCalculationLogic : IAdminEmailUserPermissionsCalculationLogic
    {
        private readonly IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository;
        private readonly IAdminEmailUserMembershipRepository adminEmailUserMembershipRepository;
        private readonly IAdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic;

        public AdminEmailUserPermissionsCalculationLogic(
            IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository,
            IAdminEmailUserMembershipRepository adminEmailUserMembershipRepository,
            IAdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic)
        {
            this.adminEmailUsersCrudRepository = adminEmailUsersCrudRepository;
            this.adminEmailUserMembershipRepository = adminEmailUserMembershipRepository;
            this.adminUserGroupPermissionsCalculationLogic = adminUserGroupPermissionsCalculationLogic;
        }

        public IDictionary<string, PermissionStatus> CalculatePermissionsForAdminEmailUser(Guid adminEmailUserId)
        {
            List<IDictionary<string, PermissionStatus>> permissions = new List<IDictionary<string, PermissionStatus>>();

            this.AddAdminEmailUserToPermissionsCalculation(permissions, adminEmailUserId);
            this.AddAdminUserGroupToPermissionsCalculation(permissions, this.adminEmailUserMembershipRepository.GetAdminUserGroupsOfAdminEmailUser(adminEmailUserId));

            IDictionary<string, PermissionStatus> sessionPermissions = PermissionsCalculation.Aggregate(permissions);

            return sessionPermissions;
        }

        public IDictionary<string, PermissionStatus> CalculateStrictPermissionsForAdminEmailUser(Guid adminEmailUserId)
        {
            IDictionary<string, PermissionStatus> sessionPermissions = this.CalculatePermissionsForAdminEmailUser(adminEmailUserId);
            sessionPermissions = PermissionsCalculation.ToStrictPermissions(sessionPermissions);

            return sessionPermissions;
        }

        private void AddAdminEmailUserToPermissionsCalculation(List<IDictionary<string, PermissionStatus>> permissions, Guid adminEmailUserId)
        {
            var adminEmailUser = this.adminEmailUsersCrudRepository.GetGlobalAdminEmailUser(adminEmailUserId);
            permissions.Add(adminEmailUser.Permissions);
        }

        private void AddAdminUserGroupToPermissionsCalculation(List<IDictionary<string, PermissionStatus>> permissions, IEnumerable<IDbAdminUserGroup> adminUserGroups)
        {
            if (adminUserGroups.Any())
            {
                var adminUserGroupPermissions = this.adminUserGroupPermissionsCalculationLogic.CalculatePermissionsForAdminUserGroups(adminUserGroups);
                permissions.Add(adminUserGroupPermissions);
            }
        }
    }
}