using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.Email;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Password;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    [TestClass]
    public class AdminEmailUserPasswordResetLogicTests
    {
        [TestMethod]
        public void InitializePasswordResetNotFoundTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryNotExisting();

            IBrowserInfo browserInfo = this.CreateBrowserInfo();

            AdminEmailUserPasswordResetLogic adminEmailUserPasswordResetLogic = new AdminEmailUserPasswordResetLogic(
                null,
                adminEmailUsersCrudRepository.Object,
                null,
                null,
                null,
                null,
                null,
                Mock.Of<ILogger<AdminEmailUserPasswordResetLogic>>(),
                this.SetupOptions());

            // Act
            var result = adminEmailUserPasswordResetLogic.InitializePasswordReset(AdminEmailUserTestValues.EmailDefault, browserInfo);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void InitializePasswordResetTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryExisting();
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = this.SetupAdminEmailUserPasswordResetTokenRepositoryDefault();
            Mock<IAdminEmailUserPasswordResetMailLogic> adminEmailUserPasswordResetMailLogic = this.SetupAdminEmailUserPasswordResetMailLogicDefault();
            Mock<IEmailClient> emailClient = this.SetupEmailClientDefault();
            Mock<ISHA256TokenGenerator> sha256TokenGenerator = this.SetupSHA256TokenGeneratorDefault();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();

            IBrowserInfo browserInfo = this.CreateBrowserInfo();

            AdminEmailUserPasswordResetLogic adminEmailUserPasswordResetLogic = new AdminEmailUserPasswordResetLogic(
                adminEmailUserPasswordResetTokenRepository.Object,
                adminEmailUsersCrudRepository.Object,
                adminEmailUserPasswordResetMailLogic.Object,
                emailClient.Object,
                null,
                sha256TokenGenerator.Object,
                dateTimeProvider.Object,
                Mock.Of<ILogger<AdminEmailUserPasswordResetLogic>>(),
                this.SetupOptions());

            // Act
            var result = adminEmailUserPasswordResetLogic.InitializePasswordReset(AdminEmailUserTestValues.EmailDefault, browserInfo);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
        }

        [TestMethod]
        public void ResetPasswordNotFoundExpiredTest()
        {
            // Arrange
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = this.SetupAdminEmailUserPasswordResetTokenRepositoryExpired();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();

            AdminEmailUserPasswordResetLogic adminEmailUserPasswordResetLogic = new AdminEmailUserPasswordResetLogic(
                adminEmailUserPasswordResetTokenRepository.Object,
                null,
                null,
                null,
                null,
                null,
                dateTimeProvider.Object,
                Mock.Of<ILogger<AdminEmailUserPasswordResetLogic>>(),
                this.SetupOptions());

            // Act
            var result = adminEmailUserPasswordResetLogic.ResetPassword(AdminEmailUserPasswordResetTokenTestValues.TokenDefault2, AdminEmailUserTestValues.PasswordForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void ResetPasswordNotFoundTokenTest()
        {
            // Arrange
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = this.SetupAdminEmailUserPasswordResetTokenRepositoryNotFound();

            AdminEmailUserPasswordResetLogic adminEmailUserPasswordResetLogic = new AdminEmailUserPasswordResetLogic(
                adminEmailUserPasswordResetTokenRepository.Object,
                null,
                null,
                null,
                null,
                null,
                null,
                Mock.Of<ILogger<AdminEmailUserPasswordResetLogic>>(),
                this.SetupOptions());

            // Act
            var result = adminEmailUserPasswordResetLogic.ResetPassword(AdminEmailUserPasswordResetTokenTestValues.TokenDefault, AdminEmailUserTestValues.PasswordForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void ResetPasswordTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryExisting();
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = this.SetupAdminEmailUserPasswordResetTokenRepositoryDefault();
            Mock<IBsiPasswordHasher> bsiPasswordHasher = this.SetupBsiPasswordHasherDefault();
            Mock<IDateTimeProvider> dateTimeProvider = this.SetupDateTimeProviderDefault();

            AdminEmailUserPasswordResetLogic adminEmailUserPasswordResetLogic = new AdminEmailUserPasswordResetLogic(
                adminEmailUserPasswordResetTokenRepository.Object,
                adminEmailUsersCrudRepository.Object,
                null,
                null,
                bsiPasswordHasher.Object,
                null,
                dateTimeProvider.Object,
                Mock.Of<ILogger<AdminEmailUserPasswordResetLogic>>(),
                this.SetupOptions());

            // Act
            var result = adminEmailUserPasswordResetLogic.ResetPassword(AdminEmailUserPasswordResetTokenTestValues.TokenDefault, AdminEmailUserTestValues.PasswordForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUserPasswordResetTokenRepository.Verify(repository => repository.DeleteToken(AdminEmailUserPasswordResetTokenTestValues.TokenDefault), Times.Once);
        }

        private IBrowserInfo CreateBrowserInfo()
        {
            Mock<IBrowserInfo> browserInfoMock = new Mock<IBrowserInfo>(MockBehavior.Strict);
            browserInfoMock.Setup(browserInfo => browserInfo.Browser).Returns("Browser");
            browserInfoMock.Setup(browserInfo => browserInfo.OperatingSystem).Returns("OperatingSystem");
            var browserInfo = browserInfoMock.Object;
            return browserInfo;
        }

        private Mock<IBsiPasswordHasher> SetupBsiPasswordHasherDefault()
        {
            var bsiPasswordHasher = new Mock<IBsiPasswordHasher>(MockBehavior.Strict);
            bsiPasswordHasher.Setup(service => service.HashPassword(AdminEmailUserTestValues.PasswordForUpdate))
                .Returns(new BsiPasswordHash()
                {
                    PasswordHash = AdminEmailUserTestValues.PasswordHashForUpdate,
                    Salt = AdminEmailUserTestValues.PasswordSaltForUpdate
                });
            return bsiPasswordHasher;
        }

        private Mock<IAdminEmailUserPasswordResetMailLogic> SetupAdminEmailUserPasswordResetMailLogicDefault()
        {
            Mock<IAdminEmailUserPasswordResetMailLogic> adminEmailUserPasswordResetMailLogic = new Mock<IAdminEmailUserPasswordResetMailLogic>(MockBehavior.Strict);
            adminEmailUserPasswordResetMailLogic.Setup(service => service.GetMessage(It.IsAny<IAdminEmailUserPasswordResetMailMetadata>())).Returns("Email Message");
            return adminEmailUserPasswordResetMailLogic;
        }

        private Mock<IDateTimeProvider> SetupDateTimeProviderDefault()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => AdminEmailUserPasswordResetTokenTestValues.ExpirationNow);
            return dateTimeProvider;
        }

        private Mock<IEmailClient> SetupEmailClientDefault()
        {
            Mock<IEmailClient> emailClient = new Mock<IEmailClient>(MockBehavior.Strict);
            emailClient.Setup(service => service.Send(It.IsAny<IEmail>())).Callback((IEmail email) =>
            {
                Assert.AreEqual(AdminEmailUserTestValues.EmailDefault, email.To);
                Assert.IsNotNull(email.Subject);
                Assert.IsNotNull(email.Message);
            });
            return emailClient;
        }

        private Mock<IAdminEmailUserPasswordResetTokenRepository> SetupAdminEmailUserPasswordResetTokenRepositoryDefault()
        {
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = new Mock<IAdminEmailUserPasswordResetTokenRepository>(MockBehavior.Strict);
            adminEmailUserPasswordResetTokenRepository.Setup(repository => repository.CreateToken(It.IsAny<IDbAdminEmailUserPasswordResetToken>()))
                .Callback((IDbAdminEmailUserPasswordResetToken token) =>
                {
                    DbAdminEmailUserPasswordResetTokenTest.AssertCreated(token);
                });
            adminEmailUserPasswordResetTokenRepository.Setup(repository => repository.DeleteToken(AdminEmailUserPasswordResetTokenTestValues.TokenDefault));
            adminEmailUserPasswordResetTokenRepository.Setup(repository => repository.DeleteToken(AdminEmailUserPasswordResetTokenTestValues.ExpirationNow));
            adminEmailUserPasswordResetTokenRepository
                .Setup(repository => repository.GetToken(AdminEmailUserPasswordResetTokenTestValues.TokenDefault))
                .Returns(DbAdminEmailUserPasswordResetTokenTest.Default());
            return adminEmailUserPasswordResetTokenRepository;
        }

        private Mock<IAdminEmailUserPasswordResetTokenRepository> SetupAdminEmailUserPasswordResetTokenRepositoryExpired()
        {
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = new Mock<IAdminEmailUserPasswordResetTokenRepository>(MockBehavior.Strict);
            adminEmailUserPasswordResetTokenRepository
                .Setup(repository => repository.GetToken(AdminEmailUserPasswordResetTokenTestValues.TokenDefault2))
                .Returns(DbAdminEmailUserPasswordResetTokenTest.Default2());
            return adminEmailUserPasswordResetTokenRepository;
        }

        private Mock<IAdminEmailUserPasswordResetTokenRepository> SetupAdminEmailUserPasswordResetTokenRepositoryNotFound()
        {
            Mock<IAdminEmailUserPasswordResetTokenRepository> adminEmailUserPasswordResetTokenRepository = new Mock<IAdminEmailUserPasswordResetTokenRepository>(MockBehavior.Strict);
            adminEmailUserPasswordResetTokenRepository
                .Setup(repository => repository.GetToken(AdminEmailUserPasswordResetTokenTestValues.TokenDefault))
                .Returns(() => null);
            return adminEmailUserPasswordResetTokenRepository;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryExisting()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetGlobalAdminEmailUser(AdminEmailUserTestValues.IdDefault)).Returns(DbAdminEmailUserTest.Default());
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.EmailDefault)).Returns(DbAdminEmailUserTest.Default());
            adminEmailUsersCrudRepository.Setup(repository => repository.UpdateGlobalAdminEmailUser(It.IsAny<IDbAdminEmailUser>())).Callback((IDbAdminEmailUser dbAdminEmailUser) =>
            {
                DbAdminEmailUserTest.AssertUpdatedPasswordChange(dbAdminEmailUser);
            });
            return adminEmailUsersCrudRepository;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryNotExisting()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.EmailDefault)).Returns(() => null);
            return adminEmailUsersCrudRepository;
        }

        private IOptions<AdminEmailUserPasswordResetOptions> SetupOptions()
        {
            return Options.Create(new AdminEmailUserPasswordResetOptions()
            {
                RunOnInitialization = true,
                ExpirationTimeInMinutes = 60,
                MailHomepageUrl = "MailHomepageUrl",
                MailResetPasswordUrlPrefix = "MailResetPasswordUrlPrefix",
                MailSupportUrl = "MailSupportUrl"
            });
        }

        private Mock<ISHA256TokenGenerator> SetupSHA256TokenGeneratorDefault()
        {
            Mock<ISHA256TokenGenerator> sha256TokenGenerator = new Mock<ISHA256TokenGenerator>(MockBehavior.Strict);
            sha256TokenGenerator.Setup(generator => generator.Generate()).Returns(AdminEmailUserPasswordResetTokenTestValues.TokenForCreate);
            return sha256TokenGenerator;
        }
    }
}