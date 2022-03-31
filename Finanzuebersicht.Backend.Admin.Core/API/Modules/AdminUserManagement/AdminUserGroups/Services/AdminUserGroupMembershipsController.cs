using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminUserGroups
{
    [ApiController]
    [Route("api/admin-user-management/admin-user-groups/membership/admin-user-groups")]
    public class AdminUserGroupMembershipsController : ControllerBase
    {
        private readonly IAdminUserGroupsCrudLogic adminUserGroupsCrudLogic;

        public AdminUserGroupMembershipsController(IAdminUserGroupsCrudLogic adminUserGroupsCrudLogic)
        {
            this.adminUserGroupsCrudLogic = adminUserGroupsCrudLogic;
        }

        [HttpPost]
        [Route("add")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult AddAdminUserGroupToAdminUserGroup([FromBody] AdminUserGroupMembership adminUserGroupMembership)
        {
            ILogicResult createAdminUserGroupResult = this.adminUserGroupsCrudLogic.AddAdminUserGroupToAdminUserGroup(
                adminUserGroupMembership.AdminUserGroupId,
                adminUserGroupMembership.ParentAdminUserGroupId);

            return this.FromLogicResult(createAdminUserGroupResult);
        }

        [HttpPost]
        [Route("remove")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [SwaggerOperation(Tags = new[] { "AdminUserGroupMembership" })]
        public ActionResult RemoveAdminUserGroupFromAdminUserGroup([FromBody] AdminUserGroupMembership adminUserGroupMembership)
        {
            ILogicResult createAdminUserGroupResult = this.adminUserGroupsCrudLogic.RemoveAdminUserGroupFromAdminUserGroup(
                adminUserGroupMembership.AdminUserGroupId,
                adminUserGroupMembership.ParentAdminUserGroupId);

            return this.FromLogicResult(createAdminUserGroupResult);
        }
    }
}