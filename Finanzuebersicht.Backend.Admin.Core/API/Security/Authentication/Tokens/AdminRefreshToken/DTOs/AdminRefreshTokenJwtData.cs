using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    public class AdminRefreshTokenJwtData : IAdminRefreshTokenJwtData
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}