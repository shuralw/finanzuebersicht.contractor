using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups
{
    public interface IAdminAdGroupsCrudLogic
    {
        ILogicResult AddAdminAdGroupToAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId);

        ILogicResult<Guid> CreateAdminAdGroup(string dn);

        ILogicResult DeleteAdminAdGroup(Guid adminAdGroupId);

        ILogicResult<IPagedResult<IAdminAdGroup>> GetPagedAdminAdGroups();

        ILogicResult<IAdminAdGroupDetail> GetAdminAdGroupDetail(Guid adminAdGroupId);

        ILogicResult RemoveAdminAdGroupFromAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId);

        ILogicResult UpdateAdminAdGroup(Guid adminAdGroupId, string dn);

        ILogicResult UpdateAdminAdGroupPermissions(Guid adminAdGroupId, IDictionary<string, PermissionStatus> permissionsUpdate);
    }
}