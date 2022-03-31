using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminSessionManagement.Sessions
{
    [ApiController]
    [Route("api/session")]
    public class SessionController : ControllerBase
    {
        private readonly IAdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic;
        private readonly IAdminAccessTokensCrudLogic adminAccessTokensCrudLogic;

        private readonly IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler;

        public SessionController(
            IAdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic,
            IAdminAccessTokensCrudLogic adminAccessTokensCrudLogic,
            IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler)
        {
            this.adminRefreshTokensCrudLogic = adminRefreshTokensCrudLogic;
            this.adminAccessTokensCrudLogic = adminAccessTokensCrudLogic;

            this.adminRefreshTokenCookieHandler = adminRefreshTokenCookieHandler;
        }

        [HttpGet]
        [Authorized]
        [SwaggerOperation(Tags = new[] { "AdminSessionManagement" })]
        public ActionResult<IAdminAccessTokenDetail> GetSession()
        {
            Guid adminAccessTokenId = this.User.GetAdminAccessTokenId();

            ILogicResult<IAdminAccessTokenDetail> sessionResult = this.adminAccessTokensCrudLogic.GetAdminAccessTokenDetail(adminAccessTokenId);

            return this.FromLogicResult(sessionResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("logout")]
        [SwaggerOperation(Tags = new[] { "AdminSessionManagement" })]
        public ActionResult Logout()
        {
            Guid adminRefreshTokenId = this.User.GetAdminRefreshTokenId();

            ILogicResult terminateSessionResult = this.adminRefreshTokensCrudLogic.DeleteAdminRefreshToken(adminRefreshTokenId);

            this.adminRefreshTokenCookieHandler.RemoveAdminRefreshTokenFromCookie();

            return this.FromLogicResult(terminateSessionResult);
        }
    }
}