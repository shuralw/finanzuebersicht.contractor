using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions
{
    internal class AdPermissionsCalculationLogic : IAdPermissionsCalculationLogic
    {
        private readonly IAdminAdUsersCrudRepository adminAdUsersCrudRepository;
        private readonly IAdminAdGroupsCrudRepository adminAdGroupsCrudRepository;
        private readonly IAdminAdUserMembershipRepository adminAdUserMembershipRepository;
        private readonly IAdminAdGroupMembershipRepository adminAdGroupMembershipRepository;
        private readonly IAdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic;

        public AdPermissionsCalculationLogic(
            IAdminAdUsersCrudRepository adminAdUsersCrudRepository,
            IAdminAdGroupsCrudRepository adminAdGroupsCrudRepository,
            IAdminAdUserMembershipRepository adminAdUserMembershipRepository,
            IAdminAdGroupMembershipRepository adminAdGroupMembershipRepository,
            IAdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic)
        {
            this.adminAdUsersCrudRepository = adminAdUsersCrudRepository;
            this.adminAdGroupsCrudRepository = adminAdGroupsCrudRepository;
            this.adminAdUserMembershipRepository = adminAdUserMembershipRepository;
            this.adminAdGroupMembershipRepository = adminAdGroupMembershipRepository;
            this.adminUserGroupPermissionsCalculationLogic = adminUserGroupPermissionsCalculationLogic;
        }

        public IDictionary<string, PermissionStatus> CalculatePermissionsForAd(Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds)
        {
            List<IDictionary<string, PermissionStatus>> permissions = new List<IDictionary<string, PermissionStatus>>();

            if (adminAdUserId != null)
            {
                IDbAdminAdUser dbAdminAdUser = this.adminAdUsersCrudRepository.GetGlobalAdminAdUser(adminAdUserId.Value);
                permissions.Add(dbAdminAdUser.Permissions);

                IEnumerable<IDbAdminUserGroup> parentAdminUserGroups = this.adminAdUserMembershipRepository.GetAdminUserGroupsOfAdminAdUser(adminAdUserId.Value);
                this.AddAdminUserGroupToPermissionsCalculation(permissions, parentAdminUserGroups);
            }

            if (adminAdGroupIds != null && adminAdGroupIds.Any())
            {
                foreach (var adminAdGroupId in adminAdGroupIds)
                {
                    IDbAdminAdGroup dbAdminAdGroup = this.adminAdGroupsCrudRepository.GetGlobalAdminAdGroup(adminAdGroupId);
                    permissions.Add(dbAdminAdGroup.Permissions);

                    IEnumerable<IDbAdminUserGroup> parentAdminUserGroups = this.adminAdGroupMembershipRepository.GetAdminUserGroupsOfAdminAdGroup(adminAdGroupId);
                    this.AddAdminUserGroupToPermissionsCalculation(permissions, parentAdminUserGroups);
                }
            }

            IDictionary<string, PermissionStatus> sessionPermissions = PermissionsCalculation.Aggregate(permissions);
            return sessionPermissions;
        }

        public IDictionary<string, PermissionStatus> CalculateStrictPermissionsForAd(Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds)
        {
            IDictionary<string, PermissionStatus> sessionPermissions = this.CalculatePermissionsForAd(adminAdUserId, adminAdGroupIds);
            sessionPermissions = PermissionsCalculation.ToStrictPermissions(sessionPermissions);

            return sessionPermissions;
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