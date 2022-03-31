using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IAdminEmailUserMembershipRepository
    {
        void AddAdminEmailUserToAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId);

        IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminEmailUser(Guid adminEmailUserId);

        void RemoveAdminEmailUserFromAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId);
    }
}