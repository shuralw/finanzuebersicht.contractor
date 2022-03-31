using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    internal class AdminAdUserTest : IAdminAdUser
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public static IAdminAdUser Default()
        {
            return new AdminAdUserTest()
            {
                Id = AdminAdUserTestValues.IdDefault,
                Dn = AdminAdUserTestValues.DnDefault,
            };
        }

        public static void AssertDefault(IAdminAdUser adminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, adminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDefault, adminAdUser.Dn);
        }

        public static void AssertDefault2(IAdminAdUser adminAdUser)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault2, adminAdUser.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDefault2, adminAdUser.Dn);
        }
    }
}