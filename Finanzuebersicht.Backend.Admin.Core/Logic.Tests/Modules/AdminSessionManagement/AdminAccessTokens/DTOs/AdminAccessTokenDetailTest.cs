using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class AdminAccessTokenDetailTest : IAdminAccessTokenDetail
    {
        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        public static void AssertDefault(IAdminAccessTokenDetail adminAccessTokenDetail)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdDefault, adminAccessTokenDetail.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdDefault, adminAccessTokenDetail.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameDefault, adminAccessTokenDetail.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnDefault, adminAccessTokenDetail.ExpiresOn);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminEmailUserIdDefault, adminAccessTokenDetail.AdminEmailUserId);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminAdUserIdDefault, adminAccessTokenDetail.AdminAdUserId);
            CollectionAssert.AreEqual(AdminAccessTokenTestValues.AdminAdGroupIdsDefault.ToList(), adminAccessTokenDetail.AdminAdGroupIds.ToList());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsDefault, adminAccessTokenDetail.CachedPermissions);
        }

        public static void AssertDefaultGlobalAdmin(IAdminAccessTokenDetail adminAccessTokenDetail)
        {
            Assert.AreEqual(AdminAccessTokenTestValues.IdDefault, adminAccessTokenDetail.Id);
            Assert.AreEqual(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate, adminAccessTokenDetail.AdminRefreshTokenId);
            Assert.AreEqual(AdminAccessTokenTestValues.UsernameForCreate, adminAccessTokenDetail.Username);
            Assert.AreEqual(AdminAccessTokenTestValues.ExpiresOnForCreate, adminAccessTokenDetail.ExpiresOn);
            Assert.IsNull(adminAccessTokenDetail.AdminEmailUserId);
            Assert.IsNull(adminAccessTokenDetail.AdminAdUserId);
            Assert.IsFalse(adminAccessTokenDetail.AdminAdGroupIds.Any());
            AssertExtension.AreDictionariesEqual(AdminAccessTokenTestValues.CachedPermissionsDefault, adminAccessTokenDetail.CachedPermissions);
        }
    }
}