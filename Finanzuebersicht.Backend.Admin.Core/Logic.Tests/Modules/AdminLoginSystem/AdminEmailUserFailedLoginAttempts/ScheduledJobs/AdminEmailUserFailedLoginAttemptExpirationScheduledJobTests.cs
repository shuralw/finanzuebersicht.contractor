using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    [TestClass]
    public class AdminEmailUserFailedLoginAttemptExpirationScheduledJobTests
    {
        public static readonly bool RunOnInitialization = true;
        public static readonly int ThresholdInMinutes = 30;

        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = this.SetupAdminEmailUserFailedLoginAttemptsLogicDefault();

            AdminEmailUserFailedLoginAttemptsExpirationScheduledJob scheduledJob = new AdminEmailUserFailedLoginAttemptsExpirationScheduledJob(
                adminEmailUserFailedLoginAttemptsLogic.Object,
                this.SetupOptions());

            // Act
            scheduledJob.Execute();

            // Assert
            adminEmailUserFailedLoginAttemptsLogic.Verify(logic => logic.RemoveExpiredFailedLoginAttempts(), Times.Once);
        }

        [TestMethod]
        public void GetDelayInSecondsTest()
        {
            // Arrange
            AdminEmailUserFailedLoginAttemptsExpirationScheduledJob scheduledJob = new AdminEmailUserFailedLoginAttemptsExpirationScheduledJob(
                null,
                this.SetupOptions());

            // Act
            int delayInSeconds = scheduledJob.GetDelayInSeconds();

            // Assert
            Assert.AreEqual(1800, delayInSeconds);
        }

        [TestMethod]
        public void IsExecutingOnInitializationTest()
        {
            // Arrange
            AdminEmailUserFailedLoginAttemptsExpirationScheduledJob scheduledJob = new AdminEmailUserFailedLoginAttemptsExpirationScheduledJob(
                null,
                this.SetupOptions());

            // Act
            bool isExecutingOnInitialization = scheduledJob.IsExecutingOnInitialization();

            // Assert
            Assert.AreEqual(RunOnInitialization, isExecutingOnInitialization);
        }

        private Mock<IAdminEmailUserFailedLoginAttemptsLogic> SetupAdminEmailUserFailedLoginAttemptsLogicDefault()
        {
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = new Mock<IAdminEmailUserFailedLoginAttemptsLogic>(MockBehavior.Strict);
            adminEmailUserFailedLoginAttemptsLogic.Setup(logic => logic.RemoveExpiredFailedLoginAttempts());
            return adminEmailUserFailedLoginAttemptsLogic;
        }

        private IOptions<AdminEmailUserFailedLoginAttemptsOptions> SetupOptions()
        {
            return Options.Create(new AdminEmailUserFailedLoginAttemptsOptions()
            {
                RunOnInitialization = RunOnInitialization,
                ThresholdInMinutes = ThresholdInMinutes
            });
        }
    }
}