using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminLoginSystem.AdminEmailUserLogin
{
    [ApiController]
    [Route("api/session/login")]
    public class AdminEmailUserLoginController : ControllerBase
    {
        private readonly IAdminEmailUserLoginLogic adminEmailUserLoginLogic;

        private readonly IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler;

        public AdminEmailUserLoginController(
            IAdminEmailUserLoginLogic adminEmailUserLoginLogic,
            IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler)
        {
            this.adminEmailUserLoginLogic = adminEmailUserLoginLogic;
            this.adminRefreshTokenCookieHandler = adminRefreshTokenCookieHandler;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Login as AdminEmailUser", Tags = new[] { "Login" })]
        public ActionResult LoginAsAdminEmailUser([FromBody] AdminEmailUserLogin adminEmailUserLogin)
        {
            ILogicResult<IAdminRefreshTokenDetail> loginAsAdminEmailUserResult =
                this.adminEmailUserLoginLogic.LoginAsAdminEmailUser(adminEmailUserLogin.Email, adminEmailUserLogin.Passwort);

            if (!loginAsAdminEmailUserResult.IsSuccessful)
            {
                return this.FromLogicResult(loginAsAdminEmailUserResult);
            }

            IAdminRefreshTokenDetail adminRefreshTokenDetail = loginAsAdminEmailUserResult.Data;
            IAdminRefreshTokenJwtData adminRefreshTokenJwtData = AdminRefreshTokenDetail.ToAdminRefreshTokenJwtData(adminRefreshTokenDetail);
            this.adminRefreshTokenCookieHandler.SetAdminRefreshTokenToCookie(adminRefreshTokenJwtData);
            return this.Ok();
        }
    }
}