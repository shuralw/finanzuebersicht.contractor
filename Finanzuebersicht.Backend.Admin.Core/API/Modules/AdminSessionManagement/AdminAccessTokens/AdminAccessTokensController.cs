using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminSessionManagement.AdminAccessTokens
{
    [ApiController]
    [Route("api/session/access")]
    public class AdminAccessTokensController : ControllerBase
    {
        private readonly IAdminAccessTokensCrudLogic adminAccessTokensCrudLogic;

        private readonly IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler;

        private readonly IJwtTokenHandler jwtTokenHandler;

        public AdminAccessTokensController(
            IAdminAccessTokensCrudLogic adminAccessTokensCrudLogic,
            IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler,
            IJwtTokenHandler jwtTokenHandler)
        {
            this.adminAccessTokensCrudLogic = adminAccessTokensCrudLogic;
            this.adminRefreshTokenCookieHandler = adminRefreshTokenCookieHandler;
            this.jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(Tags = new[] { "AdminSessionManagement" })]
        public ActionResult<DataBody<string>> CreateAdminAccessToken()
        {
            IAdminRefreshTokenJwtData adminRefreshTokenJwtData;
            try
            {
                adminRefreshTokenJwtData = this.adminRefreshTokenCookieHandler.GetAdminRefreshTokenFromCookie();
            }
            catch
            {
                return this.Unauthorized();
            }

            ILogicResult<IAdminAccessToken> adminAccessTokenResult = this.adminAccessTokensCrudLogic.CreateAdminAccessTokenFromAdminRefreshToken(adminRefreshTokenJwtData.Id);
            if (!adminAccessTokenResult.IsSuccessful)
            {
                this.adminRefreshTokenCookieHandler.RemoveAdminRefreshTokenFromCookie();
                return this.Unauthorized();
            }

            var adminAccessTokenJwtData = AdminAccessToken.ToAdminAccessTokenJwtData(adminAccessTokenResult.Data);
            var jwtToken = this.jwtTokenHandler.GenerateJwtToken(adminAccessTokenJwtData);

            return this.Ok(new DataBody<string>(jwtToken));
        }
    }
}