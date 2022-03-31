using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class AdminRefreshTokenTest : IAdminRefreshToken
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public static IAdminRefreshToken Default()
        {
            return new AdminRefreshTokenTest()
            {
                Id = AdminRefreshTokenTestValues.IdDefault,
                Username = AdminRefreshTokenTestValues.UsernameDefault,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnDefault,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdDefault,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdDefault,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsDefault,
            };
        }

        public static void AssertDefault(IAdminRefreshToken adminRefreshToken)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdDefault, adminRefreshToken.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameDefault, adminRefreshToken.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnDefault, adminRefreshToken.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdDefault, adminRefreshToken.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdDefault, adminRefreshToken.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate.ToList(), adminRefreshToken.AdminAdGroupIds.ToList());
        }
    }
}