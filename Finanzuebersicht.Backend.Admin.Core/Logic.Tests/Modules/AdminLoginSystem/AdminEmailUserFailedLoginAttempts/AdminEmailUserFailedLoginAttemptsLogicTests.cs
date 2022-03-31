using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    [TestClass]
    public class AdminEmailUserFailedLoginAttemptsLogicTests
    {
        [TestMethod]
        public void AddFailedLoginAttemptTest()
        {
            // Arrange
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = this.SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault();

            AdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic = new AdminEmailUserFailedLoginAttemptsLogic(
                    adminEmailUserFailedLoginAttemptsCrudRepository.Object,
                    this.DateTimeProviderDefaultNow().Object,
                    this.SetupOptions());

            // Act
            adminEmailUserFailedLoginAttemptsLogic.AddFailedLoginAttempt(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId);
        }

        [TestMethod]
        public void HasAdminEmailUserTooManyFailedLoginAttemptsFalseExpiredTest()
        {
            // Arrange
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = this.SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryTest();

            AdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic = new AdminEmailUserFailedLoginAttemptsLogic(
                    adminEmailUserFailedLoginAttemptsCrudRepository.Object,
                    this.DateTimeProviderDefaultNow().Object,
                    this.SetupOptions());

            // Act
            var hasAdminEmailUserTooManyFailedLoginAttempts = adminEmailUserFailedLoginAttemptsLogic.HasAdminEmailUserTooManyFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId);

            // Assert
            Assert.IsFalse(hasAdminEmailUserTooManyFailedLoginAttempts);
        }

        [TestMethod]
        public void HasAdminEmailUserTooManyFailedLoginAttemptsFalseTooLessTest()
        {
            // Arrange
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = this.SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryTooLess();

            AdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic = new AdminEmailUserFailedLoginAttemptsLogic(
                    adminEmailUserFailedLoginAttemptsCrudRepository.Object,
                    this.DateTimeProviderDefaultNow().Object,
                    this.SetupOptions());

            // Act
            var hasAdminEmailUserTooManyFailedLoginAttempts = adminEmailUserFailedLoginAttemptsLogic.HasAdminEmailUserTooManyFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId);

            // Assert
            Assert.IsFalse(hasAdminEmailUserTooManyFailedLoginAttempts);
        }

        [TestMethod]
        public void HasAdminEmailUserTooManyFailedLoginAttemptsTrueTest()
        {
            // Arrange
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = this.SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryTooMany();

            AdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic = new AdminEmailUserFailedLoginAttemptsLogic(
                    adminEmailUserFailedLoginAttemptsCrudRepository.Object,
                    this.DateTimeProviderDefaultNow().Object,
                    this.SetupOptions());

            // Act
            var hasAdminEmailUserTooManyFailedLoginAttempts = adminEmailUserFailedLoginAttemptsLogic.HasAdminEmailUserTooManyFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId);

            // Assert
            Assert.IsTrue(hasAdminEmailUserTooManyFailedLoginAttempts);
        }

        [TestMethod]
        public void RemoveFailedLoginAttemptsDateTimeTest()
        {
            // Arrange
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = this.SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault();

            AdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic = new AdminEmailUserFailedLoginAttemptsLogic(
                    adminEmailUserFailedLoginAttemptsCrudRepository.Object,
                    this.DateTimeProviderDefaultNow().Object,
                    this.SetupOptions());

            // Act
            adminEmailUserFailedLoginAttemptsLogic.RemoveExpiredFailedLoginAttempts();

            // Assert
            adminEmailUserFailedLoginAttemptsCrudRepository.Verify(repository => repository.DeleteFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.OlderThan), Times.Once);
        }

        [TestMethod]
        public void RemoveFailedLoginAttemptsAdminEmailUserIdTest()
        {
            // Arrange
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = this.SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault();

            AdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic = new AdminEmailUserFailedLoginAttemptsLogic(
                adminEmailUserFailedLoginAttemptsCrudRepository.Object,
                null,
                this.SetupOptions());

            // Act
            adminEmailUserFailedLoginAttemptsLogic.RemoveFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId);

            // Assert
            adminEmailUserFailedLoginAttemptsCrudRepository.Verify(repository => repository.DeleteFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId), Times.Once);
        }

        private Mock<IDateTimeProvider> DateTimeProviderDefaultNow()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => AdminEmailUserFailedLoginAttemptTestValues.Now);
            return dateTimeProvider;
        }

        private Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault()
        {
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = new Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository>(MockBehavior.Strict);
            adminEmailUserFailedLoginAttemptsCrudRepository.Setup(repository => repository.CreateFailedLoginAttempt(It.IsAny<IDbAdminEmailUserFailedLoginAttempt>()))
                .Callback((IDbAdminEmailUserFailedLoginAttempt adminEmailUserFailedLoginAttempt) =>
                {
                    Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, adminEmailUserFailedLoginAttempt.AdminEmailUserId);
                    Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.Now, adminEmailUserFailedLoginAttempt.OccurredAt);
                });
            adminEmailUserFailedLoginAttemptsCrudRepository.Setup(repository => repository.DeleteFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.OlderThan));
            adminEmailUserFailedLoginAttemptsCrudRepository.Setup(repository => repository.DeleteFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId));
            return adminEmailUserFailedLoginAttemptsCrudRepository;
        }

        private Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryTest()
        {
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = new Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository>(MockBehavior.Strict);
            adminEmailUserFailedLoginAttemptsCrudRepository.Setup(repository => repository.GetFailedLoginAttempts(It.IsAny<Guid>()))
                .Returns((Guid adminEmailUserId) =>
                {
                    Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, adminEmailUserId);

                    return new List<IDbAdminEmailUserFailedLoginAttempt>()
                    {
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt1 },
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt2 },
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt4 }
                    };
                });
            return adminEmailUserFailedLoginAttemptsCrudRepository;
        }

        private Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryTooLess()
        {
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = new Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository>(MockBehavior.Strict);
            adminEmailUserFailedLoginAttemptsCrudRepository.Setup(repository => repository.GetFailedLoginAttempts(It.IsAny<Guid>()))
                .Returns((Guid adminEmailUserId) =>
                {
                    Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, adminEmailUserId);

                    return new List<IDbAdminEmailUserFailedLoginAttempt>()
                    {
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt1 },
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt2 }
                    };
                });
            return adminEmailUserFailedLoginAttemptsCrudRepository;
        }

        private Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> SetupAdminEmailUserFailedLoginAttemptsCrudRepositoryTooMany()
        {
            Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository> adminEmailUserFailedLoginAttemptsCrudRepository = new Mock<IAdminEmailUserFailedLoginAttemptsCrudRepository>(MockBehavior.Strict);
            adminEmailUserFailedLoginAttemptsCrudRepository.Setup(repository => repository.GetFailedLoginAttempts(It.IsAny<Guid>()))
                .Returns((Guid adminEmailUserId) =>
                {
                    Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, adminEmailUserId);

                    return new List<IDbAdminEmailUserFailedLoginAttempt>()
                    {
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt1 },
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt2 },
                        new DbAdminEmailUserFailedLoginAttempt() { AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserId, OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccuredAt3 }
                    };
                });
            return adminEmailUserFailedLoginAttemptsCrudRepository;
        }

        private IOptions<AdminEmailUserFailedLoginAttemptsOptions> SetupOptions()
        {
            return Options.Create(new AdminEmailUserFailedLoginAttemptsOptions()
            {
                MaxCount = AdminEmailUserFailedLoginAttemptTestValues.MaxCount,
                RunOnInitialization = AdminEmailUserFailedLoginAttemptTestValues.RunOnInitialization,
                ThresholdInMinutes = AdminEmailUserFailedLoginAttemptTestValues.ThresholdInMinutes
            });
        }
    }
}