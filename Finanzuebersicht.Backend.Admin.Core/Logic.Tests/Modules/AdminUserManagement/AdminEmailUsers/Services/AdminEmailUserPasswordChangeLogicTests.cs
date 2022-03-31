using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Password;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    [TestClass]
    public class AdminEmailUserPasswordChangeLogicTests
    {
        [TestMethod]
        public void ChangePasswordDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            Mock<ISessionContext> sessionContext = this.SetupSessionContextDefault();
            Mock<IBsiPasswordHasher> bsiPasswortHasher = this.SetupBsiPasswordHasherDefault();
            var logger = Mock.Of<ILogger<AdminEmailUserPasswordChangeLogic>>();

            AdminEmailUserPasswordChangeLogic adminEmailUserPasswordChangeLogic = new AdminEmailUserPasswordChangeLogic(
                adminEmailUsersCrudRepository.Object,
                sessionContext.Object,
                bsiPasswortHasher.Object,
                logger);

            // Act
            ILogicResult result = adminEmailUserPasswordChangeLogic
                .ChangePassword(AdminEmailUserTestValues.PasswordDefault, AdminEmailUserTestValues.PasswordForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Once);
        }

        [TestMethod]
        public void ChangePasswordForbiddenTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            Mock<ISessionContext> sessionContext = this.SetupSessionContextForbidden();
            Mock<IBsiPasswordHasher> bsiPasswortHasher = this.SetupBsiPasswordHasherDefault();
            var logger = Mock.Of<ILogger<AdminEmailUserPasswordChangeLogic>>();

            AdminEmailUserPasswordChangeLogic adminEmailUserPasswordChangeLogic = new AdminEmailUserPasswordChangeLogic(
                adminEmailUsersCrudRepository.Object,
                sessionContext.Object,
                bsiPasswortHasher.Object,
                logger);

            // Act
            ILogicResult result = adminEmailUserPasswordChangeLogic
                .ChangePassword(AdminEmailUserTestValues.PasswordDefault, AdminEmailUserTestValues.PasswordForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Forbidden, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Never);
        }

        [TestMethod]
        public void ChangePasswordForbiddenOldPasswordTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            Mock<ISessionContext> sessionContext = this.SetupSessionContextDefault();
            Mock<IBsiPasswordHasher> bsiPasswortHasher = this.SetupBsiPasswordHasherFails();
            var logger = Mock.Of<ILogger<AdminEmailUserPasswordChangeLogic>>();

            AdminEmailUserPasswordChangeLogic adminEmailUserPasswordChangeLogic = new AdminEmailUserPasswordChangeLogic(
                adminEmailUsersCrudRepository.Object,
                sessionContext.Object,
                bsiPasswortHasher.Object,
                logger);

            // Act
            ILogicResult result = adminEmailUserPasswordChangeLogic
                .ChangePassword(AdminEmailUserTestValues.PasswordDefault, AdminEmailUserTestValues.PasswordForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Forbidden, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Never);
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryEmpty()
        {
            Mock<IAdminAccessTokensCrudRepository> adminRefreshTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.DeleteAdminAccessTokensOfAdminEmailUser(AdminEmailUserTestValues.IdDefault));
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IBsiPasswordHasher> SetupBsiPasswordHasherDefault()
        {
            var bsiPasswordHasher = new Mock<IBsiPasswordHasher>(MockBehavior.Strict);
            bsiPasswordHasher.Setup(service => service.ComparePasswords(AdminEmailUserTestValues.PasswordDefault, AdminEmailUserTestValues.PasswordHashDefault, AdminEmailUserTestValues.PasswordSaltDefault)).Returns(true);
            bsiPasswordHasher.Setup(service => service.HashPassword(AdminEmailUserTestValues.PasswordForUpdate)).Returns((string passwort) =>
            {
                return new BsiPasswordHash()
                {
                    PasswordHash = AdminEmailUserTestValues.PasswordHashForUpdate,
                    Salt = AdminEmailUserTestValues.PasswordSaltForUpdate,
                };
            });
            return bsiPasswordHasher;
        }

        private Mock<IBsiPasswordHasher> SetupBsiPasswordHasherFails()
        {
            var bsiPasswordHasher = new Mock<IBsiPasswordHasher>(MockBehavior.Strict);
            bsiPasswordHasher.Setup(service => service.ComparePasswords(AdminEmailUserTestValues.PasswordDefault, AdminEmailUserTestValues.PasswordHashDefault, AdminEmailUserTestValues.PasswordSaltDefault)).Returns(false);
            return bsiPasswordHasher;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryDefaultExists()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.DoesAdminEmailUserExist(AdminEmailUserTestValues.IdDefault)).Returns(true);
            adminEmailUsersCrudRepository.Setup(repository => repository.DoesAdminEmailUserExist(AdminEmailUserTestValues.EmailForUpdate)).Returns(false);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.IdDefault)).Returns(DbAdminEmailUserTest.Default());
            adminEmailUsersCrudRepository.Setup(repository => repository.GetPagedAdminEmailUsers()).Returns(DbAdminEmailUserTest.ForPaged());
            adminEmailUsersCrudRepository.Setup(repository => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>())).Callback((IDbAdminEmailUser dbAdminEmailUser) =>
            {
                DbAdminEmailUserTest.AssertUpdatedPasswordChange(dbAdminEmailUser);
            });
            adminEmailUsersCrudRepository.Setup(repository => repository.DeleteAdminEmailUser(AdminEmailUserTestValues.IdDefault));
            return adminEmailUsersCrudRepository;
        }

        private Mock<ISessionContext> SetupSessionContextDefault()
        {
            var sessionContext = new Mock<ISessionContext>(MockBehavior.Strict);
            sessionContext.Setup(context => context.AdminEmailUserId).Returns(AdminEmailUserTestValues.IdDefault);
            return sessionContext;
        }

        private Mock<ISessionContext> SetupSessionContextForbidden()
        {
            var sessionContext = new Mock<ISessionContext>(MockBehavior.Strict);
            sessionContext.Setup(context => context.AdminEmailUserId).Returns(() => null);
            return sessionContext;
        }
    }
}