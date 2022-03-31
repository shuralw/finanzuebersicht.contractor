using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class DbAdminEmailUser : IDbAdminEmailUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }
    }
}