namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    public interface IJwtTokenHandler
    {
        IAdminAccessTokenJwtData ExtractAdminAccessToken(string jwtToken);

        IAdminRefreshTokenJwtData ExtractAdminRefreshToken(string jwtToken);

        string GenerateJwtToken(IAdminAccessTokenJwtData adminAccessTokenJwtData);

        string GenerateJwtToken(IAdminRefreshTokenJwtData adminRefreshTokenJwtData);
    }
}