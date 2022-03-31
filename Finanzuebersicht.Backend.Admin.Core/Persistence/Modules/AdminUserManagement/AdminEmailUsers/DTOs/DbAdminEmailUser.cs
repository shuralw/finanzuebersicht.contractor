using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class DbAdminEmailUser : IDbAdminEmailUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminEmailUser FromEfAdminEmailUser(EfAdminEmailUser efAdminEmailUser)
        {
            if (efAdminEmailUser == null)
            {
                return null;
            }

            return new DbAdminEmailUser()
            {
                Id = efAdminEmailUser.Id,
                Email = efAdminEmailUser.Email,
                PasswordHash = efAdminEmailUser.PasswordHash,
                PasswordSalt = efAdminEmailUser.PasswordSalt,
                Permissions = DbPermissionsEntry.FromEfPermissionsEntry(efAdminEmailUser.Permissions)
            };
        }

        public static EfAdminEmailUser ToEfAdminEmailUser(IDbAdminEmailUser adminEmailUser)
        {
            return new EfAdminEmailUser()
            {
                Id = adminEmailUser.Id,
                Email = adminEmailUser.Email,
                PasswordHash = adminEmailUser.PasswordHash,
                PasswordSalt = adminEmailUser.PasswordSalt
            };
        }

        public static void UpdateEfAdminEmailUser(EfAdminEmailUser efAdminEmailUser, IDbAdminEmailUser adminEmailUser)
        {
            efAdminEmailUser.Email = adminEmailUser.Email;
            efAdminEmailUser.PasswordHash = adminEmailUser.PasswordHash;
            efAdminEmailUser.PasswordSalt = adminEmailUser.PasswordSalt;
        }
    }
}