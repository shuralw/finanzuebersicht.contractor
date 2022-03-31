using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    internal class AdminUserGroupTest : IAdminUserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static IAdminUserGroup Default()
        {
            return new AdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDefault,
                Name = AdminUserGroupTestValues.NameDefault,
            };
        }

        public static IAdminUserGroup Default2()
        {
            return new AdminUserGroupTest()
            {
                Id = AdminUserGroupTestValues.IdDefault2,
                Name = AdminUserGroupTestValues.NameDefault2,
            };
        }

        public static void AssertDefault(IAdminUserGroup adminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault, adminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault, adminUserGroup.Name);
        }

        public static void AssertDefault2(IAdminUserGroup adminUserGroup)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault2, adminUserGroup.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault2, adminUserGroup.Name);
        }
    }
}