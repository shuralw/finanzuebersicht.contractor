using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    public interface IAdminRefreshTokenJwtData
    {
        DateTime ExpiresOn { get; set; }

        Guid Id { get; set; }

        string Username { get; set; }
    }
}