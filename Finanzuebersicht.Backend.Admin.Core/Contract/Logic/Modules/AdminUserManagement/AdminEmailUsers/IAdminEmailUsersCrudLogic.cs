using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IAdminEmailUsersCrudLogic
    {
        ILogicResult AddAdminEmailUserToAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId);

        ILogicResult<Guid> CreateAdminEmailUser(string email);

        ILogicResult UpdateAdminEmailUser(Guid adminEmailUserId, string email);

        ILogicResult DeleteAdminEmailUser(Guid adminEmailUserId);

        ILogicResult<IAdminEmailUserDetail> GetAdminEmailUserDetail(Guid adminEmailUserId);

        ILogicResult<IPagedResult<IAdminEmailUser>> GetPagedAdminEmailUsers();

        ILogicResult RemoveAdminEmailUserFromAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId);

        ILogicResult UpdateAdminEmailUserPermissions(Guid adminEmailUserId, IDictionary<string, PermissionStatus> permissionsUpdate);
    }
}