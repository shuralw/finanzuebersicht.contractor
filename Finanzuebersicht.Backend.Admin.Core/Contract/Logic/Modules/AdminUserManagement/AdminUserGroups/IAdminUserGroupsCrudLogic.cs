using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups
{
    public interface IAdminUserGroupsCrudLogic
    {
        ILogicResult AddAdminUserGroupToAdminUserGroup(Guid adminUserGroupId, Guid parentId);

        ILogicResult<Guid> CreateAdminUserGroup(string name);

        ILogicResult DeleteAdminUserGroup(Guid adminUserGroupId);

        ILogicResult<IPagedResult<IAdminUserGroup>> GetPagedAdminUserGroups();

        ILogicResult<IAdminUserGroupDetail> GetAdminUserGroupDetail(Guid adminUserGroupId);

        ILogicResult RemoveAdminUserGroupFromAdminUserGroup(Guid adminUserGroupId, Guid parentId);

        ILogicResult UpdateAdminUserGroup(Guid adminUserGroupId, string name);

        ILogicResult UpdateAdminUserGroupPermissions(Guid adminUserGroupId, IDictionary<string, PermissionStatus> permissionsUpdate);
    }
}