using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    internal class DbAdminAdUserTest : IDbAdminAdUser
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminAdUser DbDefault()
        {
            return new DbAdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdDbDefault,
                Dn = AdminAdUserTestValues.DnDbDefault,
                Permissions = AdminAdUserTestValues.PermissionsDbDefault,
            };
        }

        public static IDbAdminAdUser DbDefault2()
        {
            return new DbAdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdDbDefault2,
                Dn = AdminAdUserTestValues.DnDbDefault2,
                Permissions = AdminAdUserTestValues.PermissionsDbDefault2,
            };
        }

        public static IDbAdminAdUser ForCreate()
        {
            return new DbAdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdForCreate,
                Dn = AdminAdUserTestValues.DnForCreate,
                Permissions = AdminAdUserTestValues.PermissionsForCreate,
            };
        }

        public static IDbAdminAdUser ForUpdate()
        {
            return new DbAdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdDbDefault,
                Dn = AdminAdUserTestValues.DnForUpdate,
                Permissions = AdminAdUserTestValues.PermissionsForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDbDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDbDefault, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsDbDefault, dbAdminAdUser.Permissions);
        }

        public static void AssertDbDefault2(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDbDefault2, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDbDefault2, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsDbDefault2, dbAdminAdUser.Permissions);
        }

        public static void AssertForCreate(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdForCreate, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnForCreate, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsForCreate, dbAdminAdUser.Permissions);
        }

        public static void AssertForUpdate(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDbDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnForUpdate, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsForUpdate, dbAdminAdUser.Permissions);
        }
    }
}