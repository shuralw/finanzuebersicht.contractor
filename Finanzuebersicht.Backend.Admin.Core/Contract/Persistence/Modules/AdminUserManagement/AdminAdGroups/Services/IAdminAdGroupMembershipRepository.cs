using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    public interface IAdminAdGroupMembershipRepository
    {
        void AddAdminAdGroupToAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId);

        IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminAdGroup(Guid adminAdGroupId);

        void RemoveAdminAdGroupFromAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId);
    }
}