using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminAdGroups
{
    [ApiController]
    [Route("api/admin-user-management/admin-ad-groups")]
    public class AdminAdGroupsController : ControllerBase
    {
        private readonly IAdminAdGroupsCrudLogic adminAdGroupsCrudLogic;

        public AdminAdGroupsController(IAdminAdGroupsCrudLogic adminAdGroupsCrudLogic)
        {
            this.adminAdGroupsCrudLogic = adminAdGroupsCrudLogic;
        }

        [HttpGet]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [Pagination(FilterFields = new[] { "dn" }, SortFields = new[] { "dn" })]
        public ActionResult<IPagedResult<IAdminAdGroup>> GetPagedAdminAdGroups()
        {
            ILogicResult<IPagedResult<IAdminAdGroup>> getAdminAdGroupsResult = this.adminAdGroupsCrudLogic.GetPagedAdminAdGroups();
            return this.FromLogicResult(getAdminAdGroupsResult);
        }

        [HttpGet]
        [Route("{adminAdGroupId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<IAdminAdGroupDetail> GetAdminAdGroup(Guid adminAdGroupId)
        {
            var getAdminAdGroupDetailResult = this.adminAdGroupsCrudLogic.GetAdminAdGroupDetail(adminAdGroupId);
            return this.FromLogicResult(getAdminAdGroupDetailResult);
        }

        [HttpPost]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<DataBody<Guid>> CreateAdminAdGroup([FromBody] AdminAdGroupCreate adminAdGroupCreate)
        {
            ILogicResult<Guid> createAdminAdGroupResult = this.adminAdGroupsCrudLogic.CreateAdminAdGroup(adminAdGroupCreate.Dn);
            if (!createAdminAdGroupResult.IsSuccessful)
            {
                return this.FromLogicResult(createAdminAdGroupResult);
            }

            return this.Ok(new DataBody<Guid>(createAdminAdGroupResult.Data));
        }

        [HttpPut]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminAdGroup([FromBody] AdminAdGroupUpdate adminAdGroupUpdate)
        {
            ILogicResult createAdminAdGroupResult = this.adminAdGroupsCrudLogic.UpdateAdminAdGroup(adminAdGroupUpdate.Id, adminAdGroupUpdate.Dn);
            return this.FromLogicResult(createAdminAdGroupResult);
        }

        [HttpDelete]
        [Route("{adminAdGroupId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult DeleteAdminAdGroup(Guid adminAdGroupId)
        {
            ILogicResult deleteAdminAdGroupResult = this.adminAdGroupsCrudLogic.DeleteAdminAdGroup(adminAdGroupId);
            return this.FromLogicResult(deleteAdminAdGroupResult);
        }

        [HttpPut]
        [Route("{adminAdGroupId}/permissions")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminAdGroupPermissions(Guid adminAdGroupId, [FromBody] ApiPermissions permissionsUpdate)
        {
            ILogicResult createAdminUserGroupResult = this.adminAdGroupsCrudLogic.UpdateAdminAdGroupPermissions(adminAdGroupId, permissionsUpdate.Permissions);
            return this.FromLogicResult(createAdminUserGroupResult);
        }
    }
}