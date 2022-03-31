using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdUsers
{
    internal class AdminAdUser : IAdminAdUser
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public static IAdminAdUser FromDbAdminAdUser(IDbAdminAdUser adminAdUser)
        {
            return new AdminAdUser()
            {
                Id = adminAdUser.Id,
                Dn = adminAdUser.Dn
            };
        }
    }
}