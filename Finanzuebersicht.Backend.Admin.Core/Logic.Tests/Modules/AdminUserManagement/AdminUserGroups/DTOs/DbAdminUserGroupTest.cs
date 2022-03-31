using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    internal class DbAdminUserGroupTest : IDbAdminUserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminUserGroup Default()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDefault,
                Name = AdminUserGroupTestValues.NameDefault,
                Permissions = AdminUserGroupTestValues.PermissionsDefault,
            };
        }

        public static IDbAdminUserGroup Default2()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDefault2,
                Name = AdminUserGroupTestValues.NameDefault2,
                Permissions = AdminUserGroupTestValues.PermissionsDefault2,
            };
        }

        public static IDbAdminUserGroup Default3()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDefault3,
                Name = AdminUserGroupTestValues.NameDefault3,
                Permissions = AdminUserGroupTestValues.PermissionsDefault3,
            };
        }

        public static IDbAdminUserGroup ForUpdate()
        {
            return new DbAdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDefault,
                Name = AdminUserGroupTestValues.NameForUpdate,
                Permissions = AdminUserGroupTestValues.PermissionsForUpdate,
            };
        }

        public static IDbPagedResult<IDbAdminUserGroup> ForPaged()
        {
            return new DbPagedResult<IDbAdminUserGroup>()
            {
                Data = new List<IDbAdminUserGroup>()
                {
                    Default(),
                    Default2()
                },
                TotalCount = 2,
                Count = 2,
                Limit = 10,
                Offset = 0
            };
        }

        public static void AssertDefault(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDefault, dbAdminUserGroup.Permissions);
        }

        public static void AssertDefault2(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault2, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault2, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDefault2, dbAdminUserGroup.Permissions);
        }

        public static void AssertDefault3(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault3, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault3, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDefault3, dbAdminUserGroup.Permissions);
        }

        public static void AssertCreated(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdForCreate, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameForCreate, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsForCreate, dbAdminUserGroup.Permissions);
        }

        public static void AssertUpdated(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameForUpdate, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsForUpdate, dbAdminUserGroup.Permissions);
        }

        public static void AssertUpdatedName(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameForUpdate, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDefault, dbAdminUserGroup.Permissions);
        }

        public static void AssertUpdatedPermission(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsForUpdate, dbAdminUserGroup.Permissions);
        }

        public static void AssertUpdatedPermissionGlobalAdmin(IDbAdminUserGroup dbAdminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault, dbAdminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault, dbAdminUserGroup.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsForUpdateGlobalAdmin, dbAdminUserGroup.Permissions);
        }
    }
}