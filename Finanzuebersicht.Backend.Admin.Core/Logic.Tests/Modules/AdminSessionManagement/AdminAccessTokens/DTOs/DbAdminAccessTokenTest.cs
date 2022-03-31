using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class DbAdminAccessTokenTest : IDbAdminAccessToken
    {
        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        public static IDbAdminAccessToken Default()
        {
            return new DbAdminAccessTokenTest()
            {
                Id = AdminAccessTokenTestValues.IdDefault,
                AdminRefreshTokenId = AdminAccessTokenTestValues.AdminRefreshTokenIdDefault,
                Username = AdminAccessTokenTestValues.UsernameDefault,
                ExpiresOn = AdminAccessTokenTestValues.ExpiresOnDefault,
                AdminEmailUserId = AdminAccessTokenTestValues.AdminEmailUserIdDefault,
                AdminAdUserId = AdminAccessTokenTestValues.AdminAdUserIdDefault,
                AdminAdGroupIds = AdminAccessTokenTestValues.AdminAdGroupIdsDefault,
                CachedPermissions = AdminAccessTokenTestValues.CachedPermissionsDefault,
            };
        }

        public static void AssertDefault(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdDefault, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdDefault, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameDefault, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnDefault, dbAdminAccessToken.ExpiresOn);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdDefault, dbAdminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdDefault, dbAdminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminAccessToken.AdminAdGroupIds.ToList());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsDefault, dbAdminAccessToken.CachedPermissions);
        }

        public static void AssertCreated(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdDefault, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, dbAdminAccessToken.ExpiresOn);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdForCreate, dbAdminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdForCreate, dbAdminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminAccessToken.AdminAdGroupIds.ToList());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsForCreate, dbAdminAccessToken.CachedPermissions);
        }

        public static void AssertCreatedForEmail(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, dbAdminAccessToken.ExpiresOn);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdForCreate, dbAdminAccessToken.AdminEmailUserId);
            Assert.IsNull(dbAdminAccessToken.AdminAdUserId);
            Assert.IsFalse(dbAdminAccessToken.AdminAdGroupIds.Any());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsForCreate, dbAdminAccessToken.CachedPermissions);
        }

        public static void AssertCreatedForAd(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, dbAdminAccessToken.ExpiresOn);
            Assert.IsNull(dbAdminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdForCreate, dbAdminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminAccessToken.AdminAdGroupIds.ToList());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsForCreate, dbAdminAccessToken.CachedPermissions);
        }

        public static void AssertCreatedForGlobalAdmin(IDbAdminAccessToken dbAdminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, dbAdminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, dbAdminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, dbAdminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, dbAdminAccessToken.ExpiresOn);
            Assert.IsNull(dbAdminAccessToken.AdminEmailUserId);
            Assert.IsNull(dbAdminAccessToken.AdminAdUserId);
            Assert.IsFalse(dbAdminAccessToken.AdminAdGroupIds.Any());
            AssertExtension.AreDictionariesEqual(
                PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.ALLOW),
                dbAdminAccessToken.CachedPermissions);
        }
    }
}