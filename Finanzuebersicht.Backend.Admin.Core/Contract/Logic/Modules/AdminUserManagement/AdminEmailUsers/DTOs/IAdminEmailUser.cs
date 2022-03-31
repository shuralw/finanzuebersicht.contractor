using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IAdminEmailUser
    {
        Guid Id { get; set; }

        string Email { get; set; }
    }
}