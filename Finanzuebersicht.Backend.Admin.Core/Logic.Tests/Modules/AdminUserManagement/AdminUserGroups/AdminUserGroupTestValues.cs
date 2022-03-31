using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    public class AdminUserGroupTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("b5b59b13-e6f8-4be1-bac8-7d0b684765a4");
        public static readonly Guid IdDefault2 = Guid.Parse("e6f89b13-b5b5-4be1-bac8-7d0b684765a4");
        public static readonly Guid IdDefault3 = Guid.Parse("4be19b13-b5b5-4be1-bac8-7d0b684765a4");
        public static readonly Guid IdForCreate = Guid.Parse("8c7e723d-7556-4af9-a78d-cdf47dd40153");
        public static readonly Guid IdForUpdate = Guid.Parse("61d244b2-3a5b-4ba4-9d0d-4744bdb6d2a4");

        public static readonly string NameDefault = "NameDefault";
        public static readonly string NameDefault2 = "NameDefault2";
        public static readonly string NameDefault3 = "NameDefault3";
        public static readonly string NameForCreate = "NameForCreate";
        public static readonly string NameForUpdate = "NameForUpdate";

        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault = PermissionsTestValues.PermissionsDefault;
        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault2 = PermissionsTestValues.PermissionsDefault2;
        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault3 = PermissionsTestValues.PermissionsDefault3;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForCreate = PermissionsTestValues.PermissionsForCreate;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdate = PermissionsTestValues.PermissionsForUpdate;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdateGlobalAdmin = PermissionsTestValues.PermissionsForUpdateGlobalAdmin;

        public static readonly IDictionary<string, PermissionStatus> CalculatedPermissionsDefault = PermissionsTestValues.PermissionsDefault;

        public static readonly IEnumerable<IAdminUserGroup> ParentAdminUserGroups = new IAdminUserGroup[] { AdminUserGroupTest.Default2() };
    }
}