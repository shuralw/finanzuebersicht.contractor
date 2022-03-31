using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdUsers
{
    internal class DbAdminAdUser : IDbAdminAdUser
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }
    }
}