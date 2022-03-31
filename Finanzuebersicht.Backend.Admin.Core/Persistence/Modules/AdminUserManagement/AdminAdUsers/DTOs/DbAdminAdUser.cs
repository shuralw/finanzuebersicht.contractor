using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    internal class DbAdminAdUser : IDbAdminAdUser
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminAdUser FromEfAdminAdUser(EfAdminAdUser adminAdUser)
        {
            if (adminAdUser == null)
            {
                return null;
            }

            return new DbAdminAdUser()
            {
                Id = adminAdUser.Id,
                Dn = adminAdUser.Dn,
                Permissions = DbPermissionsEntry.FromEfPermissionsEntry(adminAdUser.Permissions)
            };
        }

        public static EfAdminAdUser ToEfAdminAdUser(IDbAdminAdUser adminAdUser)
        {
            return new EfAdminAdUser()
            {
                Id = adminAdUser.Id,
                Dn = adminAdUser.Dn
            };
        }

        public static void UpdateEfAdminAdUser(EfAdminAdUser efAdminAdUser, IDbAdminAdUser adminAdUser)
        {
            efAdminAdUser.Dn = adminAdUser.Dn;
        }
    }
}