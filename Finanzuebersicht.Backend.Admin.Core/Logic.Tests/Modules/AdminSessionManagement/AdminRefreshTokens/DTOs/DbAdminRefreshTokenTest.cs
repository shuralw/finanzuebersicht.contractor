using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class DbAdminRefreshTokenTest : IDbAdminRefreshToken
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public static IDbAdminRefreshToken Default()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdDefault,
                Username = AdminRefreshTokenTestValues.UsernameDefault,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnDefault,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdDefault,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdDefault,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsDefault,
            };
        }

        public static IDbAdminRefreshToken ForCreateEmail()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdForCreate,
                Username = AdminRefreshTokenTestValues.UsernameForCreate,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnForCreate,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdForCreate,
                AdminAdUserId = null,
                AdminAdGroupIds = Array.Empty<Guid>(),
            };
        }

        public static IDbAdminRefreshToken ForCreateAd()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdForCreate,
                Username = AdminRefreshTokenTestValues.UsernameForCreate,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnForCreate,
                AdminEmailUserId = null,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdForCreate,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate,
            };
        }

        public static IDbAdminRefreshToken ForCreateGlobalAdmin()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdForCreate,
                Username = AdminRefreshTokenTestValues.UsernameForCreate,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnForCreate,
                AdminEmailUserId = null,
                AdminAdUserId = null,
                AdminAdGroupIds = Array.Empty<Guid>(),
            };
        }

        public static void AssertDefault(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdDefault, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameDefault, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnDefault, dbAdminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdDefault, dbAdminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdDefault, dbAdminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminRefreshToken.AdminAdGroupIds.ToList());
        }

        public static void AssertCreated(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForCreate, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameForCreate, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnForCreate, dbAdminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdForCreate, dbAdminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdForCreate, dbAdminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminRefreshToken.AdminAdGroupIds.ToList());
        }

        public static void AssertCreatedAdminEmailUser(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForCreate, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameForCreate, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnForCreate, dbAdminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdForCreate, dbAdminRefreshToken.AdminEmailUserId);
            Assert.IsNull(dbAdminRefreshToken.AdminAdUserId);
            Assert.IsFalse(dbAdminRefreshToken.AdminAdGroupIds.Any());
        }

        public static void AssertCreatedAd(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForCreate, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameForCreate, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnForCreate, dbAdminRefreshToken.ExpiresOn);
            Assert.IsNull(dbAdminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdForCreate, dbAdminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminRefreshToken.AdminAdGroupIds.ToList());
        }

        public static void AssertCreatedGlobalAdmin(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForCreate, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameForCreate, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnForCreate, dbAdminRefreshToken.ExpiresOn);
            Assert.IsNull(dbAdminRefreshToken.AdminEmailUserId);
            Assert.IsNull(dbAdminRefreshToken.AdminAdUserId);
            Assert.IsFalse(dbAdminRefreshToken.AdminAdGroupIds.Any());
        }
    }
}