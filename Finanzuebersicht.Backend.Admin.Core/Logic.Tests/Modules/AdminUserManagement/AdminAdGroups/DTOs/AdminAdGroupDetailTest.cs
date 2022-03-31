using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    internal class AdminAdGroupDetailTest : IAdminAdGroupDetail
    {
        public Guid Id { get; set; }

        public string Dn { get; set; }

        public IDictionary<string, PermissionStatus> Permissions { get; set; }

        public IDictionary<string, PermissionStatus> CalculatedPermissions { get; set; }

        public IEnumerable<IAdminUserGroup> ParentAdminUserGroups { get; set; }

        public static IAdminAdGroupDetail Default()
        {
            return new AdminAdGroupDetailTest()
            {
                Id = AdminAdGroupTestValues.IdDefault,
                Dn = AdminAdGroupTestValues.DnDefault,
                Permissions = AdminAdGroupTestValues.PermissionsDefault,
                CalculatedPermissions = AdminAdGroupTestValues.CalculatedPermissionsDefault,
                ParentAdminUserGroups = AdminAdGroupTestValues.ParentAdminUserGroups,
            };
        }

        public static void AssertDefault(IAdminAdGroupDetail adminAdGroupDetail)
        {
            Assert.AreEqual(AdminAdGroupTestValues.IdDefault, adminAdGroupDetail.Id);
            Assert.AreEqual(AdminAdGroupTestValues.DnDefault, adminAdGroupDetail.Dn);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.PermissionsDefault, adminAdGroupDetail.Permissions);
            AssertExtension.AreDictionariesEqual(AdminAdGroupTestValues.CalculatedPermissionsDefault, adminAdGroupDetail.CalculatedPermissions);
            Assert.AreEqual(1, adminAdGroupDetail.ParentAdminUserGroups.Count());
            AdminUserGroupTest.AssertDefault(adminAdGroupDetail.ParentAdminUserGroups.ElementAt(0));
        }
    }
}