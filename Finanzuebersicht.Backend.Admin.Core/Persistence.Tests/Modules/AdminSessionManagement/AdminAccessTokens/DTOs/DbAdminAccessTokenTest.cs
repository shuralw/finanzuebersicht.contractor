using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class DbAdminAccessTokenTest : IDbAdminAccessToken
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        public static IDbAdminAccessToken DbDefault()
        {
            return new DbAdminAccessTokenTest()
            {
                Id = AdminAccessTokenTestValues.IdDbDefault,
                AdminEmailUserId = AdminAccessTokenTestValues.AdminEmailUserIdDbDefault,
                AdminAdUserId = AdminAccessTokenTestValues.AdminAdUserIdDbDefault,
                AdminAdGroupIds = AdminAccessTokenTestValues.AdminAdGroupIdsDbDefault,
                Username = AdminAccessTokenTestValues.UsernameDbDefault,
                ExpiresOn = AdminAccessTokenTestValues.ExpiresOnDbDefault,
                AdminRefreshTokenId = AdminAccessTokenTestValues.AdminRefreshTokenIdDbDefault,
                CachedPermissions = AdminAccessTokenTestValues.CachedPermissionsDbDefault,
            };
        }

        public static IDbAdminAccessToken DbDefault2()
        {
            return new DbAdminAccessTokenTest()
            {
                Id = AdminAccessTokenTestValues.IdDbDefault2,
                AdminEmailUserId = AdminAccessTokenTestValues.AdminEmailUserIdDbDefault2,
                AdminAdUserId = AdminAccessTokenTestValues.AdminAdUserIdDbDefault2,
                AdminAdGroupIds = AdminAccessTokenTestValues.AdminAdGroupIdsDbDefault2,
                Username = AdminAccessTokenTestValues.UsernameDbDefault2,
                ExpiresOn = AdminAccessTokenTestValues.ExpiresOnDbDefault2,
                AdminRefreshTokenId = AdminAccessTokenTestValues.AdminRefreshTokenIdDbDefault2,
                CachedPermissions = AdminAccessTokenTestValues.CachedPermissionsDbDefault2,
            };
        }

        public static IDbAdminAccessToken ForCreate()
        {
            return new DbAdminAccessTokenTest()
            {
                Id = AdminAccessTokenTestValues.IdForCreate,
                AdminEmailUserId = AdminAccessTokenTestValues.AdminEmailUserIdForCreate,
                AdminAdUserId = AdminAccessTokenTestValues.AdminAdUserIdForCreate,
                AdminAdGroupIds = AdminAccessTokenTestValues.AdminAdGroupIdsForCreate,
                Username = AdminAccessTokenTestValues.UsernameForCreate,
                ExpiresOn = AdminAccessTokenTestValues.ExpiresOnForCreate,
                AdminRefreshTokenId = AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate,
                CachedPermissions = AdminAccessTokenTestValues.CachedPermissionsForCreate,
            };
        }

        public static IDbAdminAccessToken ForUpdate()
        {
            return new DbAdminAccessTokenTest()
            {
                Id = AdminAccessTokenTestValues.IdForUpdate,
                AdminEmailUserId = AdminAccessTokenTestValues.AdminEmailUserIdForUpdate,
                AdminAdUserId = AdminAccessTokenTestValues.AdminAdUserIdForUpdate,
                AdminAdGroupIds = AdminAccessTokenTestValues.AdminAdGroupIdsForUpdate,
                Username = AdminAccessTokenTestValues.UsernameForUpdate,
                ExpiresOn = AdminAccessTokenTestValues.ExpiresOnForUpdate,
                AdminRefreshTokenId = AdminAccessTokenTestValues.AdminRefreshTokenIdForUpdate,
                CachedPermissions = AdminAccessTokenTestValues.CachedPermissionsForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdDbDefault, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdDbDefault, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdDbDefault, dbAdminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdDbDefault, dbAdminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsDbDefault.ToList(), dbAdminAccessToken.AdminAdGroupIds.ToList());
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameDbDefault, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnDbDefault, dbAdminAccessToken.ExpiresOn);
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsDbDefault, dbAdminAccessToken.CachedPermissions);
        }

        public static void AssertDbDefault2(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdDbDefault2, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdDbDefault2, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdDbDefault2, dbAdminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdDbDefault2, dbAdminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsDbDefault2.ToList(), dbAdminAccessToken.AdminAdGroupIds.ToList());
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameDbDefault2, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnDbDefault2, dbAdminAccessToken.ExpiresOn);
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsDbDefault2, dbAdminAccessToken.CachedPermissions);
        }

        public static void AssertForCreate(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdForCreate, dbAdminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdForCreate, dbAdminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminAccessToken.AdminAdGroupIds.ToList());
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, dbAdminAccessToken.ExpiresOn);
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsForCreate, dbAdminAccessToken.CachedPermissions);
        }

        public static void AssertForUpdate(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForUpdate, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForUpdate, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdForUpdate, dbAdminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdForUpdate, dbAdminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsForUpdate.ToList(), dbAdminAccessToken.AdminAdGroupIds.ToList());
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForUpdate, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForUpdate, dbAdminAccessToken.ExpiresOn);
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsForUpdate, dbAdminAccessToken.CachedPermissions);
        }
    }
}