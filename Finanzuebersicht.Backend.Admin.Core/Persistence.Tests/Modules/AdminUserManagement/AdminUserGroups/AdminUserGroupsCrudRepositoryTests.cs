using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Tools.Pagination;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    [TestClass]
    public class AdminUserGroupsCrudRepositoryTests
    {
        [TestMethod]
        public void CreateAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryEmpty();

            // Act
            adminUserGroupsCrudRepository.CreateAdminUserGroup(DbAdminUserGroupTest.ForCreate());

            // Assert
            IDbAdminUserGroup dbAdminUserGroup = adminUserGroupsCrudRepository.GetAdminUserGroup(AdminUserGroupTestValues.IdForCreate);
            DbAdminUserGroupTest.AssertForCreate(dbAdminUserGroup);
        }

        [TestMethod]
        public void DeleteAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryDefault();

            // Act
            adminUserGroupsCrudRepository.DeleteAdminUserGroup(AdminUserGroupTestValues.IdDbDefault);

            // Assert
            IDbAdminUserGroup dbAdminUserGroup = adminUserGroupsCrudRepository.GetAdminUserGroup(AdminUserGroupTestValues.IdDbDefault);
            Assert.IsNull(dbAdminUserGroup);
        }

        [TestMethod]
        public void DoesAdminUserGroupExistTrueTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryDefault();

            // Act
            bool doesAdminUserGroupExist = adminUserGroupsCrudRepository.DoesAdminUserGroupExist(AdminUserGroupTestValues.NameDbDefault);

            // Assert
            Assert.IsTrue(doesAdminUserGroupExist);
        }

        [TestMethod]
        public void DoesAdminUserGroupExistFalseTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryEmpty();

            // Act
            bool doesAdminUserGroupExist = adminUserGroupsCrudRepository.DoesAdminUserGroupExist(AdminUserGroupTestValues.NameDbDefault);

            // Assert
            Assert.IsFalse(doesAdminUserGroupExist);
        }

        [TestMethod]
        public void GetAdminUserGroupDefaultTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryDefault();

            // Act
            IDbAdminUserGroup dbAdminUserGroup = adminUserGroupsCrudRepository.GetAdminUserGroup(AdminUserGroupTestValues.IdDbDefault);

            // Assert
            DbAdminUserGroupTest.AssertDbDefault(dbAdminUserGroup);
        }

        [TestMethod]
        public void GetAdminUserGroupNullTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryEmpty();

            // Act
            IDbAdminUserGroup dbAdminUserGroup = adminUserGroupsCrudRepository.GetAdminUserGroup(AdminUserGroupTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAdminUserGroup);
        }

        [TestMethod]
        public void GetPagedAdminUserGroupsDefaultTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbAdminUserGroup> dbAdminUserGroupsPagedResult =
                adminUserGroupsCrudRepository.GetPagedAdminUserGroups();

            // Assert
            IDbAdminUserGroup[] dbAdminUserGroups = dbAdminUserGroupsPagedResult.Data.ToArray();
            Assert.AreEqual(3, dbAdminUserGroups.Length);
            DbAdminUserGroupTest.AssertDbDefault(dbAdminUserGroups[0]);
            DbAdminUserGroupTest.AssertDbDefault2(dbAdminUserGroups[1]);
            DbAdminUserGroupTest.AssertDbDefault3(dbAdminUserGroups[2]);
        }

        [TestMethod]
        public void UpdateAdminUserGroupTest()
        {
            // Arrange
            AdminUserGroupsCrudRepository adminUserGroupsCrudRepository = this.GetAdminUserGroupsCrudRepositoryDefault();

            // Act
            adminUserGroupsCrudRepository.UpdateAdminUserGroup(DbAdminUserGroupTest.ForUpdate());

            // Assert
            IDbAdminUserGroup dbAdminUserGroup = adminUserGroupsCrudRepository.GetAdminUserGroup(AdminUserGroupTestValues.IdDbDefault);
            DbAdminUserGroupTest.AssertForUpdate(dbAdminUserGroup);
        }

        private AdminUserGroupsCrudRepository GetAdminUserGroupsCrudRepositoryDefault()
        {
            return new AdminUserGroupsCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AdminUserGroupsCrudRepository GetAdminUserGroupsCrudRepositoryEmpty()
        {
            return new AdminUserGroupsCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }
    }
}