using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    [TestClass]
    public class AdminEmailUserMembershipRepositoryTests
    {
        [TestMethod]
        public void AddAdminEmailUserToAdminUserGroupTest()
        {
            // Arrange
            AdminEmailUserMembershipRepository adminEmailUserMembershipRepository = this.GetAdminEmailUserMembershipRepositoryDefault();

            // Act
            adminEmailUserMembershipRepository.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminEmailUserMembershipRepository
                .GetAdminUserGroupsOfAdminEmailUser(AdminEmailUserTestValues.IdDbDefault).ToList();
            DbAdminUserGroupTest.AssertDbDefault(dbAdminUserGroups[0]);
        }

        [TestMethod]
        public void RemoveAdminEmailUserFromAdminUserGroupTest()
        {
            // Arrange
            AdminEmailUserMembershipRepository adminEmailUserMembershipRepository = this.GetAdminEmailUserMembershipRepositoryDefault();

            adminEmailUserMembershipRepository.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Act
            adminEmailUserMembershipRepository.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminEmailUserMembershipRepository
                .GetAdminUserGroupsOfAdminEmailUser(AdminEmailUserTestValues.IdDbDefault).ToList();
            Assert.AreEqual(0, dbAdminUserGroups.Count);
        }

        private AdminEmailUserMembershipRepository GetAdminEmailUserMembershipRepositoryDefault()
        {
            return new AdminEmailUserMembershipRepository(InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }
    }
}