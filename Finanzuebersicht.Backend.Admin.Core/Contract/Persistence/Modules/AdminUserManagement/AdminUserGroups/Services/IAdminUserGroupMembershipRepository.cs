using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    public interface IAdminUserGroupMembershipRepository
    {
        void AddAdminUserGroupToAdminUserGroup(Guid adminUserGroupId, Guid parentId);

        bool HasCircularMembership(Guid adminUserGroupId);

        IEnumerable<IDbAdminUserGroup> GetAdminUserGroupParentsOfAdminUserGroup(Guid adminUserGroupId);

        IEnumerable<IDbAdminEmailUser> GetAdminEmailUsersOfAdminUserGroup(Guid adminUserGroupId);

        IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminUserGroup(Guid adminUserGroupId);

        IEnumerable<IDbAdminAdUser> GetAdminAdUsersOfAdminUserGroup(Guid adminUserGroupId);

        IEnumerable<IDbAdminAdGroup> GetAdminAdGroupsOfAdminUserGroup(Guid adminUserGroupId);

        void RemoveAdminUserGroupFromAdminUserGroup(Guid adminUserGroupId, Guid parentAdminUserGroupId);
    }
}