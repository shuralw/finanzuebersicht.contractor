using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    [TestClass]
    public class AdminRefreshTokensCrudLogicTests
    {
        [TestMethod]
        public void CreateAdminRefreshTokenForAdminEmailUserDefaultTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryAdminEmailUser();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminRefreshTokensCrudLogic>>();
            IOptions<AdminRefreshTokenOptions> options = this.SetupAdminRefreshTokenOptions();

            AdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic = new AdminRefreshTokensCrudLogic(
                adminRefreshTokensCrudRepository.Object,
                guidGenerator.Object,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            Guid adminRefreshTokenId = adminRefreshTokensCrudLogic.CreateAdminRefreshTokenForAdminEmailUser(
                AdminRefreshTokenTestValues.AdminEmailUserIdForCreate,
                AdminRefreshTokenTestValues.UsernameForCreate);

            // Assert
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForCreate, adminRefreshTokenId);
            adminRefreshTokensCrudRepository.Verify((repository) => repository.CreateAdminRefreshToken(It.IsAny<IDbAdminRefreshToken>()), Times.Once);
        }

        [TestMethod]
        public void CreateAdminRefreshTokenForAdDefaultTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryAd();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminRefreshTokensCrudLogic>>();
            IOptions<AdminRefreshTokenOptions> options = this.SetupAdminRefreshTokenOptions();

            AdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic = new AdminRefreshTokensCrudLogic(
                adminRefreshTokensCrudRepository.Object,
                guidGenerator.Object,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            Guid adminRefreshTokenId = adminRefreshTokensCrudLogic.CreateAdminRefreshTokenForAd(
                AdminRefreshTokenTestValues.AdminAdUserIdForCreate,
                AdminRefreshTokenTestValues.AdminAdGroupIdsForCreate,
                AdminRefreshTokenTestValues.UsernameForCreate);

            // Assert
            Assert.AreEqual(AdminRefreshTokenTestValues.IdForCreate, adminRefreshTokenId);
            adminRefreshTokensCrudRepository.Verify((repository) => repository.CreateAdminRefreshToken(It.IsAny<IDbAdminRefreshToken>()), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminRefreshTokenDefaultTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AdminRefreshTokensCrudLogic>>();
            IOptions<AdminRefreshTokenOptions> options = this.SetupAdminRefreshTokenOptions();

            AdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic = new AdminRefreshTokensCrudLogic(
                adminRefreshTokensCrudRepository.Object,
                null,
                null,
                logger,
                options);

            // Act
            ILogicResult result = adminRefreshTokensCrudLogic.DeleteAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminRefreshTokensCrudRepository.Verify((repository) => repository.DeleteAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminRefreshTokenNotExistsTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminRefreshTokensCrudLogic>>();
            IOptions<AdminRefreshTokenOptions> options = this.SetupAdminRefreshTokenOptions();

            AdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic = new AdminRefreshTokensCrudLogic(
                adminRefreshTokensCrudRepository.Object,
                null,
                null,
                logger,
                options);

            // Act
            ILogicResult result = adminRefreshTokensCrudLogic.DeleteAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminRefreshTokensCrudRepository.Verify((repository) => repository.DeleteAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetAdminRefreshTokenDetailDefaultTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryDefaultExists();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            var logger = Mock.Of<ILogger<AdminRefreshTokensCrudLogic>>();
            IOptions<AdminRefreshTokenOptions> options = this.SetupAdminRefreshTokenOptions();

            AdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic = new AdminRefreshTokensCrudLogic(
                adminRefreshTokensCrudRepository.Object,
                null,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            ILogicResult<IAdminRefreshTokenDetail> result = adminRefreshTokensCrudLogic.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AdminRefreshTokenDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAdminRefreshTokenDetailNotExistsTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminRefreshTokensCrudLogic>>();
            IOptions<AdminRefreshTokenOptions> options = this.SetupAdminRefreshTokenOptions();

            AdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic = new AdminRefreshTokensCrudLogic(
                adminRefreshTokensCrudRepository.Object,
                null,
                null,
                logger,
                options);

            // Act
            ILogicResult<IAdminRefreshTokenDetail> result = adminRefreshTokensCrudLogic.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryDefaultExists()
        {
            var adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDefault)).Returns(true);
            adminRefreshTokensCrudRepository.Setup(repository => repository.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault)).Returns(DbAdminRefreshTokenTest.Default());
            adminRefreshTokensCrudRepository.Setup(repository => repository.DeleteAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault));
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryEmpty()
        {
            var adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.DoesAdminRefreshTokenExist(AdminRefreshTokenTestValues.IdDefault)).Returns(false);
            adminRefreshTokensCrudRepository.Setup(repository => repository.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault)).Returns(() => null);
            adminRefreshTokensCrudRepository.Setup(repository => repository.CreateAdminRefreshToken(It.IsAny<IDbAdminRefreshToken>())).Callback((IDbAdminRefreshToken dbAdminRefreshToken) =>
            {
                DbAdminRefreshTokenTest.AssertCreated(dbAdminRefreshToken);
            });
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryAdminEmailUser()
        {
            var adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.CreateAdminRefreshToken(It.IsAny<IDbAdminRefreshToken>())).Callback((IDbAdminRefreshToken dbAdminRefreshToken) =>
            {
                DbAdminRefreshTokenTest.AssertCreatedAdminEmailUser(dbAdminRefreshToken);
            });
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryAd()
        {
            var adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.CreateAdminRefreshToken(It.IsAny<IDbAdminRefreshToken>())).Callback((IDbAdminRefreshToken dbAdminRefreshToken) =>
            {
                DbAdminRefreshTokenTest.AssertCreatedAd(dbAdminRefreshToken);
            });
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(AdminRefreshTokenTestValues.IdForCreate);
            return guidGeneration;
        }

        private Mock<IDateTimeProvider> SetupDateTimeProviderDefault()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => AdminRefreshTokenTestValues.ExpirationNow);
            return dateTimeProvider;
        }

        private IOptions<AdminRefreshTokenOptions> SetupAdminRefreshTokenOptions()
        {
            return Options.Create(new AdminRefreshTokenOptions()
            {
                RunOnInitialization = true,
                ExpirationTimeInMinutes = 60 * 12
            });
        }
    }
}