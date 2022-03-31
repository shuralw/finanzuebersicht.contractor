using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    internal class DbAdminUserGroupTest : IDbAdminUserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminUserGroup DbDefault()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDbDefault,
                Name = AdminUserGroupTestValues.NameDbDefault,
                Permissions = AdminUserGroupTestValues.PermissionsDbDefault,
            };
        }

        public static IDbAdminUserGroup DbDefault2()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDbDefault2,
                Name = AdminUserGroupTestValues.NameDbDefault2,
                Permissions = AdminUserGroupTestValues.PermissionsDbDefault2,
            };
        }

        public static IDbAdminUserGroup DbDefault3()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDbDefault3,
                Name = AdminUserGroupTestValues.NameDbDefault3,
                Permissions = AdminUserGroupTestValues.PermissionsDbDefault3,
            };
        }

        public static IDbAdminUserGroup ForCreate()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdForCreate,
                Name = AdminUserGroupTestValues.NameForCreate,
                Permissions = AdminUserGroupTestValues.PermissionsForCreate,
            };
        }

        public static IDbAdminUserGroup ForUpdate()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDbDefault,
                Name = AdminUserGroupTestValues.NameForUpdate,
                Permissions = AdminUserGroupTestValues.PermissionsForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDbDefault, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDbDefault, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDbDefault, dbAdminUserGroup.Permissions);
        }

        public static void AssertDbDefault2(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDbDefault2, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDbDefault2, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDbDefault2, dbAdminUserGroup.Permissions);
        }

        public static void AssertDbDefault3(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDbDefault3, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDbDefault3, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDbDefault3, dbAdminUserGroup.Permissions);
        }

        public static void AssertForCreate(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdForCreate, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameForCreate, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsForCreate, dbAdminUserGroup.Permissions);
        }

        public static void AssertForUpdate(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDbDefault, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameForUpdate, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsForUpdate, dbAdminUserGroup.Permissions);
        }
    }
}