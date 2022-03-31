using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    public interface IDbAdminAdUser
    {
        Guid Id { get; set; }

        string Dn { get; set; }

        IDictionary<string, PermissionStatus> Permissions { get; set; }
    }
}