using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    internal class DbAdminAdGroup : IDbAdminAdGroup
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminAdGroup FromEfAdminAdGroup(EfAdminAdGroup adminAdGroup)
        {
            if (adminAdGroup == null)
            {
                return null;
            }

            return new DbAdminAdGroup()
            {
                Id = adminAdGroup.Id,
                Dn = adminAdGroup.Dn,
                Permissions = DbPermissionsEntry.FromEfPermissionsEntry(adminAdGroup.Permissions)
            };
        }

        public static EfAdminAdGroup ToEfAdminAdGroup(IDbAdminAdGroup adminAdGroup)
        {
            return new EfAdminAdGroup()
            {
                Id = adminAdGroup.Id,
                Dn = adminAdGroup.Dn
            };
        }

        public static void UpdateEfAdminAdGroup(EfAdminAdGroup efAdminAdGroup, IDbAdminAdGroup adminAdGroup)
        {
            efAdminAdGroup.Dn = adminAdGroup.Dn;
        }
    }
}