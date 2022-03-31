using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class AdminEmailUserDetailTest : IAdminEmailUserDetail
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        public IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }

        public static IAdminEmailUserDetail Default()
        {
            return new AdminEmailUserDetailTest()
            {
                Id = AdminEmailUserTestValues.IdDefault,
                Email = AdminEmailUserTestValues.EmailDefault,
                Permissions = AdminEmailUserTestValues.PermissionsDefault,
                CalculatedPermissions = AdminEmailUserTestValues.CalculatedPermissionsDefault,
                ParentAdminUserGroups = AdminEmailUserTestValues.ParentAdminUserGroups,
            };
        }

        public static void AssertDefault(IAdminEmailUserDetail adminEmailUserDetail)
        {
            Assert.AreEqual(AdminEmailUserTestValues.IdDefault, adminEmailUserDetail.Id);
            Assert.AreEqual(AdminEmailUserTestValues.EmailDefault, adminEmailUserDetail.Email);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.PermissionsDefault, adminEmailUserDetail.Permissions);
            AssertExtension.AreDictionariesEqual(AdminEmailUserTestValues.CalculatedPermissionsDefault, adminEmailUserDetail.CalculatedPermissions);
            Assert.AreEqual(1, adminEmailUserDetail.ParentAdminUserGroups.Count());
            AdminUserGroupTest.AssertDefault(adminEmailUserDetail.ParentAdminUserGroups.ElementAt(0));
        }
    }
}