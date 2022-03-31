using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    public interface IAdminAdUserMembershipRepository
    {
        void AddAdminAdUserToAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId);

        IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminAdUser(Guid adminAdUserId);

        void RemoveAdminAdUserFromAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId);
    }
}