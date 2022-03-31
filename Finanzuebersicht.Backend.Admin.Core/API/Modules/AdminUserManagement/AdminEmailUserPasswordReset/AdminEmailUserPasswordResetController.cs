using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Tools.UserAgent;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    [ApiController]
    [Route("api/admin-user-management/admin-email-users")]
    [AllowAnonymous]
    public class AdminEmailUserPasswordResetController : ControllerBase
    {
        private readonly IAdminEmailUserPasswordResetLogic adminEmailUserPasswordResetLogic;

        public AdminEmailUserPasswordResetController(IAdminEmailUserPasswordResetLogic adminEmailUserPasswordResetLogic)
        {
            this.adminEmailUserPasswordResetLogic = adminEmailUserPasswordResetLogic;
        }

        [HttpPost]
        [Route("forgotpassword")]
        [SwaggerOperation(Tags = new[] { "AdminEmailUsers" })]
        public ActionResult ForgotPassword([FromBody] AdminEmailUserForgotPassword adminEmailUserForgotPassword)
        {
            var browser = UserAgentParser.GetBrowser(this.Request);
            var operatingSystem = UserAgentParser.GetOperatingSystem(this.Request);

            ILogicResult result = this.adminEmailUserPasswordResetLogic.InitializePasswordReset(adminEmailUserForgotPassword.Email, new BrowserInfo()
            {
                Browser = browser,
                OperatingSystem = operatingSystem
            });

            return this.FromLogicResult(result);
        }

        [HttpPut]
        [Route("resetpassword")]
        [SwaggerOperation(Tags = new[] { "AdminEmailUsers" })]
        public ActionResult ResetPassword([FromBody] AdminEmailUserResetPassword adminEmailUserResetPassword)
        {
            ILogicResult result = this.adminEmailUserPasswordResetLogic.ResetPassword(adminEmailUserResetPassword.Token, adminEmailUserResetPassword.NewPassword);
            return this.FromLogicResult(result);
        }
    }
}