using Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminSessionManagement.AdminAccessTokens
{
    public class AdminAccessToken
    {
        public static IAdminAccessTokenJwtData ToAdminAccessTokenJwtData(IAdminAccessToken adminAccessToken)
        {
            return new AdminAccessTokenJwtData()
            {
                Id = adminAccessToken.Id,
                ExpiresOn = adminAccessToken.ExpiresOn,
                Username = adminAccessToken.Username,
            };
        }
    }
}