using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminEmailUsers
{
    [ApiController]
    [Route("api/admin-user-management/admin-user-groups/membership/admin-email-users")]
    public class AdminEmailUserMembershipsController : ControllerBase
    {
        private readonly IAdminEmailUsersCrudLogic adminEmailUsersCrudLogic;

        public AdminEmailUserMembershipsController(IAdminEmailUsersCrudLogic adminEmailUsersCrudLogic)
        {
            this.adminEmailUsersCrudLogic = adminEmailUsersCrudLogic;
        }

        [HttpPost]
        [Route("add")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult AddAdminEmailUserToAdminUserGroup([FromBody] AdminEmailUserMembership adminEmailUserMembership)
        {
            ILogicResult createAdminEmailUserResult = this.adminEmailUsersCrudLogic.AddAdminEmailUserToAdminUserGroup(
                adminEmailUserMembership.AdminEmailUserId,
                adminEmailUserMembership.AdminUserGroupId);

            return this.FromLogicResult(createAdminEmailUserResult);
        }

        [HttpPost]
        [Route("remove")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult RemoveAdminEmailUserFromAdminUserGroup([FromBody] AdminEmailUserMembership adminEmailUserMembership)
        {
            ILogicResult createAdminEmailUserResult = this.adminEmailUsersCrudLogic.RemoveAdminEmailUserFromAdminUserGroup(
                adminEmailUserMembership.AdminEmailUserId,
                adminEmailUserMembership.AdminUserGroupId);

            return this.FromLogicResult(createAdminEmailUserResult);
        }
    }
}