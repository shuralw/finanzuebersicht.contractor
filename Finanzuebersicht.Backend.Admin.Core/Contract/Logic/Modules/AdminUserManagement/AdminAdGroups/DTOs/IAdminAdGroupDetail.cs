using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups
{
    public interface IAdminAdGroupDetail
    {
        Guid Id { get; set; }

        string Dn { get; set; }

        IDictionary<string, PermissionStatus> Permissions { get; set; }

        IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }
    }
}