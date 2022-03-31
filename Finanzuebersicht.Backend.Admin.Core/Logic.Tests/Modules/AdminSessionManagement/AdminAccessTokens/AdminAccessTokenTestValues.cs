using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    public class AdminAccessTokenTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("78e813fa-892d-43ff-95fe-b86d727a0a06");
        public static readonly Guid IdForCreate = Guid.Parse("21082130-a13b-4a15-8f36-bf94e281a421");

        public static readonly Guid AdminRefreshTokenIdDefault = AdminRefreshTokenTestValues.IdDefault;
        public static readonly Guid AdminRefreshTokenIdForCreate = AdminRefreshTokenTestValues.IdForCreate;

        public static readonly string UsernameDefault = "UsernameDefault";
        public static readonly string UsernameForCreate = "UsernameForCreate";

        public static readonly DateTime ExpiresOnDefault = new DateTime(2019, 5, 25);
        public static readonly DateTime ExpiresOnForCreate = new DateTime(2018, 1, 9, 12, 0, 0);

        public static readonly DateTime ExpirationNow = new DateTime(2018, 1, 9);

        public static readonly Guid AdminEmailUserIdDefault = AdminEmailUserTestValues.IdDefault;
        public static readonly Guid AdminEmailUserIdForCreate = AdminEmailUserTestValues.IdForCreate;

        public static readonly Guid AdminAdUserIdDefault = AdminAdUserTestValues.IdDefault;
        public static readonly Guid AdminAdUserIdForCreate = AdminAdUserTestValues.IdForCreate;

        public static readonly IEnumerable<Guid> AdminAdGroupIdsDefault = new Guid[] { AdminAdGroupTestValues.IdDefault };
        public static readonly IEnumerable<Guid> AdminAdGroupIdsForCreate = new Guid[] { AdminAdGroupTestValues.IdForCreate };

        public static readonly IDictionary<string, PermissionStatus> CachedPermissionsDefault = PermissionsTestValues.PermissionsDefault;
        public static readonly IDictionary<string, PermissionStatus> CachedPermissionsForCreate = PermissionsTestValues.PermissionsForCreate;
    }
}