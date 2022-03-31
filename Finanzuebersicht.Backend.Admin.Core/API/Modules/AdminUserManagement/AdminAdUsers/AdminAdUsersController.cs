using Microsoft.AspNetCore.Mvc;
using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminAdUsers
{
    [ApiController]
    [Route("api/admin-user-management/admin-ad-users")]
    public class AdminAdUsersController : ControllerBase
    {
        private readonly IAdminAdUsersCrudLogic adminAdUsersCrudLogic;

        public AdminAdUsersController(IAdminAdUsersCrudLogic adminAdUsersCrudLogic)
        {
            this.adminAdUsersCrudLogic = adminAdUsersCrudLogic;
        }

        [HttpGet]
        [Authorized(PermissionName.Benutzerverwaltung)]
        [Pagination(FilterFields = new[] { "dn" }, SortFields = new[] { "dn" })]
        public ActionResult<IPagedResult<IAdminAdUser>> GetPagedAdminAdUsers()
        {
            ILogicResult<IPagedResult<IAdminAdUser>> getAdminAdUsersResult = this.adminAdUsersCrudLogic.GetPagedAdminAdUsers();
            return this.FromLogicResult(getAdminAdUsersResult);
        }

        [HttpGet]
        [Route("{adminAdUserId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<IAdminAdUserDetail> GetAdminAdUser(Guid adminAdUserId)
        {
            var getAdminAdUserDetailResult = this.adminAdUsersCrudLogic.GetAdminAdUserDetail(adminAdUserId);
            return this.FromLogicResult(getAdminAdUserDetailResult);
        }

        [HttpPost]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult<DataBody<Guid>> CreateAdminAdUser([FromBody] AdminAdUserCreate adminAdUserCreate)
        {
            ILogicResult<Guid> createAdminAdUserResult = this.adminAdUsersCrudLogic.CreateAdminAdUser(adminAdUserCreate.Dn);
            if (!createAdminAdUserResult.IsSuccessful)
            {
                return this.FromLogicResult(createAdminAdUserResult);
            }

            return this.Ok(new DataBody<Guid>(createAdminAdUserResult.Data));
        }

        [HttpPut]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminAdUser([FromBody] AdminAdUserUpdate adminAdUserUpdate)
        {
            ILogicResult createAdminAdUserResult = this.adminAdUsersCrudLogic.UpdateAdminAdUser(adminAdUserUpdate.Id, adminAdUserUpdate.Dn);
            return this.FromLogicResult(createAdminAdUserResult);
        }

        [HttpDelete]
        [Route("{adminAdUserId}")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult DeleteAdminAdUser(Guid adminAdUserId)
        {
            ILogicResult deleteAdminAdUserResult = this.adminAdUsersCrudLogic.DeleteAdminAdUser(adminAdUserId);
            return this.FromLogicResult(deleteAdminAdUserResult);
        }

        [HttpPut]
        [Route("{adminAdUserId}/permissions")]
        [Authorized(PermissionName.Benutzerverwaltung)]
        public ActionResult UpdateAdminAdUserPermissions(Guid adminAdUserId, [FromBody] ApiPermissions permissionsUpdate)
        {
            ILogicResult createAdminUserGroupResult = this.adminAdUsersCrudLogic.UpdateAdminAdUserPermissions(adminAdUserId, permissionsUpdate.Permissions);
            return this.FromLogicResult(createAdminUserGroupResult);
        }
    }
}