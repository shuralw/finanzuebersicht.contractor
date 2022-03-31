using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class DbAdminRefreshTokenTest : IDbAdminRefreshToken
    {
        public Guid Id { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public static IDbAdminRefreshToken DbDefault()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdDbDefault,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdDbDefault,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdDbDefault,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsDbDefault,
                Username = AdminRefreshTokenTestValues.UsernameDbDefault,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnDbDefault,
            };
        }

        public static IDbAdminRefreshToken DbDefault2()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdDbDefault2,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdDbDefault2,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdDbDefault2,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsDbDefault2,
                Username = AdminRefreshTokenTestValues.UsernameDbDefault2,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnDbDefault2,
            };
        }

        public static IDbAdminRefreshToken ForCreate()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdForCreate,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdForCreate,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdForCreate,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate,
                Username = AdminRefreshTokenTestValues.UsernameForCreate,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnForCreate,
            };
        }

        public static IDbAdminRefreshToken ForUpdate()
        {
            return new DbAdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdForUpdate,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdForUpdate,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdForUpdate,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsForUpdate,
                Username = AdminRefreshTokenTestValues.UsernameForUpdate,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdDbDefault, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameDbDefault, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnDbDefault, dbAdminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdDbDefault, dbAdminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdDbDefault, dbAdminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsDbDefault.ToList(), dbAdminRefreshToken.AdminAdGroupIds.ToList());
        }

        public static void AssertDbDefault2(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdDbDefault2, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameDbDefault2, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnDbDefault2, dbAdminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdDbDefault2, dbAdminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdDbDefault2, dbAdminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsDbDefault2.ToList(), dbAdminRefreshToken.AdminAdGroupIds.ToList());
        }

        public static void AssertForCreate(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForCreate, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameForCreate, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnForCreate, dbAdminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdForCreate, dbAdminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdForCreate, dbAdminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate.ToList(), dbAdminRefreshToken.AdminAdGroupIds.ToList());
        }

        public static void AssertForUpdate(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForUpdate, dbAdminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameForUpdate, dbAdminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnForUpdate, dbAdminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdForUpdate, dbAdminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdForUpdate, dbAdminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsForUpdate.ToList(), dbAdminRefreshToken.AdminAdGroupIds.ToList());
        }
    }
}