using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IDbAdminEmailUser
    {
        Guid Id { get; set; }

        string Email { get; set; }

        string PasswordHash { get; set; }

        string PasswordSalt { get; set; }

        IDictionary<string, PermissionStatus> Permissions { get; set; }
    }
}