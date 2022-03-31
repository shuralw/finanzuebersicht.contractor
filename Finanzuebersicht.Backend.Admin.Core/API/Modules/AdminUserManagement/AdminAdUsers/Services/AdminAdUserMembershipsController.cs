using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminAdUsers
{
    [ApiController]
    [Route("api/admin-user-management/admin-user-groups/membership/admin-ad-users")]
    public class AdminAdUserMembershipsController : ControllerBase
    {
        private readonly IAdminAdUsersCrudLogic adminAdUsersCrudLogic;

        public AdminAdUserMembershipsController(IAdminAdUsersCrudLogic adminAdUsersCrudLogic)
        {
            this.adminAdUsersCrudLogic = adminAdUsersCrudLogic;
        }

        [HttpPost]
        [Route("add")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult AddAdminAdUserToAdminUserGroup([FromBody] AdminAdUserMembership adminAdUserMembership)
        {
            ILogicResult createAdminAdUserResult = this.adminAdUsersCrudLogic.AddAdminAdUserToAdminUserGroup(
                adminAdUserMembership.AdminAdUserId,
                adminAdUserMembership.AdminUserGroupId);

            return this.FromLogicResult(createAdminAdUserResult);
        }

        [HttpPost]
        [Route("remove")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult RemoveAdminAdUserFromAdminUserGroup([FromBody] AdminAdUserMembership adminAdUserMembership)
        {
            ILogicResult createAdminAdUserResult = this.adminAdUsersCrudLogic.RemoveAdminAdUserFromAdminUserGroup(
                adminAdUserMembership.AdminAdUserId,
                adminAdUserMembership.AdminUserGroupId);

            return this.FromLogicResult(createAdminAdUserResult);
        }
    }
}