using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    [TestClass]
    public class AdminEmailUserPasswordResetExpirationScheduledJobTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = this.SetupAdminEmailUserPasswordResetTokenRepositoryDefault();

            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();

            AdminEmailUserPasswordResetExpirationScheduledJob scheduledJob = new AdminEmailUserPasswordResetExpirationScheduledJob(
                adminEmailUserPasswordResetTokenRepository.Object,
                dateTimeProvider.Object,
                this.SetupOptions());

            // Act
            scheduledJob.Execute();
            adminEmailUserPasswordResetTokenRepository.Verify(logic => logic.DeleteToken(AdminEmailUserPasswordResetTokenTestValues.ExpirationNow), Times.Once);
        }

        [TestMethod]
        public void GetDelayInSecondsTest()
        {
            // Arrange
            AdminEmailUserPasswordResetExpirationScheduledJob scheduledJob = new AdminEmailUserPasswordResetExpirationScheduledJob(
                null,
                null,
                this.SetupOptions());

            // Act
            var delayInSeconds = scheduledJob.GetDelayInSeconds();

            // Assert
            Assert.AreEqual(1800, delayInSeconds);
        }

        [TestMethod]
        public void IsExecutingOnInitializationTest()
        {
            // Arrange
            AdminEmailUserPasswordResetExpirationScheduledJob scheduledJob = new AdminEmailUserPasswordResetExpirationScheduledJob(
                null,
                null,
                this.SetupOptions());

            // Act
            bool isExecutingOnInitialization = scheduledJob.IsExecutingOnInitialization();

            // Assert
            Assert.AreEqual(true, isExecutingOnInitialization);
        }

        private Mock<IAdminEmailUserPasswordResetTokenRepository> SetupAdminEmailUserPasswordResetTokenRepositoryDefault()
        {
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = new Mock<IAdminEmailUserPasswordResetTokenRepository>(MockBehavior.Strict);
            adminEmailUserPasswordResetTokenRepository.Setup(logic => logic.DeleteToken(AdminEmailUserPasswordResetTokenTestValues.ExpirationNow));
            return adminEmailUserPasswordResetTokenRepository;
        }

        private Mock<IDateTimeProvider> SetupDateTimeProviderDefault()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => AdminEmailUserPasswordResetTokenTestValues.ExpirationNow);
            return dateTimeProvider;
        }

        private IOptions<AdminEmailUserPasswordResetOptions> SetupOptions()
        {
            return Options.Create(new AdminEmailUserPasswordResetOptions()
            {
                RunOnInitialization = true,
                ExpirationTimeInMinutes = 30
            });
        }
    }
}