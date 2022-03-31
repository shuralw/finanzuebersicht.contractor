using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    [TestClass]
    public class AdminRefreshTokensCrudRepositoryTests
    {
        [TestMethod]
        public void CreateAdminRefreshTokenTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryEmpty();

            // Act
            adminRefreshTokensCrudRepository.CreateAdminRefreshToken(DbAdminRefreshTokenTest.ForCreate());

            // Assert
            IDbAdminRefreshToken dbAdminRefreshTokenDetail = adminRefreshTokensCrudRepository.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdForCreate);
            DbAdminRefreshTokenTest.AssertForCreate(dbAdminRefreshTokenDetail);
        }

        [TestMethod]
        public void DeleteAdminRefreshTokenTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryDefault();

            // Act
            adminRefreshTokensCrudRepository.DeleteAdminRefreshToken(AdminRefreshTokenTestValues.IdDbDefault);

            // Assert
            bool doesAdminRefreshTokenExist = adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDbDefault);
            Assert.IsFalse(doesAdminRefreshTokenExist);
        }

        [TestMethod]
        public void DeleteAdminRefreshTokensOfAdminEmailUserTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryDefault();

            // Act
            adminRefreshTokensCrudRepository.DeleteAdminRefreshTokensOfAdminEmailUser(AdminRefreshTokenTestValues.AdminEmailUserIdDbDefault);

            // Assert
            bool doesAdminRefreshTokenExist = adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDbDefault);
            Assert.IsFalse(doesAdminRefreshTokenExist);
            bool doesAdminRefreshTokenExist2 = adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDbDefault2);
            Assert.IsTrue(doesAdminRefreshTokenExist2);
        }

        [TestMethod]
        public void DeleteExpiredAdminRefreshTokensTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryDefault();

            // Act
            adminRefreshTokensCrudRepository.DeleteExpiredAdminRefreshTokens(AdminRefreshTokenTestValues.ExpiresCheck);

            // Assert
            bool doesAdminRefreshTokenExist = adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDbDefault);
            Assert.IsTrue(doesAdminRefreshTokenExist);
            bool doesAdminRefreshTokenExist2 = adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDbDefault2);
            Assert.IsFalse(doesAdminRefreshTokenExist2);
        }

        [TestMethod]
        public void DoesAdminRefreshTokenExistFalseTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryEmpty();

            // Act
            bool doesAdminRefreshTokenExist = adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesAdminRefreshTokenExist);
        }

        [TestMethod]
        public void DoesAdminRefreshTokenExistTrueTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryDefault();

            // Act
            bool doesAdminRefreshTokenExist = adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesAdminRefreshTokenExist);
        }

        [TestMethod]
        public void GetAdminRefreshTokenDefaultTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryDefault();

            // Act
            IDbAdminRefreshToken dbAdminRefreshToken = adminRefreshTokensCrudRepository.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDbDefault);

            // Assert
            DbAdminRefreshTokenTest.AssertDbDefault(dbAdminRefreshToken);
        }

        [TestMethod]
        public void GetAdminRefreshTokenNullTest()
        {
            // Arrange
            AdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository = this.GetAdminRefreshTokensCrudRepositoryEmpty();

            // Act
            IDbAdminRefreshToken dbAdminRefreshToken = adminRefreshTokensCrudRepository.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAdminRefreshToken);
        }

        private AdminRefreshTokensCrudRepository GetAdminRefreshTokensCrudRepositoryDefault()
        {
            return new AdminRefreshTokensCrudRepository(InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AdminRefreshTokensCrudRepository GetAdminRefreshTokensCrudRepositoryEmpty()
        {
            return new AdminRefreshTokensCrudRepository(InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }
    }
}