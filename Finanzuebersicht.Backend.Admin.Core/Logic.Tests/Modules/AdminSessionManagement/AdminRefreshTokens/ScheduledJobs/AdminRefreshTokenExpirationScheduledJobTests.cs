using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    [TestClass]
    public class AdminRefreshTokenExpirationScheduledJobTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryDefault();

            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();

            AdminRefreshTokenExpirationScheduledJob scheduledJob = new AdminRefreshTokenExpirationScheduledJob(
                adminRefreshTokensCrudRepository.Object,
                dateTimeProvider.Object,
                this.SetupOptions());

            // Act
            scheduledJob.Execute();
            adminRefreshTokensCrudRepository.Verify(repository => repository.DeleteExpiredAdminRefreshTokens(AdminRefreshTokenTestValues.ExpirationNow), Times.Once);
        }

        [TestMethod]
        public void GetDelayInSecondsTest()
        {
            // Arrange
            AdminRefreshTokenExpirationScheduledJob scheduledJob = new AdminRefreshTokenExpirationScheduledJob(
                null,
                null,
                this.SetupOptions());

            // Act
            var delayInSeconds = scheduledJob.GetDelayInSeconds();

            // Assert
            Assert.AreEqual(43200, delayInSeconds);
        }

        [TestMethod]
        public void IsExecutingOnInitializationTest()
        {
            // Arrange
            AdminRefreshTokenExpirationScheduledJob scheduledJob = new AdminRefreshTokenExpirationScheduledJob(
                null,
                null,
                this.SetupOptions());

            // Act
            bool isExecutingOnInitialization = scheduledJob.IsExecutingOnInitialization();

            // Assert
            Assert.AreEqual(true, isExecutingOnInitialization);
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryDefault()
        {
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(logic => logic.DeleteExpiredAdminRefreshTokens(AdminRefreshTokenTestValues.ExpirationNow));
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IDateTimeProvider> SetupDateTimeProviderDefault()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => AdminRefreshTokenTestValues.ExpirationNow);
            return dateTimeProvider;
        }

        private IOptions<AdminRefreshTokenOptions> SetupOptions()
        {
            return Options.Create(new AdminRefreshTokenOptions()
            {
                RunOnInitialization = true,
                ExpirationTimeInMinutes = 60 * 12
            });
        }
    }
}