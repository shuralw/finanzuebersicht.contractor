using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminUserGroups
{
    [ApiController]
    [Route("api/admin-user-management/admin-user-groups")]
    public class AdminUserGroupsController : ControllerBase
    {
        private readonly IAdminUserGroupsCrudLogic adminUserGroupsCrudLogic;

        public AdminUserGroupsController(IAdminUserGroupsCrudLogic adminUserGroupsCrudLogic)
        {
            this.adminUserGroupsCrudLogic = adminUserGroupsCrudLogic;
        }

        [HttpGet]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [Pagination(FilterFields = new[] { "name" }, SortFields = new[] { "name" })]
        public ActionResult<IPagedResult<IAdminUserGroup>> GetPagedAdminUserGroups()
        {
            ILogicResult<IPagedResult<IAdminUserGroup>> getAdminUserGroupsResult = this.adminUserGroupsCrudLogic.GetPagedAdminUserGroups();
            return this.FromLogicResult(getAdminUserGroupsResult);
        }

        [HttpGet]
        [Route("{adminUserGroupId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<IAdminUserGroupDetail> GetAdminUserGroup(Guid adminUserGroupId)
        {
            var getAdminUserGroupDetailResult = this.adminUserGroupsCrudLogic.GetAdminUserGroupDetail(adminUserGroupId);
            return this.FromLogicResult(getAdminUserGroupDetailResult);
        }

        [HttpPost]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<DataBody<Guid>> CreateAdminUserGroup([FromBody] AdminUserGroupCreate adminUserGroupCreate)
        {
            ILogicResult<Guid> createAdminUserGroupResult = this.adminUserGroupsCrudLogic.CreateAdminUserGroup(adminUserGroupCreate.Name);
            if (!createAdminUserGroupResult.IsSuccessful)
            {
                return this.FromLogicResult(createAdminUserGroupResult);
            }

            return this.Ok(new DataBody<Guid>(createAdminUserGroupResult.Data));
        }

        [HttpPut]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminUserGroup([FromBody] AdminUserGroupUpdate adminUserGroupUpdate)
        {
            ILogicResult createAdminUserGroupResult = this.adminUserGroupsCrudLogic.UpdateAdminUserGroup(adminUserGroupUpdate.Id, adminUserGroupUpdate.Name);
            return this.FromLogicResult(createAdminUserGroupResult);
        }

        [HttpDelete]
        [Route("{adminUserGroupId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult DeleteAdminUserGroup(Guid adminUserGroupId)
        {
            ILogicResult deleteAdminUserGroupResult = this.adminUserGroupsCrudLogic.DeleteAdminUserGroup(adminUserGroupId);
            return this.FromLogicResult(deleteAdminUserGroupResult);
        }

        [HttpPut]
        [Route("{adminUserGroupId}/permissions")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminUserGroupPermissions(Guid adminUserGroupId, [FromBody] ApiPermissions permissionsUpdate)
        {
            ILogicResult createAdminUserGroupResult = this.adminUserGroupsCrudLogic.UpdateAdminUserGroupPermissions(adminUserGroupId, permissionsUpdate.Permissions);
            return this.FromLogicResult(createAdminUserGroupResult);
        }
    }
}