using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    public class AdminAccessTokenTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("c0626325-92e0-4a95-b2e3-2ca4fd4a23f9");
        public static readonly Guid IdDbDefault2 = Guid.Parse("b021b3fc-f204-4c82-aba0-09192bbd6265");
        public static readonly Guid IdForCreate = Guid.Parse("40be556a-9b2a-4879-8b4b-124609ab1e66");
        public static readonly Guid IdForUpdate = Guid.Parse("13370686-e566-4d13-ac51-ab6ca6acee50");

        public static readonly string UsernameDbDefault = "UsernameDbDefault";
        public static readonly string UsernameDbDefault2 = "UsernameDbDefault2";
        public static readonly string UsernameForCreate = "UsernameForCreate";
        public static readonly string UsernameForUpdate = "UsernameForUpdate";

        public static readonly DateTime ExpiresOnDbDefault = new DateTime(2018, 3, 4);
        public static readonly DateTime ExpiresOnDbDefault2 = new DateTime(2014, 12, 10);
        public static readonly DateTime ExpiresOnForCreate = new DateTime(2020, 2, 19);
        public static readonly DateTime ExpiresOnForUpdate = new DateTime(2021, 8, 17);
        public static readonly DateTime ExpiresCheck = new DateTime(2016, 8, 17);

        public static readonly Guid AdminRefreshTokenIdDbDefault = AdminRefreshTokenTestValues.IdDbDefault;
        public static readonly Guid AdminRefreshTokenIdDbDefault2 = AdminRefreshTokenTestValues.IdDbDefault2;
        public static readonly Guid AdminRefreshTokenIdForCreate = AdminRefreshTokenTestValues.IdForCreate;
        public static readonly Guid AdminRefreshTokenIdForUpdate = AdminRefreshTokenTestValues.IdForUpdate;

        public static readonly Guid AdminEmailUserIdDbDefault = AdminEmailUserTestValues.IdDbDefault;
        public static readonly Guid AdminEmailUserIdDbDefault2 = AdminEmailUserTestValues.IdDbDefault2;
        public static readonly Guid AdminEmailUserIdForCreate = AdminEmailUserTestValues.IdForCreate;
        public static readonly Guid AdminEmailUserIdForUpdate = AdminEmailUserTestValues.IdDbDefault;

        public static readonly Guid AdminAdUserIdDbDefault = AdminAdUserTestValues.IdDbDefault;
        public static readonly Guid AdminAdUserIdDbDefault2 = AdminAdUserTestValues.IdDbDefault2;
        public static readonly Guid AdminAdUserIdForCreate = AdminAdUserTestValues.IdForCreate;
        public static readonly Guid AdminAdUserIdForUpdate = AdminAdUserTestValues.IdDbDefault;

        public static readonly IEnumerable<Guid> AdminAdGroupIdsDbDefault = new Guid[] { AdminAdGroupTestValues.IdDbDefault };
        public static readonly IEnumerable<Guid> AdminAdGroupIdsDbDefault2 = new Guid[] { AdminAdGroupTestValues.IdDbDefault2 };
        public static readonly IEnumerable<Guid> AdminAdGroupIdsForCreate = new Guid[] { AdminAdGroupTestValues.IdForCreate };
        public static readonly IEnumerable<Guid> AdminAdGroupIdsForUpdate = new Guid[] { AdminAdGroupTestValues.IdDbDefault };

        public static readonly IDictionary<string, PermissionStatus> CachedPermissionsDbDefault = PermissionsTestValues.PermissionsDbDefault;
        public static readonly IDictionary<string, PermissionStatus> CachedPermissionsDbDefault2 = PermissionsTestValues.PermissionsDbDefault2;
        public static readonly IDictionary<string, PermissionStatus> CachedPermissionsForCreate = PermissionsTestValues.PermissionsForCreate;
        public static readonly IDictionary<string, PermissionStatus> CachedPermissionsForUpdate = PermissionsTestValues.PermissionsForUpdate;
    }
}