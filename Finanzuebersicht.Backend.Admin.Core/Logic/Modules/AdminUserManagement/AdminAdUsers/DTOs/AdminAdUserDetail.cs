using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdUsers
{
    internal class AdminAdUserDetail : IAdminAdUserDetail
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        public IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }
    }
}