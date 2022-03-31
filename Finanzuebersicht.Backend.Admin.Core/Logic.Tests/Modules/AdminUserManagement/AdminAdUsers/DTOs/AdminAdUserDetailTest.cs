using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    internal class AdminAdUserDetailTest : IAdminAdUserDetail
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        public IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }

        public static IAdminAdUserDetail Default()
        {
            return new AdminAdUserDetailTest()
            {
                Id = AdminAdUserTestValues.IdDefault,
                Dn = AdminAdUserTestValues.DnDefault,
                Permissions = AdminAdUserTestValues.PermissionsDefault,
                CalculatedPermissions = AdminAdUserTestValues.CalculatedPermissionsDefault,
                ParentAdminUserGroups = AdminAdUserTestValues.ParentAdminUserGroups,
            };
        }

        public static void AssertDefault(IAdminAdUserDetail adminAdUserDetail)
        {
            Assert.AreEqual(AdminAdUserTestValues.IdDefault, adminAdUserDetail.Id);
            Assert.AreEqual(AdminAdUserTestValues.DnDefault, adminAdUserDetail.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.PermissionsDefault, adminAdUserDetail.Permissions);
            AssertExtension.AreDictionariesEqual(AdminAdUserTestValues.CalculatedPermissionsDefault, adminAdUserDetail.CalculatedPermissions);
            Assert.AreEqual(1, adminAdUserDetail.ParentAdminUserGroups.Count());
            AdminUserGroupTest.AssertDefault(adminAdUserDetail.ParentAdminUserGroups.ElementAt(0));
        }
    }
}