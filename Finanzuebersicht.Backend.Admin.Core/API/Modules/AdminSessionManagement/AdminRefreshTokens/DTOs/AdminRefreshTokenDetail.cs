using Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminSessionManagement.AdminRefreshTokens
{
    public class AdminRefreshTokenDetail
    {
        public static IAdminRefreshTokenJwtData ToAdminRefreshTokenJwtData(IAdminRefreshTokenDetail adminRefreshTokenDetail)
        {
            return new AdminRefreshTokenJwtData()
            {
                Id = adminRefreshTokenDetail.Id,
                ExpiresOn = adminRefreshTokenDetail.ExpiresOn,
                Username = adminRefreshTokenDetail.Username
            };
        }
    }
}