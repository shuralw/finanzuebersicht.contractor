using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups
{
    public interface IAdminAdGroup
    {
        Guid Id { get; set; }

        string Dn { get; set; }
    }
}