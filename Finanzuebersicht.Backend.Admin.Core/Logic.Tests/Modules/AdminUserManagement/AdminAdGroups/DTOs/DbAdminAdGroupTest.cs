using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    internal class DbAdminAdGroupTest : IDbAdminAdGroup
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public static IDbAdminAdGroup Default()
        {
            return new DbAdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdDefault,
                Dn = AdminAdGroupTestValues.DnDefault,
                PasswordHash = AdminAdGroupTestValues.PasswordHashDefault,
                PasswordSalt = AdminAdGroupTestValues.PasswordSaltDefault,
                Permissions = AdminAdGroupTestValues.PermissionsDefault,
            };
        }

        public static IDbAdminAdGroup Default2()
        {
            return new DbAdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdDefault2,
                Dn = AdminAdGroupTestValues.DnDefault2,
                PasswordHash = AdminAdGroupTestValues.PasswordHashDefault2,
                PasswordSalt = AdminAdGroupTestValues.PasswordSaltDefault2,
                Permissions = AdminAdGroupTestValues.PermissionsDefault2,
            };
        }

        public static IDbAdminAdGroup ForUpdate()
        {
            return new DbAdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdDefault,
                Dn = AdminAdGroupTestValues.DnForUpdate,
                PasswordHash = AdminAdGroupTestValues.PasswordHashForUpdate,
                PasswordSalt = AdminAdGroupTestValues.PasswordSaltForUpdate,
                Permissions = AdminAdGroupTestValues.PermissionsForUpdate,
            };
        }

        public static IDbPagedResult<IDbAdminAdGroup> ForPaged()
        {
            return new DbPagedResult<IDbAdminAdGroup>()
            {
                Data = new List<IDbAdminAdGroup>()
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

        public static void AssertDefault(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDefault, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsDefault, dbAdminAdGroup.Permissions);
        }

        public static void AssertCreated(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdForCreate, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnForCreate, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsForCreate, dbAdminAdGroup.Permissions);
        }

        public static void AssertUpdated(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnForUpdate, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsForUpdate, dbAdminAdGroup.Permissions);
        }

        public static void AssertUpdatedMail(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnForUpdate, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsDefault, dbAdminAdGroup.Permissions);
        }

        public static void AssertUpdatedPasswordChange(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDefault, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsDefault, dbAdminAdGroup.Permissions);
        }

        public static void AssertUpdatedPermission(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDefault, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsForUpdate, dbAdminAdGroup.Permissions);
        }

        public static void AssertUpdatedPermissionGlobalAdmin(IDbAdminAdGroup dbAdminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, dbAdminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDefault, dbAdminAdGroup.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsForUpdateGlobalAdmin, dbAdminAdGroup.Permissions);
        }
    }
}