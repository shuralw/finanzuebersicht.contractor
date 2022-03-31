using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class AdminRefreshTokenDetailTest : IAdminRefreshTokenDetail
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public static IAdminRefreshTokenDetail Default()
        {
            return new AdminRefreshTokenDetailTest()
            {
                Id = AdminRefreshTokenTestValues.IdDefault,
                Username = AdminRefreshTokenTestValues.UsernameDefault,
                ExpiresOn = AdminRefreshTokenTestValues.ExpiresOnDefault,
                AdminEmailUserId = AdminRefreshTokenTestValues.AdminEmailUserIdDefault,
                AdminAdUserId = AdminRefreshTokenTestValues.AdminAdUserIdDefault,
                AdminAdGroupIds = AdminRefreshTokenTestValues.AdminAdGroupIdsDefault,
            };
        }

        public static void AssertDefault(IAdminRefreshTokenDetail adminRefreshTokenDetail)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdDefault, adminRefreshTokenDetail.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameDefault, adminRefreshTokenDetail.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnDefault, adminRefreshTokenDetail.ExpiresOn);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminEmailUserIdDefault, adminRefreshTokenDetail.AdminEmailUserId);
            Assert.AreEqual(AdminRefreshTokenTestValues.AdminAdUserIdDefault, adminRefreshTokenDetail.AdminAdUserId);
            CollectionAssert.AreEqual(AdminRefreshTokenTestValues.AdminAdGroupIdsDefault.ToList(), adminRefreshTokenDetail.AdminAdGroupIds.ToList());
        }

        public static void AssertDefaultGlobalAdmin(IAdminRefreshTokenDetail adminRefreshTokenDetail)
        {
            Assert.AreEqual(AdminRefreshTokenTestValues.IdDefault, adminRefreshTokenDetail.Id);
            Assert.AreEqual(AdminRefreshTokenTestValues.UsernameForCreate, adminRefreshTokenDetail.Username);
            Assert.AreEqual(AdminRefreshTokenTestValues.ExpiresOnForCreate, adminRefreshTokenDetail.ExpiresOn);
            Assert.IsNull(adminRefreshTokenDetail.AdminEmailUserId);
            Assert.IsNull(adminRefreshTokenDetail.AdminAdUserId);
            Assert.IsFalse(adminRefreshTokenDetail.AdminAdGroupIds.Any());
        }
    }
}