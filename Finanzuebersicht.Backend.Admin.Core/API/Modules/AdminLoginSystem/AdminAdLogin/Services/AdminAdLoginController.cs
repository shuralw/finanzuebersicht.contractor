using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.Ad;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminLoginSystem.AdminAdLogin
{
    [ApiController]
    [Route("api/session/login/ad")]
    public class AdminAdLoginController : ControllerBase
    {
        private readonly IAdminAdLoginLogic adminAdLoginLogic;
        private readonly IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler;

        public AdminAdLoginController(
            IAdminAdLoginLogic adminAdLoginLogic,
            IAdminRefreshTokenCookieHandler adminRefreshTokenCookieHandler)
        {
            this.adminAdLoginLogic = adminAdLoginLogic;
            this.adminRefreshTokenCookieHandler = adminRefreshTokenCookieHandler;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Login with SSO", Tags = new[] { "Login" })]
        public async Task<ActionResult> LoginWithSsoToken([FromBody] ApiSsoToken ssoToken)
        {
            var loginAsAdminAdUserResult = await this.adminAdLoginLogic.LoginWithSsoToken(ssoToken.SsoToken);

            if (!loginAsAdminAdUserResult.IsSuccessful)
            {
                return this.FromLogicResult(loginAsAdminAdUserResult);
            }

            IAdminRefreshTokenDetail adminRefreshTokenDetail = loginAsAdminAdUserResult.Data;
            IAdminRefreshTokenJwtData adminRefreshTokenJwtData = AdminRefreshTokenDetail.ToAdminRefreshTokenJwtData(adminRefreshTokenDetail);
            this.adminRefreshTokenCookieHandler.SetAdminRefreshTokenToCookie(adminRefreshTokenJwtData);

            return this.Ok();
        }
    }
}