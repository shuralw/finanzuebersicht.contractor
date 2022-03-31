using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserLogin;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminLoginSystem.AdminEmailUserLogin
{
    [TestClass]
    public class AdminEmailUserLoginLogicTests
    {
        [TestMethod]
        public void LoginAsAdminEmailUserDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefault();
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = this.SetupAdminEmailUserFailedLoginAttemptsLogicDefault();
            Mock<IAdminRefreshTokensCrudLogic> adminRefreshTokensCrudLogic = this.SetupAdminRefreshTokenCrudLogicDefault();
            Mock<IBsiPasswordHasher> bsiPasswordHasher = this.SetupBsiPasswordHasherDefault();
            ILogger<AdminEmailUserLoginLogic> logger = Mock.Of<ILogger<AdminEmailUserLoginLogic>>();

            AdminEmailUserLoginLogic adminEmailUserLoginLogic = new AdminEmailUserLoginLogic(
                adminEmailUsersCrudRepository.Object,
                adminEmailUserFailedLoginAttemptsLogic.Object,
                adminRefreshTokensCrudLogic.Object,
                bsiPasswordHasher.Object,
                logger);

            // Act
            ILogicResult<IAdminRefreshTokenDetail> loginAsAdminEmailUserResult = adminEmailUserLoginLogic.LoginAsAdminEmailUser(AdminEmailUserTestValues.EmailDefault, AdminEmailUserTestValues.PasswordDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, loginAsAdminEmailUserResult.State);
            adminRefreshTokensCrudLogic.Verify(logic => logic.CreateAdminRefreshTokenForAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailDefault), Times.Once);
            adminEmailUserFailedLoginAttemptsLogic.Verify(logic => logic.RemoveFailedLoginAttempts(AdminEmailUserTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void LoginAsAdminEmailUserTooManyFailedLoginAttemptsTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefault();
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = this.SetupAdminEmailUserFailedLoginAttemptsLogicTooMany();
            Mock<IAdminRefreshTokensCrudLogic> adminRefreshTokensCrudLogic = this.SetupAdminRefreshTokenCrudLogicDefault();
            Mock<IBsiPasswordHasher> bsiPasswordHasher = this.SetupBsiPasswordHasherDefault();
            ILogger<AdminEmailUserLoginLogic> logger = Mock.Of<ILogger<AdminEmailUserLoginLogic>>();

            AdminEmailUserLoginLogic adminEmailUserLoginLogic = new AdminEmailUserLoginLogic(
                adminEmailUsersCrudRepository.Object,
                adminEmailUserFailedLoginAttemptsLogic.Object,
                adminRefreshTokensCrudLogic.Object,
                bsiPasswordHasher.Object,
                logger);

            // Act
            ILogicResult<IAdminRefreshTokenDetail> loginAsAdminEmailUserResult = adminEmailUserLoginLogic.LoginAsAdminEmailUser(AdminEmailUserTestValues.EmailDefault, AdminEmailUserTestValues.PasswordDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Forbidden, loginAsAdminEmailUserResult.State);
            adminRefreshTokensCrudLogic.Verify(logic => logic.CreateAdminRefreshTokenForAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailDefault), Times.Never);
        }

        [TestMethod]
        public void LoginAsAdminEmailUserUserNotFoundTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = this.SetupAdminEmailUserFailedLoginAttemptsLogicDefault();
            Mock<IAdminRefreshTokensCrudLogic> adminRefreshTokensCrudLogic = this.SetupAdminRefreshTokenCrudLogicDefault();
            Mock<IBsiPasswordHasher> bsiPasswordHasher = this.SetupBsiPasswordHasherDefault();
            ILogger<AdminEmailUserLoginLogic> logger = Mock.Of<ILogger<AdminEmailUserLoginLogic>>();

            AdminEmailUserLoginLogic adminEmailUserLoginLogic = new AdminEmailUserLoginLogic(
                adminEmailUsersCrudRepository.Object,
                adminEmailUserFailedLoginAttemptsLogic.Object,
                adminRefreshTokensCrudLogic.Object,
                bsiPasswordHasher.Object,
                logger);

            // Act
            ILogicResult<IAdminRefreshTokenDetail> loginAsAdminEmailUserResult = adminEmailUserLoginLogic.LoginAsAdminEmailUser(AdminEmailUserTestValues.EmailDefault, AdminEmailUserTestValues.PasswordDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, loginAsAdminEmailUserResult.State);
            adminRefreshTokensCrudLogic.Verify(logic => logic.CreateAdminRefreshTokenForAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailDefault), Times.Never);
        }

        [TestMethod]
        public void LoginAsAdminEmailUserWrongPasswordTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefault();
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = this.SetupAdminEmailUserFailedLoginAttemptsLogicDefault();
            Mock<IAdminRefreshTokensCrudLogic> adminRefreshTokensCrudLogic = this.SetupAdminRefreshTokenCrudLogicDefault();
            Mock<IBsiPasswordHasher> bsiPasswordHasher = this.SetupBsiPasswordHasherFail();
            ILogger<AdminEmailUserLoginLogic> logger = Mock.Of<ILogger<AdminEmailUserLoginLogic>>();

            AdminEmailUserLoginLogic adminEmailUserLoginLogic = new AdminEmailUserLoginLogic(
                adminEmailUsersCrudRepository.Object,
                adminEmailUserFailedLoginAttemptsLogic.Object,
                adminRefreshTokensCrudLogic.Object,
                bsiPasswordHasher.Object,
                logger);

            // Act
            ILogicResult<IAdminRefreshTokenDetail> loginAsAdminEmailUserResult = adminEmailUserLoginLogic.LoginAsAdminEmailUser(AdminEmailUserTestValues.EmailDefault, AdminEmailUserTestValues.PasswordDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, loginAsAdminEmailUserResult.State);
            adminRefreshTokensCrudLogic.Verify(logic => logic.CreateAdminRefreshTokenForAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailDefault), Times.Never);
            adminEmailUserFailedLoginAttemptsLogic.Verify(logic => logic.AddFailedLoginAttempt(AdminEmailUserTestValues.IdDefault), Times.Once);
        }

        private Mock<IBsiPasswordHasher> SetupBsiPasswordHasherDefault()
        {
            var bsiPasswordHasher = new Mock<IBsiPasswordHasher>(MockBehavior.Strict);
            bsiPasswordHasher
                .Setup(service => service.ComparePasswords(AdminEmailUserTestValues.PasswordDefault, AdminEmailUserTestValues.PasswordHashDefault, AdminEmailUserTestValues.PasswordSaltDefault))
                .Returns(true);
            return bsiPasswordHasher;
        }

        private Mock<IBsiPasswordHasher> SetupBsiPasswordHasherFail()
        {
            Mock<IBsiPasswordHasher> bsiPasswordHasher = new Mock<IBsiPasswordHasher>(MockBehavior.Strict);
            bsiPasswordHasher
                .Setup(service => service.ComparePasswords(AdminEmailUserTestValues.PasswordDefault, AdminEmailUserTestValues.PasswordHashDefault, AdminEmailUserTestValues.PasswordSaltDefault))
                .Returns(false);
            return bsiPasswordHasher;
        }

        private Mock<IAdminEmailUserFailedLoginAttemptsLogic> SetupAdminEmailUserFailedLoginAttemptsLogicDefault()
        {
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = new Mock<IAdminEmailUserFailedLoginAttemptsLogic>(MockBehavior.Strict);
            adminEmailUserFailedLoginAttemptsLogic.Setup(logic => logic.HasAdminEmailUserTooManyFailedLoginAttempts(AdminEmailUserTestValues.IdDefault)).Returns(false);
            adminEmailUserFailedLoginAttemptsLogic.Setup(logic => logic.AddFailedLoginAttempt(AdminEmailUserTestValues.IdDefault));
            adminEmailUserFailedLoginAttemptsLogic.Setup(logic => logic.RemoveFailedLoginAttempts(AdminEmailUserTestValues.IdDefault));
            return adminEmailUserFailedLoginAttemptsLogic;
        }

        private Mock<IAdminEmailUserFailedLoginAttemptsLogic> SetupAdminEmailUserFailedLoginAttemptsLogicTooMany()
        {
            Mock<IAdminEmailUserFailedLoginAttemptsLogic> adminEmailUserFailedLoginAttemptsLogic = new Mock<IAdminEmailUserFailedLoginAttemptsLogic>(MockBehavior.Strict);
            adminEmailUserFailedLoginAttemptsLogic.Setup(logic => logic.HasAdminEmailUserTooManyFailedLoginAttempts(AdminEmailUserTestValues.IdDefault)).Returns(true);
            return adminEmailUserFailedLoginAttemptsLogic;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryDefault()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.EmailDefault)).Returns(DbAdminEmailUserTest.Default());
            return adminEmailUsersCrudRepository;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryEmpty()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.EmailDefault)).Returns(() => null);
            return adminEmailUsersCrudRepository;
        }

        private Mock<IAdminRefreshTokensCrudLogic> SetupAdminRefreshTokenCrudLogicDefault()
        {
            Mock<IAdminRefreshTokensCrudLogic> adminRefreshTokensCrudLogic = new Mock<IAdminRefreshTokensCrudLogic>(MockBehavior.Strict);

            adminRefreshTokensCrudLogic
                .Setup(logic => logic.CreateAdminRefreshTokenForAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailDefault)).Returns(AdminRefreshTokenTestValues.IdDefault);

            adminRefreshTokensCrudLogic
                .Setup(logic => logic.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault))
                .Returns(LogicResult<IAdminRefreshTokenDetail>.Ok(AdminRefreshTokenDetailTest.Default()));

            return adminRefreshTokensCrudLogic;
        }
    }
}