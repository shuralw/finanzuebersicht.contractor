using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    internal class AdminAdGroupTest : IAdminAdGroup
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public static IAdminAdGroup Default()
        {
            return new AdminAdGroupTest()
            {
                Id = AdminAdGroupTestValues.IdDefault,
                Dn = AdminAdGroupTestValues.DnDefault,
            };
        }

        public static void AssertDefault(IAdminAdGroup adminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, adminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDefault, adminAdGroup.Dn);
        }

        public static void AssertDefault2(IAdminAdGroup adminAdGroup)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault2, adminAdGroup.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDefault2, adminAdGroup.Dn);
        }
    }
}