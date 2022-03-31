using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions
{
    public interface IAdPermissionsCalculationLogic
    {
        IDictionary<string, PermissionStatus> CalculatePermissionsForAd(Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds);

        IDictionary<string, PermissionStatus> CalculateStrictPermissionsForAd(Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds);
    }
}