using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Password;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers
{
    [TestClass]
    public class AdminEmailUsersCrudLogicTests
    {
        [TestMethod]
        public void AddAdminEmailUserToAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = this.SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminEmailUserMembershipRepository.Object,
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUserMembershipRepository.Verify((repository) => repository.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void AddAdminEmailUserToAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = this.SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminEmailUserMembershipRepository.Object,
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminEmailUserMembershipRepository.Verify((repository) => repository.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void AddAdminEmailUserToAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = this.SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminEmailUserMembershipRepository.Object,
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminEmailUserMembershipRepository.Verify((repository) => repository.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void CreateAdminEmailUserAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult<Guid> result = adminEmailUsersCrudLogic.CreateAdminEmailUser(AdminEmailUserTestValues.EmailForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.CreateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Never);
        }

        [TestMethod]
        public void CreateAdminEmailUserDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            Mock<IBsiPasswordHasher> bsiPasswordHasher = this.SetupBsiPasswordHasherDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                bsiPasswordHasher.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = adminEmailUsersCrudLogic.CreateAdminEmailUser(AdminEmailUserTestValues.EmailForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(AdminEmailUserTestValues.IdForCreate, result.Data);
            adminEmailUsersCrudRepository.Verify((repository) => repository.CreateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminEmailUserDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                adminRefreshTokensCrudRepository.Object, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.DeleteAdminEmailUser(AdminEmailUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.DeleteAdminEmailUser(AdminEmailUserTestValues.IdDefault), Times.Once);
            adminRefreshTokensCrudRepository.Verify((repository) => repository.DeleteAdminRefreshTokensOfAdminEmailUser(AdminEmailUserTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminEmailUserNotExistsTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = this.SetupAdminRefreshTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.DeleteAdminEmailUser(AdminEmailUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.DeleteAdminEmailUser(AdminEmailUserTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetAdminEmailUserDetailDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = this.SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminEmailUserPermissionsCalculationLogic> adminEmailUserPermissionsCalculationLogic = this.SetupAdminEmailUserPermissionsCalculationLogicDefault();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                adminEmailUserMembershipRepository.Object,
                adminEmailUserPermissionsCalculationLogic.Object,
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null, // guidGenerator
                logger);

            // Act
            ILogicResult<IAdminEmailUserDetail> result = adminEmailUsersCrudLogic.GetAdminEmailUserDetail(AdminEmailUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AdminEmailUserDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAdminEmailUserDetailNotExistsTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult<IAdminEmailUserDetail> result = adminEmailUsersCrudLogic.GetAdminEmailUserDetail(AdminEmailUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetPagedAdminEmailUsersDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<IAdminEmailUser>> adminEmailUsersPagedResult = adminEmailUsersCrudLogic.GetPagedAdminEmailUsers();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, adminEmailUsersPagedResult.State);
            IAdminEmailUser[] entityResults = adminEmailUsersPagedResult.Data.Data.ToArray();
            Assert.AreEqual(2, entityResults.Length);
            AdminEmailUserTest.AssertDefault(entityResults[0]);
            AdminEmailUserTest.AssertDefault2(entityResults[1]);
        }

        [TestMethod]
        public void RemoveAdminEmailUserFromAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = this.SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminEmailUserMembershipRepository.Object,
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUserMembershipRepository.Verify((repository) => repository.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void RemoveAdminEmailUserFromAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = this.SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminEmailUserMembershipRepository.Object,
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminEmailUserMembershipRepository.Verify((repository) => repository.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void RemoveAdminEmailUserFromAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = this.SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminEmailUserMembershipRepository.Object,
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminEmailUserMembershipRepository.Verify((repository) => repository.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminEmailUserAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.UpdateAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminEmailUserDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.UpdateAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminEmailUserNotExistsTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.UpdateAdminEmailUser(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.EmailForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminEmailUserPermissionsDefaultTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExistsForPermissionUpdate();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.UpdateAdminEmailUserPermissions(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminEmailUserPermissionsGlobalAdminTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.UpdateAdminEmailUserPermissions(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.PermissionsForUpdateGlobalAdmin);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminEmailUsersCrudRepository.Verify((repository) => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminEmailUserPermissionsNotExistsTest()
        {
            // Arrange
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = this.SetupAdminEmailUsersCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminEmailUsersCrudLogic>>();

            AdminEmailUsersCrudLogic adminEmailUsersCrudLogic = new AdminEmailUsersCrudLogic(
                adminEmailUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminEmailUserMembershipRepository
                null, // adminEmailUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null, // adminRefreshTokensCrudRepository
                null, // bsiPasswordHasher
                null,
                logger);

            // Act
            ILogicResult result = adminEmailUsersCrudLogic.UpdateAdminEmailUserPermissions(AdminEmailUserTestValues.IdDefault, AdminEmailUserTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
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
            bsiPasswordHasher.Setup(service => service.HashPassword(AdminEmailUserTestValues.PasswordForCreate)).Returns((string passwort) =>
            {
                return new BsiPasswordHash()
                {
                    PasswordHash = AdminEmailUserTestValues.PasswordHashForCreate,
                    Salt = AdminEmailUserTestValues.PasswordSaltForCreate,
                };
            });

            // Das Passwort wird hier mit der AdminEmailUserId verglichen, da das Initial-Passwort vom GuidGenerator erstellt wird
            bsiPasswordHasher.Setup(service => service.HashPassword(AdminEmailUserTestValues.IdForCreate.ToString())).Returns((string passwort) =>
            {
                return new BsiPasswordHash()
                {
                    PasswordHash = AdminEmailUserTestValues.PasswordHashForCreate,
                    Salt = AdminEmailUserTestValues.PasswordSaltForCreate,
                };
            });
            return bsiPasswordHasher;
        }

        private Mock<IAdminEmailUserMembershipRepository> SetupAdminEmailUserMembershipRepositoryDefault()
        {
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = new Mock<IAdminEmailUserMembershipRepository>(MockBehavior.Strict);

            adminEmailUserMembershipRepository
                .Setup(repository => repository.GetAdminUserGroupsOfAdminEmailUser(AdminEmailUserTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default() });

            adminEmailUserMembershipRepository
                .Setup(repository => repository.AddAdminEmailUserToAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault));

            adminEmailUserMembershipRepository
                .Setup(repository => repository.RemoveAdminEmailUserFromAdminUserGroup(AdminEmailUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault));

            return adminEmailUserMembershipRepository;
        }

        private Mock<IAdminEmailUserPermissionsCalculationLogic> SetupAdminEmailUserPermissionsCalculationLogicDefault()
        {
            var adminEmailUserPermissionsCalculationLogic = new Mock<IAdminEmailUserPermissionsCalculationLogic>(MockBehavior.Strict);
            adminEmailUserPermissionsCalculationLogic.Setup(logic => logic.CalculatePermissionsForAdminEmailUser(AdminEmailUserTestValues.IdDefault))
                .Returns(AdminEmailUserTestValues.PermissionsDefault);
            return adminEmailUserPermissionsCalculationLogic;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryAlreadyExists()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.IdDefault)).Returns(DbAdminEmailUserTest.Default());
            adminEmailUsersCrudRepository.Setup(repository => repository.DoesAdminEmailUserExist(AdminEmailUserTestValues.EmailForCreate)).Returns(true);
            adminEmailUsersCrudRepository.Setup(repository => repository.DoesAdminEmailUserExist(AdminEmailUserTestValues.EmailForUpdate)).Returns(true);
            return adminEmailUsersCrudRepository;
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
                DbAdminEmailUserTest.AssertUpdatedMail(dbAdminEmailUser);
            });
            adminEmailUsersCrudRepository.Setup(repository => repository.DeleteAdminEmailUser(AdminEmailUserTestValues.IdDefault));
            return adminEmailUsersCrudRepository;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryDefaultExists()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(DbAdminUserGroupTest.Default());
            return adminUserGroupsCrudRepository;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryEmpty()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(() => null);
            return adminUserGroupsCrudRepository;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryDefaultExistsForPermissionUpdate()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.IdDefault)).Returns(DbAdminEmailUserTest.Default());
            adminEmailUsersCrudRepository.Setup(repository => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>())).Callback((IDbAdminEmailUser dbAdminEmailUser) =>
            {
                DbAdminEmailUserTest.AssertUpdatedPermission(dbAdminEmailUser);
            });
            return adminEmailUsersCrudRepository;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.IdDefault)).Returns(DbAdminEmailUserTest.Default());
            adminEmailUsersCrudRepository.Setup(repository => repository.UpdateAdminEmailUser(It.IsAny<IDbAdminEmailUser>())).Callback((IDbAdminEmailUser dbAdminEmailUser) =>
            {
                DbAdminEmailUserTest.AssertUpdatedPermissionGlobalAdmin(dbAdminEmailUser);
            });
            return adminEmailUsersCrudRepository;
        }

        private Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryEmpty()
        {
            var adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.DoesAdminEmailUserExist(AdminEmailUserTestValues.IdDefault)).Returns(false);
            adminEmailUsersCrudRepository.Setup(repository => repository.DoesAdminEmailUserExist(AdminEmailUserTestValues.EmailForCreate)).Returns(false);
            adminEmailUsersCrudRepository.Setup(repository => repository.DoesAdminEmailUserExist(AdminEmailUserTestValues.EmailForUpdate)).Returns(false);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetAdminEmailUser(AdminEmailUserTestValues.IdDefault)).Returns(() => null);
            adminEmailUsersCrudRepository.Setup(repository => repository.CreateAdminEmailUser(It.IsAny<IDbAdminEmailUser>())).Callback((IDbAdminEmailUser dbAdminEmailUser) =>
            {
                DbAdminEmailUserTest.AssertCreated(dbAdminEmailUser);
            });
            return adminEmailUsersCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(AdminEmailUserTestValues.IdForCreate);
            return guidGeneration;
        }

        private Mock<IAdminRefreshTokensCrudRepository> SetupAdminRefreshTokensCrudRepositoryEmpty()
        {
            Mock<IAdminRefreshTokensCrudRepository> adminRefreshTokensCrudRepository = new Mock<IAdminRefreshTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.DeleteAdminRefreshTokensOfAdminEmailUser(AdminEmailUserTestValues.IdDefault));
            return adminRefreshTokensCrudRepository;
        }
    }
}