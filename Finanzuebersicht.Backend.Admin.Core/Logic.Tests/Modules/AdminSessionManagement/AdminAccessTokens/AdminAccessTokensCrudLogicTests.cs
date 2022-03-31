using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    [TestClass]
    public class AdminAccessTokensCrudLogicTests
    {
        [TestMethod]
        public void CreateAdminAccessTokenFromAdminRefreshTokenForCreateAdTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryForAd();
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryForCreateAd();
            Mock<IAdPermissionsCalculationLogic> adPermissionsCalculationLogic = this.SetupAdPermissionsCalculationLogicDefault();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminAccessTokensCrudLogic>>();
            IOptions<AdminAccessTokenOptions> options = this.SetupAdminAccessTokenOptions();

            AdminAccessTokensCrudLogic adminAccessTokensCrudLogic = new AdminAccessTokensCrudLogic(
                adminAccessTokensCrudRepository.Object,
                adminRefreshTokensCrudRepository.Object,
                null,
                adPermissionsCalculationLogic.Object,
                guidGenerator.Object,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            ILogicResult<IAdminAccessToken> adminAccessTokenResult = adminAccessTokensCrudLogic.CreateAdminAccessTokenFromAdminRefreshToken(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, adminAccessTokenResult.State);
            AdminAccessTokenTest.AssertCreatedForAd(adminAccessTokenResult.Data);
            adminAccessTokensCrudRepository.Verify((repository) => repository.CreateAdminAccessToken(It.IsAny<IDbAdminAccessToken>()), Times.Once);
        }

        [TestMethod]
        public void CreateAdminAccessTokenFromAdminRefreshTokenForCreateEmailTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryForEmail();
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryForCreateEmail();
            Mock<IAdminEmailUserPermissionsCalculationLogic> adminEmailUserPermissionsCalculationLogic = this.SetupAdminEmailUserPermissionsCalculationLogicDefault();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminAccessTokensCrudLogic>>();
            IOptions<AdminAccessTokenOptions> options = this.SetupAdminAccessTokenOptions();

            AdminAccessTokensCrudLogic adminAccessTokensCrudLogic = new AdminAccessTokensCrudLogic(
                adminAccessTokensCrudRepository.Object,
                adminRefreshTokensCrudRepository.Object,
                adminEmailUserPermissionsCalculationLogic.Object,
                null,
                guidGenerator.Object,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            ILogicResult<IAdminAccessToken> adminAccessTokenResult = adminAccessTokensCrudLogic.CreateAdminAccessTokenFromAdminRefreshToken(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, adminAccessTokenResult.State);
            AdminAccessTokenTest.AssertCreatedForEmail(adminAccessTokenResult.Data);
            adminAccessTokensCrudRepository.Verify((repository) => repository.CreateAdminAccessToken(It.IsAny<IDbAdminAccessToken>()), Times.Once);
        }

        [TestMethod]
        public void CreateAdminAccessTokenFromAdminRefreshTokenEmptyTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryEmpty();
            Mock<IAdminEmailUserPermissionsCalculationLogic> adminEmailUserPermissionsCalculationLogic = this.SetupAdminEmailUserPermissionsCalculationLogicDefault();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminAccessTokensCrudLogic>>();
            IOptions<AdminAccessTokenOptions> options = this.SetupAdminAccessTokenOptions();

            AdminAccessTokensCrudLogic adminAccessTokensCrudLogic = new AdminAccessTokensCrudLogic(
                adminAccessTokensCrudRepository.Object,
                adminRefreshTokensCrudRepository.Object,
                adminEmailUserPermissionsCalculationLogic.Object,
                null,
                guidGenerator.Object,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            ILogicResult<IAdminAccessToken> adminAccessTokenResult = adminAccessTokensCrudLogic.CreateAdminAccessTokenFromAdminRefreshToken(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, adminAccessTokenResult.State);
            adminAccessTokensCrudRepository.Verify((repository) => repository.CreateAdminAccessToken(It.IsAny<IDbAdminAccessToken>()), Times.Never);
        }

        [TestMethod]
        public void GetAdminAccessTokenDefaultTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryDefaultExists();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            var logger = Mock.Of<ILogger<AdminAccessTokensCrudLogic>>();
            IOptions<AdminAccessTokenOptions> options = this.SetupAdminAccessTokenOptions();

            AdminAccessTokensCrudLogic adminAccessTokensCrudLogic = new AdminAccessTokensCrudLogic(
                adminAccessTokensCrudRepository.Object,
                null,
                null,
                null,
                null,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            ILogicResult<IAdminAccessToken> result = adminAccessTokensCrudLogic.GetAdminAccessToken(AdminAccessTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AdminAccessTokenTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAdminAccessTokenDetailDefaultTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryDefaultExists();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();
            var logger = Mock.Of<ILogger<AdminAccessTokensCrudLogic>>();
            IOptions<AdminAccessTokenOptions> options = this.SetupAdminAccessTokenOptions();

            AdminAccessTokensCrudLogic adminAccessTokensCrudLogic = new AdminAccessTokensCrudLogic(
                adminAccessTokensCrudRepository.Object,
                null,
                null,
                null,
                null,
                dateTimeProvider.Object,
                logger,
                options);

            // Act
            ILogicResult<IAdminAccessTokenDetail> result = adminAccessTokensCrudLogic.GetAdminAccessTokenDetail(AdminAccessTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AdminAccessTokenDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAdminAccessTokenDetailNotExistsTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAccessTokensCrudLogic>>();
            IOptions<AdminAccessTokenOptions> options = this.SetupAdminAccessTokenOptions();

            AdminAccessTokensCrudLogic adminAccessTokensCrudLogic = new AdminAccessTokensCrudLogic(
                adminAccessTokensCrudRepository.Object,
                null,
                null,
                null,
                null,
                null,
                logger,
                options);

            // Act
            ILogicResult<IAdminAccessTokenDetail> result = adminAccessTokensCrudLogic.GetAdminAccessTokenDetail(AdminAccessTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetAdminAccessTokenNotExistsTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAccessTokensCrudLogic>>();
            IOptions<AdminAccessTokenOptions> options = this.SetupAdminAccessTokenOptions();

            AdminAccessTokensCrudLogic adminAccessTokensCrudLogic = new AdminAccessTokensCrudLogic(
                adminAccessTokensCrudRepository.Object,
                null,
                null,
                null,
                null,
                null,
                logger,
                options);

            // Act
            ILogicResult<IAdminAccessToken> result = adminAccessTokensCrudLogic.GetAdminAccessToken(AdminAccessTokenTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        private IOptions<AdminAccessTokenOptions> SetupAdminAccessTokenOptions()
        {
            return Options.Create(new AdminAccessTokenOptions()
            {
                RunOnInitialization = true,
                ExpirationTimeInMinutes = 60 * 12
            });
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryDefaultExists()
        {
            var adminAccessTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminAccessTokensCrudRepository.Setup(repository => repository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDefault)).Returns(true);
            adminAccessTokensCrudRepository.Setup(repository => repository.GetAdminAccessToken(AdminAccessTokenTestValues.IdDefault)).Returns(DbAdminAccessTokenTest.Default());
            adminAccessTokensCrudRepository.Setup(repository => repository.DeleteAdminAccessToken(AdminAccessTokenTestValues.IdDefault));
            return adminAccessTokensCrudRepository;
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryEmpty()
        {
            var adminAccessTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminAccessTokensCrudRepository.Setup(repository => repository.DoesAdminAccessTokenExist(AdminAccessTokenTestValues.IdDefault)).Returns(false);
            adminAccessTokensCrudRepository.Setup(repository => repository.GetAdminAccessToken(AdminAccessTokenTestValues.IdDefault)).Returns(() => null);
            adminAccessTokensCrudRepository.Setup(repository => repository.CreateAdminAccessToken(It.IsAny<IDbAdminAccessToken>())).Callback((IDbAdminAccessToken dbAdminAccessToken) =>
            {
                DbAdminAccessTokenTest.AssertCreated(dbAdminAccessToken);
            });
            return adminAccessTokensCrudRepository;
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryForEmail()
        {
            var adminAccessTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminAccessTokensCrudRepository.Setup(repository => repository.CreateAdminAccessToken(It.IsAny<IDbAdminAccessToken>())).Callback((IDbAdminAccessToken dbAdminAccessToken) =>
            {
                DbAdminAccessTokenTest.AssertCreatedForEmail(dbAdminAccessToken);
            });
            return adminAccessTokensCrudRepository;
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryForAd()
        {
            var adminAccessTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminAccessTokensCrudRepository.Setup(repository => repository.CreateAdminAccessToken(It.IsAny<IDbAdminAccessToken>())).Callback((IDbAdminAccessToken dbAdminAccessToken) =>
            {
                DbAdminAccessTokenTest.AssertCreatedForAd(dbAdminAccessToken);
            });
            return adminAccessTokensCrudRepository;
        }

        private Mock<IAdPermissionsCalculationLogic> SetupAdPermissionsCalculationLogicDefault()
        {
            var adPermissionsCalculationLogic = new Mock<IAdPermissionsCalculationLogic>(MockBehavior.Strict);
            adPermissionsCalculationLogic
                .Setup(logic => logic.CalculateStrictPermissionsForAd(AdminAccessTokenTestValues.AdminAdUserIdForCreate, AdminAccessTokenTestValues.AdminAdGroupIdsForCreate))
                .Returns(AdminAccessTokenTestValues.CachedPermissionsForCreate);
            return adPermissionsCalculationLogic;
        }

        private Mock<IDateTimeProvider> SetupDateTimeProviderDefault()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => AdminAccessTokenTestValues.ExpirationNow);
            return dateTimeProvider;
        }

        private Mock<IAdminEmailUserPermissionsCalculationLogic> SetupAdminEmailUserPermissionsCalculationLogicDefault()
        {
            var adminEmailUserPermissionsCalculationLogic = new Mock<IAdminEmailUserPermissionsCalculationLogic>(MockBehavior.Strict);
            adminEmailUserPermissionsCalculationLogic
                .Setup(logic => logic.CalculateStrictPermissionsForAdminEmailUser(AdminAccessTokenTestValues.AdminEmailUserIdForCreate))
                .Returns(AdminAccessTokenTestValues.CachedPermissionsForCreate);
            return adminEmailUserPermissionsCalculationLogic;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(AdminAccessTokenTestValues.IdForCreate);
            return guidGeneration;
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryForCreateAd()
        {
            var adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.GetAdminRefreshToken(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate)).Returns(DbAdminRefreshTokenTest.ForCreateAd());
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryForCreateEmail()
        {
            var adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.GetAdminRefreshToken(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate)).Returns(DbAdminRefreshTokenTest.ForCreateEmail());
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryEmpty()
        {
            var adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.GetAdminRefreshToken(AdminAccessTokenTestValues.AdminRefreshTokenIdForCreate)).Returns(() => null);
            return adminRefreshTokensCrudRepository;
        }
    }
}