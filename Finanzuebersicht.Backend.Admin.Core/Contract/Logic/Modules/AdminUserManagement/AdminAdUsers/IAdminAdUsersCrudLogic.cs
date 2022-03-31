using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers
{
    public interface IAdminAdUsersCrudLogic
    {
        ILogicResult AddAdminAdUserToAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId);

        ILogicResult<Guid> CreateAdminAdUser(string dn);

        ILogicResult DeleteAdminAdUser(Guid adminAdUserId);

        ILogicResult<IPagedResult<IAdminAdUser>> GetPagedAdminAdUsers();

        ILogicResult<IAdminAdUserDetail> GetAdminAdUserDetail(Guid adminAdUserId);

        ILogicResult RemoveAdminAdUserFromAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId);

        ILogicResult UpdateAdminAdUser(Guid adminAdUserId, string dn);

        ILogicResult UpdateAdminAdUserPermissions(Guid adminAdUserId, IDictionary<string, PermissionStatus> permissionsUpdate);
    }
}