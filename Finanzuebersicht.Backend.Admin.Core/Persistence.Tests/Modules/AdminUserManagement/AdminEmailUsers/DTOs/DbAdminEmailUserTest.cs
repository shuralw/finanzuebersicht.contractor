using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class DbAdminEmailUserTest : IDbAdminEmailUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminEmailUser DbDefault()
        {
            return new DbAdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdDbDefault,
                Email = AdminEmailUserTestValues.EmailDbDefault,
                PasswordHash = AdminEmailUserTestValues.PasswordHashDbDefault,
                PasswordSalt = AdminEmailUserTestValues.PasswordSaltDbDefault,
                Permissions = AdminEmailUserTestValues.PermissionsDbDefault,
            };
        }

        public static IDbAdminEmailUser DbDefault2()
        {
            return new DbAdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdDbDefault2,
                Email = AdminEmailUserTestValues.EmailDbDefault2,
                PasswordHash = AdminEmailUserTestValues.PasswordHashDbDefault2,
                PasswordSalt = AdminEmailUserTestValues.PasswordSaltDbDefault2,
                Permissions = AdminEmailUserTestValues.PermissionsDbDefault2,
            };
        }

        public static IDbAdminEmailUser ForCreate()
        {
            return new DbAdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdForCreate,
                Email = AdminEmailUserTestValues.EmailForCreate,
                PasswordHash = AdminEmailUserTestValues.PasswordHashForCreate,
                PasswordSalt = AdminEmailUserTestValues.PasswordSaltForCreate,
                Permissions = AdminEmailUserTestValues.PermissionsForCreate,
            };
        }

        public static IDbAdminEmailUser ForUpdate()
        {
            return new DbAdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdDbDefault,
                Email = AdminEmailUserTestValues.EmailForUpdate,
                PasswordHash = AdminEmailUserTestValues.PasswordHashForUpdate,
                PasswordSalt = AdminEmailUserTestValues.PasswordSaltForUpdate,
                Permissions = AdminEmailUserTestValues.PermissionsForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDbDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDbDefault, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashDbDefault, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltDbDefault, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsDbDefault, dbAdminEmailUser.Permissions);
        }

        public static void AssertDbDefault2(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDbDefault2, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDbDefault2, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashDbDefault2, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltDbDefault2, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsDbDefault2, dbAdminEmailUser.Permissions);
        }

        public static void AssertForCreate(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdForCreate, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailForCreate, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashForCreate, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltForCreate, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsForCreate, dbAdminEmailUser.Permissions);
        }

        public static void AssertForUpdate(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDbDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailForUpdate, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashForUpdate, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltForUpdate, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsForUpdate, dbAdminEmailUser.Permissions);
        }
    }
}