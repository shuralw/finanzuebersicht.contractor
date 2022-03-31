using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    [TestClass]
    public class AdminUserGroupMembershipRepositoryTests
    {
        [TestMethod]
        public void AddAdminUserGroupToAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            adminUserGroupMembershipRepository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDbDefault2, AdminUserGroupTestValues.IdDbDefault3);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminUserGroupMembershipRepository
                .GetAdminUserGroupsOfAdminUserGroup(AdminUserGroupTestValues.IdDbDefault3).ToList();
            DbAdminUserGroupTest.AssertDbDefault2(dbAdminUserGroups[0]);
        }

        [TestMethod]
        public void RemoveAdminUserGroupFromAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            adminUserGroupMembershipRepository.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDbDefault, AdminUserGroupTestValues.IdDbDefault2);

            // Assert
            List<IDbAdminUserGroup> dbAdminUserGroups = adminUserGroupMembershipRepository
                .GetAdminUserGroupsOfAdminUserGroup(AdminUserGroupTestValues.IdDbDefault).ToList();
            Assert.AreEqual(0, dbAdminUserGroups.Count);
        }

        [TestMethod]
        public void CircularFalseOneEntryTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            bool circular = adminUserGroupMembershipRepository.HasCircularMembership(AdminUserGroupTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(circular);
        }

        [TestMethod]
        public void CircularFalseTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();
            adminUserGroupMembershipRepository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDbDefault2, AdminUserGroupTestValues.IdDbDefault3);

            // Act
            bool circular = adminUserGroupMembershipRepository.HasCircularMembership(AdminUserGroupTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(circular);
        }

        [TestMethod]
        public void CircularTrueTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();
            adminUserGroupMembershipRepository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDbDefault2, AdminUserGroupTestValues.IdDbDefault3);

            // Act
            adminUserGroupMembershipRepository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDbDefault3, AdminUserGroupTestValues.IdDbDefault);

            bool circular = adminUserGroupMembershipRepository.HasCircularMembership(AdminUserGroupTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(circular);
        }

        [TestMethod]
        public void GetAdminAdGroupsOfAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            List<IDbAdminAdGroup> dbAdminAdGroups = adminUserGroupMembershipRepository
                .GetAdminAdGroupsOfAdminUserGroup(AdminUserGroupTestValues.IdDbDefault)
                .ToList();

            // Assert
            DbAdminAdGroupTest.AssertDbDefault(dbAdminAdGroups[0]);
        }

        [TestMethod]
        public void GetAdminAdUsersOfAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            List<IDbAdminAdUser> dbAdminAdUsers = adminUserGroupMembershipRepository
                .GetAdminAdUsersOfAdminUserGroup(AdminUserGroupTestValues.IdDbDefault)
                .ToList();

            // Assert
            DbAdminAdUserTest.AssertDbDefault(dbAdminAdUsers[0]);
        }

        [TestMethod]
        public void GetAdminUserGroupParentsOfAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            List<IDbAdminUserGroup> dbAdminUserGroup = adminUserGroupMembershipRepository
                .GetAdminUserGroupParentsOfAdminUserGroup(AdminUserGroupTestValues.IdDbDefault)
                .ToList();

            // Assert
            DbAdminUserGroupTest.AssertDbDefault2(dbAdminUserGroup[0]);
        }

        [TestMethod]
        public void GetAdminUserGroupsOfAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            List<IDbAdminUserGroup> dbAdminUserGroup = adminUserGroupMembershipRepository
                .GetAdminUserGroupsOfAdminUserGroup(AdminUserGroupTestValues.IdDbDefault2)
                .ToList();

            // Assert
            DbAdminUserGroupTest.AssertDbDefault(dbAdminUserGroup[0]);
        }

        [TestMethod]
        public void GetAdminEmailUsersOfAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupMembershipRepository adminUserGroupMembershipRepository = this.GetAdminUserGroupMembershipRepositoryDefault();

            // Act
            List<IDbAdminEmailUser> dbAdminEmailUsers = adminUserGroupMembershipRepository
                .GetAdminEmailUsersOfAdminUserGroup(AdminUserGroupTestValues.IdDbDefault)
                .ToList();

            // Assert
            DbAdminEmailUserTest.AssertDbDefault(dbAdminEmailUsers[0]);
        }

        private AdminUserGroupMembershipRepository GetAdminUserGroupMembershipRepositoryDefault()
        {
            PersistenceDbContext persistenceDbContext = InMemoryDbContext.CreatePersistenceDbContextWithDbDefault();

            persistenceDbContext.AdminEmailUserAdminUserGroupRelations.Add(new EfAdminEmailUserAdminUserGroupRelation() { MemberId = AdminEmailUserTestValues.IdDbDefault, ParentId = AdminUserGroupTestValues.IdDbDefault });
            persistenceDbContext.AdminUserGroupAdminUserGroupRelations.Add(new EfAdminUserGroupAdminUserGroupRelation() { MemberId = AdminUserGroupTestValues.IdDbDefault, ParentId = AdminUserGroupTestValues.IdDbDefault2 });
            persistenceDbContext.AdminAdUserAdminUserGroupRelations.Add(new EfAdminAdUserAdminUserGroupRelation() { MemberId = AdminAdUserTestValues.IdDbDefault, ParentId = AdminUserGroupTestValues.IdDbDefault });
            persistenceDbContext.AdminAdGroupAdminUserGroupRelations.Add(new EfAdminAdGroupAdminUserGroupRelation() { MemberId = AdminAdGroupTestValues.IdDbDefault, ParentId = AdminUserGroupTestValues.IdDbDefault });
            persistenceDbContext.SaveChanges();

            return new AdminUserGroupMembershipRepository(persistenceDbContext);
        }
    }
}