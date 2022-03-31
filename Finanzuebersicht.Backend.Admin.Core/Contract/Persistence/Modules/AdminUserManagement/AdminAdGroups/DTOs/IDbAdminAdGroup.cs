using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    public interface IDbAdminAdGroup
    {
        Guid Id { get; set; }

        string Dn { get; set; }

        IDictionary<string, PermissionStatus> Permissions { get; set; }
    }
}