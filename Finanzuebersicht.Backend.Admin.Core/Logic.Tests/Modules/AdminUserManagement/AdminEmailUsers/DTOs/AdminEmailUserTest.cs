using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class AdminEmailUserTest : IAdminEmailUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public static IAdminEmailUser Default()
        {
            return new AdminEmailUserTest()
            {
                Id = AdminEmailUserTestValues.IdDefault,
                Email = AdminEmailUserTestValues.EmailDefault,
            };
        }

        public static void AssertDefault(IAdminEmailUser adminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, adminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDefault, adminEmailUser.Email);
        }

        public static void AssertDefault2(IAdminEmailUser adminEmailUser)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault2, adminEmailUser.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDefault2, adminEmailUser.Email);
        }
    }
}