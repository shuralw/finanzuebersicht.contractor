using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    public class AdminAdUserTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("84bc26b5-c423-4901-8d0c-96d7c552579b");
        public static readonly Guid IdDbDefault2 = Guid.Parse("37d4bf0a-30da-4d32-a2fe-c4fd01b38563");
        public static readonly Guid IdForCreate = Guid.Parse("65ce12eb-9259-42b8-b32f-62f1339d07d6");

        public static readonly string DnDbDefault = "DC=Xyz";
        public static readonly string DnDbDefault2 = "DC=Abc";
        public static readonly string DnForCreate = "DC=Create";
        public static readonly string DnForUpdate = "DC=Update";

        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault = PermissionsTestValues.PermissionsDbDefault;
        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault2 = PermissionsTestValues.PermissionsDbDefault2;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForCreate = PermissionsTestValues.PermissionsForCreate;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdate = PermissionsTestValues.PermissionsForUpdate;
    }
}