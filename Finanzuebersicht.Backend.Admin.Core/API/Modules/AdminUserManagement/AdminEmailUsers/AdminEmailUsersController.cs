using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminEmailUsers
{
    [ApiController]
    [Route("api/admin-user-management/admin-email-users")]
    public class AdminEmailUsersController : ControllerBase
    {
        private readonly IAdminEmailUsersCrudLogic adminEmailUsersCrudLogic;

        public AdminEmailUsersController(IAdminEmailUsersCrudLogic adminEmailUsersCrudLogic)
        {
            this.adminEmailUsersCrudLogic = adminEmailUsersCrudLogic;
        }

        [HttpGet]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [Pagination(FilterFields = new[] { "email" }, SortFields = new[] { "email" })]
        public ActionResult<IPagedResult<IAdminEmailUser>> GetPagedAdminEmailUsers()
        {
            ILogicResult<IPagedResult<IAdminEmailUser>> getAdminEmailUsersResult = this.adminEmailUsersCrudLogic.GetPagedAdminEmailUsers();
            return this.FromLogicResult(getAdminEmailUsersResult);
        }

        [HttpGet]
        [Route("{adminEmailUserId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<IAdminEmailUserDetail> GetAdminEmailUser(Guid adminEmailUserId)
        {
            var getAdminEmailUserDetailResult = this.adminEmailUsersCrudLogic.GetAdminEmailUserDetail(adminEmailUserId);
            return this.FromLogicResult(getAdminEmailUserDetailResult);
        }

        [HttpPost]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<DataBody<Guid>> CreateAdminEmailUser([FromBody] AdminEmailUserCreate adminEmailUserCreate)
        {
            ILogicResult<Guid> createAdminEmailUserResult = this.adminEmailUsersCrudLogic.CreateAdminEmailUser(adminEmailUserCreate.Email);
            if (!createAdminEmailUserResult.IsSuccessful)
            {
                return this.FromLogicResult(createAdminEmailUserResult);
            }

            return this.Ok(new DataBody<Guid>(createAdminEmailUserResult.Data));
        }

        [HttpPut]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminEmailUser([FromBody] AdminEmailUserUpdate adminEmailUserUpdate)
        {
            ILogicResult updateAdminEmailUserResult = this.adminEmailUsersCrudLogic.UpdateAdminEmailUser(adminEmailUserUpdate.Id, adminEmailUserUpdate.Email);
            return this.FromLogicResult(updateAdminEmailUserResult);
        }

        [HttpDelete]
        [Route("{adminEmailUserId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult DeleteAdminEmailUser(Guid adminEmailUserId)
        {
            ILogicResult deleteAdminEmailUserResult = this.adminEmailUsersCrudLogic.DeleteAdminEmailUser(adminEmailUserId);
            return this.FromLogicResult(deleteAdminEmailUserResult);
        }

        [HttpPut]
        [Route("{adminEmailUserId}/permissions")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminEmailUserPermissions(Guid adminEmailUserId, [FromBody] ApiPermissions permissionsUpdate)
        {
            ILogicResult createAdminUserGroupResult = this.adminEmailUsersCrudLogic.UpdateAdminEmailUserPermissions(adminEmailUserId, permissionsUpdate.Permissions);
            return this.FromLogicResult(createAdminUserGroupResult);
        }
    }
}