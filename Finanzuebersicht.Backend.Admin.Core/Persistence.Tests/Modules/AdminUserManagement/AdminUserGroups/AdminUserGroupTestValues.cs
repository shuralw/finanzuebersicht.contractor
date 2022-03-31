using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    public class AdminUserGroupTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("96d7c552-c423-4901-8d0c-26b584bc579b");
        public static readonly Guid IdDbDefault2 = Guid.Parse("c4fd01b3-30da-4d32-a2fe-bf0a37d48563");
        public static readonly Guid IdDbDefault3 = Guid.Parse("01b3c4fd-30da-4d32-a2fe-bf0a37d48563");
        public static readonly Guid IdForCreate = Guid.Parse("62f1339d-9259-42b8-b32f-12eb65ce07d6");

        public static readonly string NameDbDefault = "XYZ Gruppe";
        public static readonly string NameDbDefault2 = "ABC Gruppe";
        public static readonly string NameDbDefault3 = "EFG Gruppe";
        public static readonly string NameForCreate = "CreateGruppe";
        public static readonly string NameForUpdate = "UpdateGruppe";

        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault = PermissionsTestValues.PermissionsDbDefault;
        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault2 = PermissionsTestValues.PermissionsDbDefault2;
        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault3 = PermissionsTestValues.PermissionsDbDefault2;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForCreate = PermissionsTestValues.PermissionsForCreate;
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdate = PermissionsTestValues.PermissionsForUpdate;
    }
}