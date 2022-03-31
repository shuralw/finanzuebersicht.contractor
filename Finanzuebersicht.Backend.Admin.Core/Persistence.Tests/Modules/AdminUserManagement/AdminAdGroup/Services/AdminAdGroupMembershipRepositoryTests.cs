using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    [TestClass]
    public class AdminAdGroupMembershipRepositoryTests
    {
        [TestMethod]
        public void AddAdminAdGroupToAdminUserGroupTest()
        {
            // Arrange
            AdminAdGroupMembershipRepository adminAdGroupMembershipRepository = this.GetAdminAdGroupMembershipRepositoryDefault();

            // Act
            adminAdGroupMembershipRepository.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminAdGroupMembershipRepository
                .GetAdminUserGroupsOfAdminAdGroup(AdminAdGroupTestValues.IdDbDefault).ToList();
            DbAdminUserGroupTest.AssertDbDefault(dbAdminUserGroups[0]);
        }

        [TestMethod]
        public void RemoveAdminAdGroupFromAdminUserGroupTest()
        {
            // Arrange
            AdminAdGroupMembershipRepository adminAdGroupMembershipRepository = this.GetAdminAdGroupMembershipRepositoryDefault();

            adminAdGroupMembershipRepository.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Act
            adminAdGroupMembershipRepository.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminAdGroupMembershipRepository
                .GetAdminUserGroupsOfAdminAdGroup(AdminAdGroupTestValues.IdDbDefault).ToList();
            Assert.AreEqual(0, dbAdminUserGroups.Count);
        }

        private AdminAdGroupMembershipRepository GetAdminAdGroupMembershipRepositoryDefault()
        {
            return new AdminAdGroupMembershipRepository(InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }
    }
}