using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    public class AdminEmailUserTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("26b584bc-c423-4901-8d0c-96d7c552579b");
        public static readonly Guid IdDbDefault2 = Guid.Parse("bf0a37d4-30da-4d32-a2fe-c4fd01b38563");
        public static readonly Guid IdForCreate = Guid.Parse("12eb65ce-9259-42b8-b32f-62f1339d07d6");

        public static readonly string EmailDbDefault = "xyz@example.org";
        public static readonly string EmailDbDefault2 = "abc@example.org";
        public static readonly string EmailForCreate = "create@example.org";
        public static readonly string EmailForUpdate = "update@example.org";

        public static readonly string PasswordHashDbDefault = "PasswordHashDbDefault";
        public static readonly string PasswordHashDbDefault2 = "PasswordHashDbDefault2";
        public static readonly string PasswordHashForCreate = "PasswordHashForCreate";
        public static readonly string PasswordHashForUpdate = "PasswordHashForUpdate";

        public static readonly string PasswordSaltDbDefault = "PasswordSaltDbDefault";
        public static readonly string PasswordSaltDbDefault2 = "PasswordSaltDbDefault2";
        public static readonly string PasswordSaltForCreate = "PasswordSaltForCreate";
        public static readonly string PasswordSaltForUpdate = "PasswordSaltForUpdate";

        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault = PermissionsTestValues.PermissionsDbDefault;
        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault2 = PermissionsTestValues.PermissionsDbDefault2;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForCreate = PermissionsTestValues.PermissionsForCreate;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdate = PermissionsTestValues.PermissionsForUpdate;
    }
}