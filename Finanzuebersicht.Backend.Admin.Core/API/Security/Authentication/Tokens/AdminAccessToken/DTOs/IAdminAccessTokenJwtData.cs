using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    public interface IAdminAccessTokenJwtData
    {
        DateTime ExpiresOn { get; set; }

        Guid Id { get; set; }

        string Username { get; set; }
    }
}