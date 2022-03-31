using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class DbAdminEmailUserTest : IDbAdminEmailUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminEmailUser Default()
        {
            return new DbAdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdDefault,
                Email = AdminEmailUserTestValues.EmailDefault,
                PasswordHash = AdminEmailUserTestValues.PasswordHashDefault,
                PasswordSalt = AdminEmailUserTestValues.PasswordSaltDefault,
                Permissions = AdminEmailUserTestValues.PermissionsDefault,
            };
        }

        public static IDbAdminEmailUser Default2()
        {
            return new DbAdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdDefault2,
                Email = AdminEmailUserTestValues.EmailDefault2,
                PasswordHash = AdminEmailUserTestValues.PasswordHashDefault2,
                PasswordSalt = AdminEmailUserTestValues.PasswordSaltDefault2,
                Permissions = AdminEmailUserTestValues.PermissionsDefault2,
            };
        }

        public static IDbAdminEmailUser ForUpdate()
        {
            return new DbAdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdDefault,
                Email = AdminEmailUserTestValues.EmailForUpdate,
                PasswordHash = AdminEmailUserTestValues.PasswordHashForUpdate,
                PasswordSalt = AdminEmailUserTestValues.PasswordSaltForUpdate,
                Permissions = AdminEmailUserTestValues.PermissionsForUpdate,
            };
        }

        public static IDbPagedResult<IDbAdminEmailUser> ForPaged()
        {
            return new DbPagedResult<IDbAdminEmailUser>()
            {
                Data = new List<IDbAdminEmailUser>()
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

        public static void AssertDefault(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDefault, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashDefault, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltDefault, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsDefault, dbAdminEmailUser.Permissions);
        }

        public static void AssertCreated(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdForCreate, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailForCreate, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashForCreate, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltForCreate, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsForCreate, dbAdminEmailUser.Permissions);
        }

        public static void AssertUpdated(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailForUpdate, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashForUpdate, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltForUpdate, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsForUpdate, dbAdminEmailUser.Permissions);
        }

        public static void AssertUpdatedMail(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailForUpdate, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashDefault, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltDefault, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsDefault, dbAdminEmailUser.Permissions);
        }

        public static void AssertUpdatedPasswordChange(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDefault, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashForUpdate, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltForUpdate, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsDefault, dbAdminEmailUser.Permissions);
        }

        public static void AssertUpdatedPermission(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDefault, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashDefault, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltDefault, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsForUpdate, dbAdminEmailUser.Permissions);
        }

        public static void AssertUpdatedPermissionGlobalAdmin(IDbAdminEmailUser dbAdminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, dbAdminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDefault, dbAdminEmailUser.Email);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordHashDefault, dbAdminEmailUser.PasswordHash);
            Assert.AreEqual(AdminEmailUserTestValues.PasswordSaltDefault, dbAdminEmailUser.PasswordSalt);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsForUpdateGlobalAdmin, dbAdminEmailUser.Permissions);
        }
    }
}