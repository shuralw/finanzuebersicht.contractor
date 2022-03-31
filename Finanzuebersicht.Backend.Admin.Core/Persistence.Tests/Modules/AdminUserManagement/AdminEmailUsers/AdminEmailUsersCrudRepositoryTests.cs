using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Tools.Pagination;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    [TestClass]
    public class AdminEmailUsersCrudRepositoryTests
    {
        [TestMethod]
        public void CreateAdminEmailUserTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryEmpty();

            // Act
            adminEmailUsersCrudRepository.CreateAdminEmailUser(DbAdminEmailUserTest.ForCreate());

            // Assert
            IDbAdminEmailUser dbAdminEmailUser = adminEmailUsersCrudRepository.GetAdminEmailUser(AdminEmailUserTestValues.IdForCreate);
            DbAdminEmailUserTest.AssertForCreate(dbAdminEmailUser);
        }

        [TestMethod]
        public void DeleteAdminEmailUserTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryDefault();

            // Act
            adminEmailUsersCrudRepository.DeleteAdminEmailUser(AdminEmailUserTestValues.IdDbDefault);

            // Assert
            bool doesAdminEmailUserExist = adminEmailUsersCrudRepository.DoesAdminEmailUserExist(AdminEmailUserTestValues.IdDbDefault);
            Assert.IsFalse(doesAdminEmailUserExist);
        }

        [TestMethod]
        public void DoesAdminEmailUserExistByEmailFalseTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryEmpty();

            // Act
            bool doesAdminEmailUserExist = adminEmailUsersCrudRepository.DoesAdminEmailUserExist(AdminEmailUserTestValues.EmailForCreate);

            // Assert
            Assert.IsFalse(doesAdminEmailUserExist);
        }

        [TestMethod]
        public void DoesAdminEmailUserExistByEmailTrueTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryDefault();

            // Act
            bool doesAdminEmailUserExist = adminEmailUsersCrudRepository.DoesAdminEmailUserExist(AdminEmailUserTestValues.EmailDbDefault);

            // Assert
            Assert.IsTrue(doesAdminEmailUserExist);
        }

        [TestMethod]
        public void DoesAdminEmailUserExistFalseTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryEmpty();

            // Act
            bool doesAdminEmailUserExist = adminEmailUsersCrudRepository.DoesAdminEmailUserExist(AdminEmailUserTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesAdminEmailUserExist);
        }

        [TestMethod]
        public void DoesAdminEmailUserExistTrueTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryDefault();

            // Act
            bool doesAdminEmailUserExist = adminEmailUsersCrudRepository.DoesAdminEmailUserExist(AdminEmailUserTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesAdminEmailUserExist);
        }

        [TestMethod]
        public void GetAdminEmailUserByMailDefaultTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryDefault();

            // Act
            IDbAdminEmailUser dbAdminEmailUser = adminEmailUsersCrudRepository.GetAdminEmailUser(AdminEmailUserTestValues.EmailDbDefault);

            // Assert
            DbAdminEmailUserTest.AssertDbDefault(dbAdminEmailUser);
        }

        [TestMethod]
        public void GetAdminEmailUserDefaultTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryDefault();

            // Act
            IDbAdminEmailUser dbAdminEmailUser = adminEmailUsersCrudRepository.GetAdminEmailUser(AdminEmailUserTestValues.IdDbDefault);

            // Assert
            DbAdminEmailUserTest.AssertDbDefault(dbAdminEmailUser);
        }

        [TestMethod]
        public void GetAdminEmailUserNullTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryEmpty();

            // Act
            IDbAdminEmailUser dbAdminEmailUser = adminEmailUsersCrudRepository.GetAdminEmailUser(AdminEmailUserTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAdminEmailUser);
        }

        [TestMethod]
        public void GetPagedAdminEmailUsersDefaultTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbAdminEmailUser> dbAdminEmailUsersPagedResult =
                adminEmailUsersCrudRepository.GetPagedAdminEmailUsers();

            // Assert
            IDbAdminEmailUser[] dbAdminEmailUsers = dbAdminEmailUsersPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbAdminEmailUsers.Length);
            DbAdminEmailUserTest.AssertDbDefault(dbAdminEmailUsers[0]);
            DbAdminEmailUserTest.AssertDbDefault2(dbAdminEmailUsers[1]);
        }

        [TestMethod]
        public void GetGlobalAdminEmailUserDefaultTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryWithoutSessionContext();

            // Act
            IDbAdminEmailUser dbAdminEmailUser = adminEmailUsersCrudRepository.GetGlobalAdminEmailUser(AdminEmailUserTestValues.IdDbDefault);

            // Assert
            DbAdminEmailUserTest.AssertDbDefault(dbAdminEmailUser);
        }

        [TestMethod]
        public void UpdateAdminEmailUserTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryDefault();

            // Act
            adminEmailUsersCrudRepository.UpdateAdminEmailUser(DbAdminEmailUserTest.ForUpdate());

            // Assert
            IDbAdminEmailUser dbAdminEmailUser = adminEmailUsersCrudRepository.GetAdminEmailUser(AdminEmailUserTestValues.IdDbDefault);
            DbAdminEmailUserTest.AssertForUpdate(dbAdminEmailUser);
        }

        [TestMethod]
        public void UpdateGlobalAdminEmailUserTest()
        {
            // Arrange
            AdminEmailUsersCrudRepository adminEmailUsersCrudRepository = this.GetAdminEmailUsersCrudRepositoryWithoutSessionContext();

            // Act
            adminEmailUsersCrudRepository.UpdateGlobalAdminEmailUser(DbAdminEmailUserTest.ForUpdate());

            // Assert
            IDbAdminEmailUser dbAdminEmailUser = adminEmailUsersCrudRepository.GetGlobalAdminEmailUser(AdminEmailUserTestValues.IdDbDefault);
            DbAdminEmailUserTest.AssertForUpdate(dbAdminEmailUser);
        }

        private AdminEmailUsersCrudRepository GetAdminEmailUsersCrudRepositoryDefault()
        {
            return new AdminEmailUsersCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AdminEmailUsersCrudRepository GetAdminEmailUsersCrudRepositoryEmpty()
        {
            return new AdminEmailUsersCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }

        private AdminEmailUsersCrudRepository GetAdminEmailUsersCrudRepositoryWithoutSessionContext()
        {
            return new AdminEmailUsersCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }
    }
}