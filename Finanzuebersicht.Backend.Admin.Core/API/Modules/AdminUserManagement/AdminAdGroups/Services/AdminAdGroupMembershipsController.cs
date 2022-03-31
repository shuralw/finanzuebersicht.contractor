using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminAdGroups
{
    [ApiController]
    [Route("api/admin-user-management/admin-user-groups/membership/admin-ad-groups")]
    public class AdminAdGroupMembershipsController : ControllerBase
    {
        private readonly IAdminAdGroupsCrudLogic adminAdGroupsCrudLogic;

        public AdminAdGroupMembershipsController(IAdminAdGroupsCrudLogic adminAdGroupsCrudLogic)
        {
            this.adminAdGroupsCrudLogic = adminAdGroupsCrudLogic;
        }

        [HttpPost]
        [Route("add")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult AddAdminAdGroupToAdminUserGroup([FromBody] AdminAdGroupMembership adminAdGroupMembership)
        {
            ILogicResult createAdminAdGroupResult = this.adminAdGroupsCrudLogic.AddAdminAdGroupToAdminUserGroup(
                adminAdGroupMembership.AdminAdGroupId,
                adminAdGroupMembership.AdminUserGroupId);

            return this.FromLogicResult(createAdminAdGroupResult);
        }

        [HttpPost]
        [Route("remove")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult RemoveAdminAdGroupFromAdminUserGroup([FromBody] AdminAdGroupMembership adminAdGroupMembership)
        {
            ILogicResult createAdminAdGroupResult = this.adminAdGroupsCrudLogic.RemoveAdminAdGroupFromAdminUserGroup(
                adminAdGroupMembership.AdminAdGroupId,
                adminAdGroupMembership.AdminUserGroupId);

            return this.FromLogicResult(createAdminAdGroupResult);
        }
    }
}