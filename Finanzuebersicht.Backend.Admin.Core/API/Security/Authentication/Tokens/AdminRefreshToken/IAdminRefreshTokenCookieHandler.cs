namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    public interface IAdminRefreshTokenCookieHandler
    {
        IAdminRefreshTokenJwtData GetAdminRefreshTokenFromCookie();

        void RemoveAdminRefreshTokenFromCookie();

        void SetAdminRefreshTokenToCookie(IAdminRefreshTokenJwtData adminRefreshTokenJwtData);
    }
}