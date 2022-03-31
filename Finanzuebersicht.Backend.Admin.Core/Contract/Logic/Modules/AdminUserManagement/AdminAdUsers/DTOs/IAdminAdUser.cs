using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers
{
    public interface IAdminAdUser
    {
        Guid Id { get; set; }

        string Dn { get; set; }
    }
}