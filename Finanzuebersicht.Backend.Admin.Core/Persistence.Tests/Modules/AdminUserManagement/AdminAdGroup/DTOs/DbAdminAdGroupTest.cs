using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    internal class DbAdminAdGroupTest : IDbAdminAdGroup
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminAdGroup DbDefault()
        {
            return new DbAdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdDbDefault,
                Dn = AdminAdGroupTestValues.DnDbDefault,
                Permissions = AdminAdGroupTestValues.PermissionsDbDefault,
            };
        }

        public static IDbAdminAdGroup DbDefault2()
        {
            return new DbAdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdDbDefault2,
                Dn = AdminAdGroupTestValues.DnDbDefault2,
                Permissions = AdminAdGroupTestValues.PermissionsDbDefault2,
            };
        }

        public static IDbAdminAdGroup ForCreate()
        {
            return new DbAdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdForCreate,
                Dn = AdminAdGroupTestValues.DnForCreate,
                Permissions = AdminAdGroupTestValues.PermissionsForCreate,
            };
        }

        public static IDbAdminAdGroup ForUpdate()
        {
            return new DbAdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdDbDefault,
                Dn = AdminAdGroupTestValues.DnForUpdate,
                Permissions = AdminAdGroupTestValues.PermissionsForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDbDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDbDefault, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsDbDefault, dbAdminAdGroup.Permissions);
        }

        public static void AssertDbDefault2(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDbDefault2, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDbDefault2, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsDbDefault2, dbAdminAdGroup.Permissions);
        }

        public static void AssertForCreate(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdForCreate, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnForCreate, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsForCreate, dbAdminAdGroup.Permissions);
        }

        public static void AssertForUpdate(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDbDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnForUpdate, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsForUpdate, dbAdminAdGroup.Permissions);
        }
    }
}