using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens
{
    internal class DbAdminEmailUserPasswordResetTokenTest : IDbAdminEmailUserPasswordResetToken
    {
        public string Token { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid AdminEmailUserId { get; set; }

        public static IDbAdminEmailUserPasswordResetToken DbDefault()
        {
            return new DbAdminEmailUserPasswordResetTokenTest()
            {
                Token = AdminEmailUserPasswordResetTokenTestValues.TokenDbDefault,
                ExpiresOn = AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDbDefault,
                AdminEmailUserId = AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdDbDefault,
            };
        }

        public static IDbAdminEmailUserPasswordResetToken DbDefault2()
        {
            return new DbAdminEmailUserPasswordResetTokenTest()
            {
                Token = AdminEmailUserPasswordResetTokenTestValues.TokenDbDefault2,
                ExpiresOn = AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDbDefault2,
                AdminEmailUserId = AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdDbDefault2,
            };
        }

        public static IDbAdminEmailUserPasswordResetToken ForCreate()
        {
            return new DbAdminEmailUserPasswordResetTokenTest()
            {
                Token = AdminEmailUserPasswordResetTokenTestValues.TokenForCreate,
                ExpiresOn = AdminEmailUserPasswordResetTokenTestValues.ExpiresOnForCreate,
                AdminEmailUserId = AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdForCreate,
            };
        }

        public static IDbAdminEmailUserPasswordResetToken ForUpdate()
        {
            return new DbAdminEmailUserPasswordResetTokenTest()
            {
                Token = AdminEmailUserPasswordResetTokenTestValues.TokenForUpdate,
                ExpiresOn = AdminEmailUserPasswordResetTokenTestValues.ExpiresOnForUpdate,
                AdminEmailUserId = AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminEmailUserPasswordResetToken dbAdminEmailUserPasswordResetToken)
        {
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.TokenDbDefault, dbAdminEmailUserPasswordResetToken.Token);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDbDefault, dbAdminEmailUserPasswordResetToken.ExpiresOn);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdDbDefault, dbAdminEmailUserPasswordResetToken.AdminEmailUserId);
        }

        public static void AssertDbDefault2(IDbAdminEmailUserPasswordResetToken dbAdminEmailUserPasswordResetToken)
        {
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.TokenDbDefault2, dbAdminEmailUserPasswordResetToken.Token);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDbDefault2, dbAdminEmailUserPasswordResetToken.ExpiresOn);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdDbDefault2, dbAdminEmailUserPasswordResetToken.AdminEmailUserId);
        }

        public static void AssertForCreate(IDbAdminEmailUserPasswordResetToken dbAdminEmailUserPasswordResetToken)
        {
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.TokenForCreate, dbAdminEmailUserPasswordResetToken.Token);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.ExpiresOnForCreate, dbAdminEmailUserPasswordResetToken.ExpiresOn);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdForCreate, dbAdminEmailUserPasswordResetToken.AdminEmailUserId);
        }

        public static void AssertForUpdate(IDbAdminEmailUserPasswordResetToken dbAdminEmailUserPasswordResetToken)
        {
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.TokenForUpdate, dbAdminEmailUserPasswordResetToken.Token);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.ExpiresOnForUpdate, dbAdminEmailUserPasswordResetToken.ExpiresOn);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdForUpdate, dbAdminEmailUserPasswordResetToken.AdminEmailUserId);
        }
    }
}