using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminEmailUsers
{
    [ApiController]
    [Route("api/admin-user-management/admin-email-users/change-password")]
    [Authorized]
    public class AdminEmailUserPasswordChangeController : ControllerBase
    {
        private readonly IAdminEmailUserPasswordChangeLogic adminEmailUserPasswordChangeLogic;

        public AdminEmailUserPasswordChangeController(
            IAdminEmailUserPasswordChangeLogic adminEmailUserPasswordChangeLogic)
        {
            this.adminEmailUserPasswordChangeLogic = adminEmailUserPasswordChangeLogic;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "AdminEmailUsers" })]
        public ActionResult ChangePassword([FromBody] AdminEmailUserChangePassword changePassword)
        {
            ILogicResult result = this.adminEmailUserPasswordChangeLogic.ChangePassword(
                changePassword.OldPassword,
                changePassword.NewPassword);
            return this.FromLogicResult(result);
        }
    }
}