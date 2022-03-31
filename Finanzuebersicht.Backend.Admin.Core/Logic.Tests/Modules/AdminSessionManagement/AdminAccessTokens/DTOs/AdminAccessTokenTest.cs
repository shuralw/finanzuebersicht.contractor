using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class AdminAccessTokenTest : IAdminAccessToken
    {
        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        public static IAdminAccessToken Default()
        {
            return new AdminAccessTokenTest()
            {
                Id = AdminAccessTokenTestValues.IdDefault,
                AdminRefreshTokenId = AdminAccessTokenTestValues.AdminRefreshTokenIdDefault,
                Username = AdminAccessTokenTestValues.UsernameDefault,
                ExpiresOn = AdminAccessTokenTestValues.ExpiresOnDefault,
                AdminEmailUserId = AdminAccessTokenTestValues.AdminEmailUserIdDefault,
                AdminAdUserId = AdminAccessTokenTestValues.AdminAdUserIdDefault,
                AdminAdGroupIds = AdminAccessTokenTestValues.AdminAdGroupIdsDefault,
                CachedPermissions = AdminAccessTokenTestValues.CachedPermissionsDefault
            };
        }

        public static void AssertDefault(IAdminAccessToken adminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdDefault, adminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdDefault, adminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameDefault, adminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnDefault, adminAccessToken.ExpiresOn);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdDefault, adminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdDefault, adminAccessToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsDefault.ToList(), adminAccessToken.AdminAdGroupIds.ToList());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsDefault, adminAccessToken.CachedPermissions);
        }

        public static void AssertCreatedForEmail(IAdminAccessToken adminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, adminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, adminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, adminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, adminAccessToken.ExpiresOn);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdForCreate, adminAccessToken.AdminEmailUserId);
            Assert.IsNull(adminAccessToken.AdminAdUserId);
            Assert.IsFalse(adminAccessToken.AdminAdGroupIds.Any());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsForCreate, adminAccessToken.CachedPermissions);
        }

        public static void AssertCreatedForAd(IAdminAccessToken adminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, adminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, adminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, adminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, adminAccessToken.ExpiresOn);
            Assert.IsNull(adminAccessToken.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdForCreate, adminAccessToken.AdminAdUserId);
            Assert.IsTrue(adminAccessToken.AdminAdGroupIds.Any());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsForCreate, adminAccessToken.CachedPermissions);
        }

        public static void AssertCreatedForGlobalAdmin(IAdminAccessToken adminAccessToken)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdForCreate, adminAccessToken.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, adminAccessToken.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, adminAccessToken.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, adminAccessToken.ExpiresOn);
            Assert.IsNull(adminAccessToken.AdminEmailUserId);
            Assert.IsNull(adminAccessToken.AdminAdUserId);
            Assert.IsFalse(adminAccessToken.AdminAdGroupIds.Any());
            AssertExtension.AreDictionariesEqual(
                PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.ALLOW),
                adminAccessToken.CachedPermissions);
        }
    }
}