using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    [TestClass]
    public class AdminAccessTokensCrudRepositoryTests
    {
        [TestMethod]
        public void CreateAdminAccessTokenTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryEmpty();

            // Act
            adminAccessTokensCrudRepository.CreateAdminAccessToken(DbAdminAccessTokenTest.ForCreate());

            // Assert
            IDbAdminAccessToken dbAdminAccessToken = adminAccessTokensCrudRepository.GetAdminAccessToken(AdminAccessTokenTestValues.IdForCreate);
            DbAdminAccessTokenTest.AssertForCreate(dbAdminAccessToken);
        }

        [TestMethod]
        public void DeleteAdminAccessTokenTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryDefault();

            // Act
            adminAccessTokensCrudRepository.DeleteAdminAccessToken(AdminAccessTokenTestValues.IdDbDefault);

            // Assert
            bool doesAdminAccessTokenExist = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault);
            Assert.IsFalse(doesAdminAccessTokenExist);
        }

        [TestMethod]
        public void DeleteExpiredAdminAccessTokensTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryDefault();

            // Act
            adminAccessTokensCrudRepository.DeleteExpiredAdminAccessTokens(AdminAccessTokenTestValues.ExpiresCheck);

            // Assert
            bool doesAdminAccessTokenExist = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault);
            Assert.IsTrue(doesAdminAccessTokenExist);
            bool doesAdminAccessTokenExist2 = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault2);
            Assert.IsFalse(doesAdminAccessTokenExist2);
        }

        [TestMethod]
        public void DeleteAdminAccessTokensOfAdminEmailUserTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryDefault();

            // Act
            adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminEmailUser(AdminAccessTokenTestValues.AdminEmailUserIdDbDefault);

            // Assert
            bool doesAdminAccessTokenExist = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault);
            Assert.IsFalse(doesAdminAccessTokenExist);
            bool doesAdminAccessTokenExist2 = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault2);
            Assert.IsTrue(doesAdminAccessTokenExist2);
        }

        [TestMethod]
        public void DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroupsTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryDefault();

            // Act
            adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            // Assert
            bool doesAdminAccessTokenExist = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault);
            Assert.IsFalse(doesAdminAccessTokenExist);
            bool doesAdminAccessTokenExist2 = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault2);
            Assert.IsFalse(doesAdminAccessTokenExist2);
        }

        [TestMethod]
        public void DoesAdminAccessTokenExistFalseTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryEmpty();

            // Act
            bool doesAdminAccessTokenExist = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesAdminAccessTokenExist);
        }

        [TestMethod]
        public void DoesAdminAccessTokenExistTrueTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryDefault();

            // Act
            bool doesAdminAccessTokenExist = adminAccessTokensCrudRepository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesAdminAccessTokenExist);
        }

        [TestMethod]
        public void GetAdminAccessTokenDefaultTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryDefault();

            // Act
            IDbAdminAccessToken dbAdminAccessToken = adminAccessTokensCrudRepository.GetAdminAccessToken(AdminAccessTokenTestValues.IdDbDefault);

            // Assert
            DbAdminAccessTokenTest.AssertDbDefault(dbAdminAccessToken);
        }

        [TestMethod]
        public void GetAdminAccessTokenNullTest()
        {
            // Arrange
            AdminAccessTokensCrudRepository adminAccessTokensCrudRepository = this.GetAdminAccessTokensCrudRepositoryEmpty();

            // Act
            IDbAdminAccessToken dbAdminAccessToken = adminAccessTokensCrudRepository.GetAdminAccessToken(AdminAccessTokenTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAdminAccessToken);
        }

        private AdminAccessTokensCrudRepository GetAdminAccessTokensCrudRepositoryDefault()
        {
            return new AdminAccessTokensCrudRepository(
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AdminAccessTokensCrudRepository GetAdminAccessTokensCrudRepositoryEmpty()
        {
            return new AdminAccessTokensCrudRepository(
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }
    }
}