using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdGroups
{
    internal class AdminAdGroup : IAdminAdGroup
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public static IAdminAdGroup FromDbAdminAdGroup(IDbAdminAdGroup adminAdGroup)
        {
            return new AdminAdGroup()
            {
                Id = adminAdGroup.Id,
                Dn = adminAdGroup.Dn
            };
        }
    }
}