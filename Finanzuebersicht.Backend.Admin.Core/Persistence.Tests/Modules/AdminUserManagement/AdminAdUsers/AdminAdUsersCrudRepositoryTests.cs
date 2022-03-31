using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Tools.Pagination;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    [TestClass]
    public class AdminAdUsersCrudRepositoryTests
    {
        [TestMethod]
        public void CreateAdminAdUserTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryEmpty();

            // Act
            adminAdUsersCrudRepository.CreateAdminAdUser(DbAdminAdUserTest.ForCreate());

            // Assert
            IDbAdminAdUser dbAdminAdUser = adminAdUsersCrudRepository.GetAdminAdUser(AdminAdUserTestValues.IdForCreate);
            DbAdminAdUserTest.AssertForCreate(dbAdminAdUser);
        }

        [TestMethod]
        public void DeleteAdminAdUserTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryDefault();

            // Act
            adminAdUsersCrudRepository.DeleteAdminAdUser(AdminAdUserTestValues.IdDbDefault);

            // Assert
            bool doesAdminAdUserExist = adminAdUsersCrudRepository.DoesAdminAdUserExist(AdminAdUserTestValues.DnDbDefault);
            Assert.IsFalse(doesAdminAdUserExist);
        }

        [TestMethod]
        public void DoesAdminAdUserExistFalseTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryEmpty();

            // Act
            bool doesAdminAdUserExist = adminAdUsersCrudRepository.DoesAdminAdUserExist(AdminAdUserTestValues.DnDbDefault);

            // Assert
            Assert.IsFalse(doesAdminAdUserExist);
        }

        [TestMethod]
        public void DoesAdminAdUserExistTrueTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryDefault();

            // Act
            bool doesAdminAdUserExist = adminAdUsersCrudRepository.DoesAdminAdUserExist(AdminAdUserTestValues.DnDbDefault);

            // Assert
            Assert.IsTrue(doesAdminAdUserExist);
        }

        [TestMethod]
        public void GetAdminAdUserDefaultTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryDefault();

            // Act
            IDbAdminAdUser dbAdminAdUser = adminAdUsersCrudRepository.GetAdminAdUser(AdminAdUserTestValues.IdDbDefault);

            // Assert
            DbAdminAdUserTest.AssertDbDefault(dbAdminAdUser);
        }

        [TestMethod]
        public void GetAdminAdUserNullTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryEmpty();

            // Act
            IDbAdminAdUser dbAdminAdUser = adminAdUsersCrudRepository.GetAdminAdUser(AdminAdUserTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAdminAdUser);
        }

        [TestMethod]
        public void GetPagedAdminAdUsersDefaultTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdUsersCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbAdminAdUser> dbAdminAdUsersPagedResult =
                adminAdGroupsCrudRepository.GetPagedAdminAdUsers();

            // Assert
            IDbAdminAdUser[] dbAdminAdUsers = dbAdminAdUsersPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbAdminAdUsers.Length);
            DbAdminAdUserTest.AssertDbDefault(dbAdminAdUsers[0]);
            DbAdminAdUserTest.AssertDbDefault2(dbAdminAdUsers[1]);
        }

        [TestMethod]
        public void GetGlobalAdminAdUsersDefaultTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryDefault();

            // Act
            IDbAdminAdUser[] adminAdUsers = adminAdUsersCrudRepository.GetGlobalAdminAdUsers(AdminAdUserTestValues.DnDbDefault).ToArray();

            // Assert
            Assert.AreEqual(1, adminAdUsers.Length);
            DbAdminAdUserTest.AssertDbDefault(adminAdUsers[0]);
        }

        [TestMethod]
        public void GetGlobalAdminAdUserDefaultTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryWithoutSessionContext();

            // Act
            IDbAdminAdUser dbAdminAdUser = adminAdUsersCrudRepository.GetGlobalAdminAdUser(AdminAdUserTestValues.IdDbDefault);

            // Assert
            DbAdminAdUserTest.AssertDbDefault(dbAdminAdUser);
        }

        [TestMethod]
        public void UpdateAdminAdUserTest()
        {
            // Arrange
            AdminAdUsersCrudRepository adminAdUsersCrudRepository = this.GetAdminAdUsersCrudRepositoryDefault();

            // Act
            adminAdUsersCrudRepository.UpdateAdminAdUser(DbAdminAdUserTest.ForUpdate());

            // Assert
            IDbAdminAdUser dbAdminAdUser = adminAdUsersCrudRepository.GetAdminAdUser(AdminAdUserTestValues.IdDbDefault);
            DbAdminAdUserTest.AssertForUpdate(dbAdminAdUser);
        }

        private AdminAdUsersCrudRepository GetAdminAdUsersCrudRepositoryDefault()
        {
            return new AdminAdUsersCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AdminAdUsersCrudRepository GetAdminAdUsersCrudRepositoryEmpty()
        {
            return new AdminAdUsersCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }

        private AdminAdUsersCrudRepository GetAdminAdUsersCrudRepositoryWithoutSessionContext()
        {
            return new AdminAdUsersCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }
    }
}