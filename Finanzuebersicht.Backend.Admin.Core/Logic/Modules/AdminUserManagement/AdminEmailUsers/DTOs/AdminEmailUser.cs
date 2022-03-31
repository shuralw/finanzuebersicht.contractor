using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class AdminEmailUser : IAdminEmailUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public static IAdminEmailUser FromDbAdminEmailUser(IDbAdminEmailUser adminEmailUser)
        {
            return new AdminEmailUser()
            {
                Id = adminEmailUser.Id,
                Email = adminEmailUser.Email
            };
        }
    }
}