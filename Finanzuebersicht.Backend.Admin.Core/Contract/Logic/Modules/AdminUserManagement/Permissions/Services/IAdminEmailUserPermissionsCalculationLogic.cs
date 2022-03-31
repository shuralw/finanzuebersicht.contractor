using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions
{
    public interface IAdminEmailUserPermissionsCalculationLogic
    {
        IDictionary<string, PermissionStatus> CalculatePermissionsForAdminEmailUser(Guid adminEmailUserId);

        IDictionary<string, PermissionStatus> CalculateStrictPermissionsForAdminEmailUser(Guid adminEmailUserId);
    }
}