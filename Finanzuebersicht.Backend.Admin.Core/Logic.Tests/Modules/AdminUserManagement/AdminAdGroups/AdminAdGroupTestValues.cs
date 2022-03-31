using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    public class AdminAdGroupTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("a4131eb1-ac82-4c01-bd2f-1a0b6c4b1bbe");
        public static readonly Guid IdDefault2 = Guid.Parse("1eb1a413-ac82-4c01-bd2f-1a0b6c4b1bbe");
        public static readonly Guid IdForCreate = Guid.Parse("dd2874c7-fa5e-4831-a57c-7be80b8c3ff7");

        public static readonly string DnDefault = "DC=Xyz";
        public static readonly string DnDefault2 = "DC=Xyz2";
        public static readonly string DnForCreate = "DC=Create";
        public static readonly string DnForUpdate = "DC=Update";

        public static readonly string PasswordDefault = "PasswordDefault";
        public static readonly string PasswordDefault2 = "PasswordDefault2";
        public static readonly string PasswordForCreate = "PasswordForCreate";
        public static readonly string PasswordForUpdate = "PasswordForUpdate";

        public static readonly string PasswordHashDefault = "lLj3sQPf1isP6T1CZWZ9RMN3W9okAdTk4OjooKHO+9BT5tJ55euCLde8ifSl6ru6SuaypWRiE1nkiZPNHDbu4A==";
        public static readonly string PasswordHashDefault2 = "22j3sQPf1isP6T1CZWZ9RMN3W9okAdTk4OjooKHO+9BT5tJ55euCLde8ifSl6ru6SuaypWRiE1nkiZPNHDbu4A==";
        public static readonly string PasswordHashForCreate = "PasswordHashForCreate";
        public static readonly string PasswordHashForUpdate = "PasswordHashForUpdate";

        public static readonly string PasswordSaltDefault = "50000.voYJdI+L2w/atDbVrWlMRUw8MkmXeBO9c35Ms2wQZfYQkw==";
        public static readonly string PasswordSaltDefault2 = "50000.22YJdI+L2w/atDbVrWlMRUw8MkmXeBO9c35Ms2wQZfYQkw==";
        public static readonly string PasswordSaltForCreate = "PasswordSaltForCreate";
        public static readonly string PasswordSaltForUpdate = "PasswordSaltForUpdate";

        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault = PermissionsTestValues.PermissionsDefault;
        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault2 = PermissionsTestValues.PermissionsDefault2;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForCreate = PermissionsTestValues.PermissionsForCreate;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdate = PermissionsTestValues.PermissionsForUpdate;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdateGlobalAdmin = PermissionsTestValues.PermissionsForUpdateGlobalAdmin;

        public static readonly IDictionary<string, PermissionStatus> CalculatedPermissionsDefault = PermissionsTestValues.PermissionsDefault;

        public static readonly IEnumerable<IAdminUserGroup> ParentAdminUserGroups = new IAdminUserGroup[] { AdminUserGroupTest.Default() };
    }
}