using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class DbAdminEmailUserPasswordResetTokenTest : IDbAdminEmailUserPasswordResetToken
    {
        public string Token { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid AdminEmailUserId { get; set; }

        public static IDbAdminEmailUserPasswordResetToken Default()
        {
            return new DbAdminEmailUserPasswordResetTokenTest()
            {
                Token = AdminEmailUserPasswordResetTokenTestValues.TokenDefault,
                ExpiresOn = AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDefault,
                AdminEmailUserId = AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdDefault,
            };
        }

        public static IDbAdminEmailUserPasswordResetToken Default2()
        {
            return new DbAdminEmailUserPasswordResetTokenTest()
            {
                Token = AdminEmailUserPasswordResetTokenTestValues.TokenDefault2,
                ExpiresOn = AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDefault2,
                AdminEmailUserId = AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdDefault2,
            };
        }

        public static void AssertDefault(IDbAdminEmailUserPasswordResetToken dbAdminEmailUserPasswordResetToken)
        {
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.TokenDefault, dbAdminEmailUserPasswordResetToken.Token);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDefault, dbAdminEmailUserPasswordResetToken.ExpiresOn);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdDefault, dbAdminEmailUserPasswordResetToken.AdminEmailUserId);
        }

        public static void AssertCreated(IDbAdminEmailUserPasswordResetToken dbAdminEmailUserPasswordResetToken)
        {
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.TokenForCreate, dbAdminEmailUserPasswordResetToken.Token);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.ExpiresOnForCreate, dbAdminEmailUserPasswordResetToken.ExpiresOn);
            Assert.AreEqual(AdminEmailUserPasswordResetTokenTestValues.AdminEmailUserIdForCreate, dbAdminEmailUserPasswordResetToken.AdminEmailUserId);
        }
    }
}