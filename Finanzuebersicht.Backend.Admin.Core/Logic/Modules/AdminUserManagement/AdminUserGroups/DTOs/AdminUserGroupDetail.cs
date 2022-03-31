using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups
{
    internal class AdminUserGroupDetail : IAdminUserGroupDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        public IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }

        public IEnumerable<IAdminEmailUser> AdminEmailUserMembers { get; set; }

        public IEnumerable<IAdminUserGroup> AdminUserGroupMembers { get; set; }

        public IEnumerable<IAdminAdUser> AdminAdUserMembers { get; set; }

        public IEnumerable<IAdminAdGroup> AdminAdGroupMembers { get; set; }
    }
}