using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups
{
    public interface IAdminUserGroupDetail
    {
        Guid Id { get; set; }

        string Name { get; set; }

        IDictionary<string, PermissionStatus> Permissions { get; set; }

        IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }

        IEnumerable<IAdminEmailUser> AdminEmailUserMembers { get; set; }

        IEnumerable<IAdminUserGroup> AdminUserGroupMembers { get; set; }

        IEnumerable<IAdminAdUser> AdminAdUserMembers { get; set; }

        IEnumerable<IAdminAdGroup> AdminAdGroupMembers { get; set; }
    }
}