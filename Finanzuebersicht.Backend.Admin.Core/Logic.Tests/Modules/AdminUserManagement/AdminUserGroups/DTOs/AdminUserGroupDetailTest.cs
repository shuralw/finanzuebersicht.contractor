using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    internal class AdminUserGroupDetailTest : IAdminUserGroupDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        public IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }

        public IEnumerable<IAdminUserGroup> AdminUserGroupMembers { get; set; }

        public IEnumerable<IAdminEmailUser> AdminEmailUserMembers { get; set; }

        public IEnumerable<IAdminAdUser> AdminAdUserMembers { get; set; }

        public IEnumerable<IAdminAdGroup> AdminAdGroupMembers { get; set; }

        public static IAdminUserGroupDetail Default()
        {
            return new AdminUserGroupDetailTest()
            {
                Id = AdminUserGroupTestValues.IdDefault,
                Name = AdminUserGroupTestValues.NameDefault,
                Permissions = AdminUserGroupTestValues.PermissionsDefault,
                CalculatedPermissions = AdminUserGroupTestValues.CalculatedPermissionsDefault,
                ParentAdminUserGroups = AdminUserGroupTestValues.ParentAdminUserGroups,
            };
        }

        public static void AssertDefault(IAdminUserGroupDetail adminUserGroupDetail)
        {
            Assert.AreEqual(AdminUserGroupTestValues.IdDefault, adminUserGroupDetail.Id);
            Assert.AreEqual(AdminUserGroupTestValues.NameDefault, adminUserGroupDetail.Name);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDefault, adminUserGroupDetail.Permissions);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.CalculatedPermissionsDefault, adminUserGroupDetail.CalculatedPermissions);

            Assert.AreEqual(1, adminUserGroupDetail.ParentAdminUserGroups.Count());
            AdminUserGroupTest.AssertDefault2(adminUserGroupDetail.ParentAdminUserGroups.ElementAt(0));

            Assert.AreEqual(1, adminUserGroupDetail.AdminEmailUserMembers.Count());
            AdminEmailUserTest.AssertDefault(adminUserGroupDetail.AdminEmailUserMembers.ElementAt(0));

            Assert.AreEqual(1, adminUserGroupDetail.AdminUserGroupMembers.Count());
            AdminUserGroupTest.AssertDefault2(adminUserGroupDetail.AdminUserGroupMembers.ElementAt(0));

            Assert.AreEqual(1, adminUserGroupDetail.AdminAdUserMembers.Count());
            AdminAdUserTest.AssertDefault(adminUserGroupDetail.AdminAdUserMembers.ElementAt(0));

            Assert.AreEqual(1, adminUserGroupDetail.AdminAdGroupMembers.Count());
            AdminAdGroupTest.AssertDefault(adminUserGroupDetail.AdminAdGroupMembers.ElementAt(0));
        }
    }
}