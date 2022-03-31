using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups
{
    internal class DbAdminUserGroup : IDbAdminUserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }
    }
}