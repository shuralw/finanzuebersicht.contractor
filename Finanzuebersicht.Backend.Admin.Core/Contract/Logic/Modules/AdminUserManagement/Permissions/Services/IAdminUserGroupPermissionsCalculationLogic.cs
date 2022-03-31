using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions
{
    public interface IAdminUserGroupPermissionsCalculationLogic
    {
        IDictionary<string, PermissionStatus> CalculatePermissionsForAdminUserGroups(IEnumerable<IDbAdminUserGroup> adminUserGroups);
    }
}