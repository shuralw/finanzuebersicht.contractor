using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IAdminEmailUserDetail
    {
        Guid Id { get; set; }

        string Email { get; set; }

        IDictionary<string, PermissionStatus> Permissions { get; set; }

        IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }
    }
}