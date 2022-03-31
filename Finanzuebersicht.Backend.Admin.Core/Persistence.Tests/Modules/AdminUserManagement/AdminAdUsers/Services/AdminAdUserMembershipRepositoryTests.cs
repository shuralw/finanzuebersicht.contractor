using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    [TestClass]
    public class AdminAdUserMembershipRepositoryTests
    {
        [TestMethod]
        public void AddAdminAdUserToAdminUserGroupTest()
        {
            // Arrange
            AdminAdUserMembershipRepository adminAdUserMembershipRepository = this.GetAdminAdUserMembershipRepositoryDefault();

            // Act
            adminAdUserMembershipRepository.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminAdUserMembershipRepository
                .GetAdminUserGroupsOfAdminAdUser(AdminAdUserTestValues.IdDbDefault).ToList();
            DbAdminUserGroupTest.AssertDbDefault(dbAdminUserGroups[0]);
        }

        [TestMethod]
        public void RemoveAdminAdUserFromAdminUserGroupTest()
        {
            // Arrange
            AdminAdUserMembershipRepository adminAdUserMembershipRepository = this.GetAdminAdUserMembershipRepositoryDefault();

            adminAdUserMembershipRepository.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Act
            adminAdUserMembershipRepository.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminAdUserMembershipRepository
                .GetAdminUserGroupsOfAdminAdUser(AdminAdUserTestValues.IdDbDefault).ToList();
            Assert.AreEqual(0, dbAdminUserGroups.Count);
        }

        private AdminAdUserMembershipRepository GetAdminAdUserMembershipRepositoryDefault()
        {
            return new AdminAdUserMembershipRepository(InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }
    }
}