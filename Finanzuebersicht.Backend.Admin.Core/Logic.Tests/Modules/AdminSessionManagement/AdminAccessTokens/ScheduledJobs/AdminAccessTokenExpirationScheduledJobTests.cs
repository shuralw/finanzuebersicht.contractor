using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminAccessTokens
{
    [TestClass]
    public class AdminAccessTokenExpirationScheduledJobTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryDefault();

            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();

            AdminAccessTokenExpirationScheduledJob scheduledJob = new AdminAccessTokenExpirationScheduledJob(
                adminAccessTokensCrudRepository.Object,
                dateTimeProvider.Object,
                this.SetupOptions());

            // Act
            scheduledJob.Execute();
            adminAccessTokensCrudRepository.Verify(repository => repository.DeleteExpiredAdminAccessTokens(AdminAccessTokenTestValues.ExpirationNow), Times.Once);
        }

        [TestMethod]
        public void GetDelayInSecondsTest()
        {
            // Arrange
            AdminAccessTokenExpirationScheduledJob scheduledJob = new AdminAccessTokenExpirationScheduledJob(
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
            AdminAccessTokenExpirationScheduledJob scheduledJob = new AdminAccessTokenExpirationScheduledJob(
                null,
                null,
                this.SetupOptions());

            // Act
            bool isExecutingOnInitialization = scheduledJob.IsExecutingOnInitialization();

            // Assert
            Assert.AreEqual(true, isExecutingOnInitialization);
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryDefault()
        {
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminAccessTokensCrudRepository.Setup(logic => logic.DeleteExpiredAdminAccessTokens(AdminAccessTokenTestValues.ExpirationNow));
            return adminAccessTokensCrudRepository;
        }

        private Mock<IDateTimeProvider> SetupDateTimeProviderDefault()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => AdminAccessTokenTestValues.ExpirationNow);
            return dateTimeProvider;
        }

        private IOptions<AdminAccessTokenOptions> SetupOptions()
        {
            return Options.Create(new AdminAccessTokenOptions()
            {
                RunOnInitialization = true,
                ExpirationTimeInMinutes = 60 * 12
            });
        }
    }
}