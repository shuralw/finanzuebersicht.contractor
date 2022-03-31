using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    internal class DbAdminAdUserTest : IDbAdminAdUser
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminAdUser Default()
        {
            return new DbAdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdDefault,
                Dn = AdminAdUserTestValues.DnDefault,
                PasswordHash = AdminAdUserTestValues.PasswordHashDefault,
                PasswordSalt = AdminAdUserTestValues.PasswordSaltDefault,
                Permissions = AdminAdUserTestValues.PermissionsDefault,
            };
        }

        public static IDbAdminAdUser Default2()
        {
            return new DbAdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdDefault2,
                Dn = AdminAdUserTestValues.DnDefault2,
                PasswordHash = AdminAdUserTestValues.PasswordHashDefault2,
                PasswordSalt = AdminAdUserTestValues.PasswordSaltDefault2,
                Permissions = AdminAdUserTestValues.PermissionsDefault2,
            };
        }

        public static IDbAdminAdUser ForUpdate()
        {
            return new DbAdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdDefault,
                Dn = AdminAdUserTestValues.DnForUpdate,
                PasswordHash = AdminAdUserTestValues.PasswordHashForUpdate,
                PasswordSalt = AdminAdUserTestValues.PasswordSaltForUpdate,
                Permissions = AdminAdUserTestValues.PermissionsForUpdate,
            };
        }

        public static IDbPagedResult<IDbAdminAdUser> ForPaged()
        {
            return new DbPagedResult<IDbAdminAdUser>()
            {
                Data = new List<IDbAdminAdUser>()
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

        public static void AssertDefault(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDefault, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsDefault, dbAdminAdUser.Permissions);
        }

        public static void AssertCreated(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdForCreate, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnForCreate, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsForCreate, dbAdminAdUser.Permissions);
        }

        public static void AssertUpdated(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnForUpdate, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsForUpdate, dbAdminAdUser.Permissions);
        }

        public static void AssertUpdatedMail(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnForUpdate, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsDefault, dbAdminAdUser.Permissions);
        }

        public static void AssertUpdatedPasswordChange(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDefault, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsDefault, dbAdminAdUser.Permissions);
        }

        public static void AssertUpdatedPermission(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDefault, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsForUpdate, dbAdminAdUser.Permissions);
        }

        public static void AssertUpdatedPermissionGlobalAdmin(IDbAdminAdUser dbAdminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, dbAdminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDefault, dbAdminAdUser.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsForUpdateGlobalAdmin, dbAdminAdUser.Permissions);
        }
    }
}