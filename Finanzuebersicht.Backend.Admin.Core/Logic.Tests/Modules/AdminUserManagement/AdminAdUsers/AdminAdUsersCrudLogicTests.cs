using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers
{
    [TestClass]
    public class AdminAdUsersCrudLogicTests
    {
        [TestMethod]
        public void AddAdminAdUserToAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdUserMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdUserMembershipRepository.Verify((repository) => repository.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void AddAdminAdUserToAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryEmpty();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdUserMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdUserMembershipRepository.Verify((repository) => repository.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void AddAdminAdUserToAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdUserMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdUserMembershipRepository.Verify((repository) => repository.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void CreateAdminAdUserAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<Guid> result = adminAdUsersCrudLogic.CreateAdminAdUser(AdminAdUserTestValues.DnForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.CreateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Never);
        }

        [TestMethod]
        public void CreateAdminAdUserDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryEmpty();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = adminAdUsersCrudLogic.CreateAdminAdUser(AdminAdUserTestValues.DnForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(AdminAdUserTestValues.IdForCreate, result.Data);
            adminAdUsersCrudRepository.Verify((repository) => repository.CreateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminAdUserDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.DeleteAdminAdUser(AdminAdUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.DeleteAdminAdUser(AdminAdUserTestValues.IdDefault), Times.Once);
            adminAccessTokensCrudRepository.Verify((repository) => repository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups(), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminAdUserNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.DeleteAdminAdUser(AdminAdUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.DeleteAdminAdUser(AdminAdUserTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetAdminAdUserDetailDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdPermissionsCalculationLogic> adminAdUserPermissionsCalculationLogic = this.SetupAdPermissionsCalculationLogicDefault();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                adminAdUserMembershipRepository.Object,
                adminAdUserPermissionsCalculationLogic.Object,
                null, // adminAccessTokensCrudRepository
                null, // guidGenerator
                logger);

            // Act
            ILogicResult<IAdminAdUserDetail> result = adminAdUsersCrudLogic.GetAdminAdUserDetail(AdminAdUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AdminAdUserDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAdminAdUserDetailNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<IAdminAdUserDetail> result = adminAdUsersCrudLogic.GetAdminAdUserDetail(AdminAdUserTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetPagedAdminAdUsersDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adminAdUserPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<IAdminAdUser>> adminAdUsersPagedResult = adminAdUsersCrudLogic.GetPagedAdminAdUsers();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, adminAdUsersPagedResult.State);
            IAdminAdUser[] entityResults = adminAdUsersPagedResult.Data.Data.ToArray();
            Assert.AreEqual(2, entityResults.Length);
            AdminAdUserTest.AssertDefault(entityResults[0]);
            AdminAdUserTest.AssertDefault2(entityResults[1]);
        }

        [TestMethod]
        public void RemoveAdminAdUserFromAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdUserMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdUserMembershipRepository.Verify((repository) => repository.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void RemoveAdminAdUserFromAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryEmpty();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdUserMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdUserMembershipRepository.Verify((repository) => repository.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void RemoveAdminAdUserFromAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdUserMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdUserMembershipRepository.Verify((repository) => repository.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminAdUserAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.UpdateAdminAdUser(AdminAdUserTestValues.IdDefault, AdminAdUserTestValues.DnForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminAdUserDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.UpdateAdminAdUser(AdminAdUserTestValues.IdDefault, AdminAdUserTestValues.DnForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminAdUserNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.UpdateAdminAdUser(AdminAdUserTestValues.IdDefault, AdminAdUserTestValues.DnForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminAdUserPermissionsDefaultTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExistsForPermissionUpdate();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.UpdateAdminAdUserPermissions(AdminAdUserTestValues.IdDefault, AdminAdUserTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminAdUserPermissionsGlobalAdminTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.UpdateAdminAdUserPermissions(AdminAdUserTestValues.IdDefault, AdminAdUserTestValues.PermissionsForUpdateGlobalAdmin);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminAdUserPermissionsNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdUsersCrudLogic>>();

            AdminAdUsersCrudLogic adminAdUsersCrudLogic = new AdminAdUsersCrudLogic(
                adminAdUsersCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdUserMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdUsersCrudLogic.UpdateAdminAdUserPermissions(AdminAdUserTestValues.IdDefault, AdminAdUserTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdUsersCrudRepository.Verify((repository) => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>()), Times.Never);
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryEmpty()
        {
            Mock<IAdminAccessTokensCrudRepository> adminRefreshTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups());
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminAdUserMembershipRepository> SetupAdminAdUserMembershipRepositoryDefault()
        {
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = new Mock<IAdminAdUserMembershipRepository>(MockBehavior.Strict);

            adminAdUserMembershipRepository
                .Setup(repository => repository.GetAdminUserGroupsOfAdminAdUser(AdminAdUserTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default() });

            adminAdUserMembershipRepository
                .Setup(repository => repository.AddAdminAdUserToAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault));

            adminAdUserMembershipRepository
                .Setup(repository => repository.RemoveAdminAdUserFromAdminUserGroup(AdminAdUserTestValues.IdDefault, AdminUserGroupTestValues.IdDefault));

            return adminAdUserMembershipRepository;
        }

        private Mock<IAdPermissionsCalculationLogic> SetupAdPermissionsCalculationLogicDefault()
        {
            var adminAdUserPermissionsCalculationLogic = new Mock<IAdPermissionsCalculationLogic>(MockBehavior.Strict);
            adminAdUserPermissionsCalculationLogic
                .Setup(logic => logic.CalculatePermissionsForAd(It.IsAny<Guid?>(), It.IsAny<IEnumerable<Guid>>()))
                .Returns((Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds) =>
                {
                    Assert.AreEqual(AdminAdUserTestValues.IdDefault, adminAdUserId);
                    Assert.IsFalse(adminAdGroupIds.Any());
                    return AdminAdUserTestValues.PermissionsDefault;
                });
            return adminAdUserPermissionsCalculationLogic;
        }

        private Mock<IAdminAdUsersCrudRepository> SetupAdminAdUsersCrudRepositoryAlreadyExists()
        {
            var adminAdUsersCrudRepository = new Mock<IAdminAdUsersCrudRepository>(MockBehavior.Strict);
            adminAdUsersCrudRepository.Setup(repository => repository.GetAdminAdUser(AdminAdUserTestValues.IdDefault)).Returns(DbAdminAdUserTest.Default());
            adminAdUsersCrudRepository.Setup(repository => repository.DoesAdminAdUserExist(AdminAdUserTestValues.DnForCreate)).Returns(true);
            adminAdUsersCrudRepository.Setup(repository => repository.DoesAdminAdUserExist(AdminAdUserTestValues.DnForUpdate)).Returns(true);
            return adminAdUsersCrudRepository;
        }

        private Mock<IAdminAdUsersCrudRepository> SetupAdminAdUsersCrudRepositoryDefaultExists()
        {
            var adminAdUsersCrudRepository = new Mock<IAdminAdUsersCrudRepository>(MockBehavior.Strict);
            adminAdUsersCrudRepository.Setup(repository => repository.DoesAdminAdUserExist(AdminAdUserTestValues.DnForUpdate)).Returns(false);
            adminAdUsersCrudRepository.Setup(repository => repository.GetAdminAdUser(AdminAdUserTestValues.IdDefault)).Returns(DbAdminAdUserTest.Default());
            adminAdUsersCrudRepository.Setup(repository => repository.GetPagedAdminAdUsers()).Returns(DbAdminAdUserTest.ForPaged());
            adminAdUsersCrudRepository.Setup(repository => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>())).Callback((IDbAdminAdUser dbAdminAdUser) =>
            {
                DbAdminAdUserTest.AssertUpdatedMail(dbAdminAdUser);
            });
            adminAdUsersCrudRepository.Setup(repository => repository.DeleteAdminAdUser(AdminAdUserTestValues.IdDefault));
            return adminAdUsersCrudRepository;
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

        private Mock<IAdminAdUsersCrudRepository> SetupAdminAdUsersCrudRepositoryDefaultExistsForPermissionUpdate()
        {
            var adminAdUsersCrudRepository = new Mock<IAdminAdUsersCrudRepository>(MockBehavior.Strict);
            adminAdUsersCrudRepository.Setup(repository => repository.GetAdminAdUser(AdminAdUserTestValues.IdDefault)).Returns(DbAdminAdUserTest.Default());
            adminAdUsersCrudRepository.Setup(repository => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>())).Callback((IDbAdminAdUser dbAdminAdUser) =>
            {
                DbAdminAdUserTest.AssertUpdatedPermission(dbAdminAdUser);
            });
            return adminAdUsersCrudRepository;
        }

        private Mock<IAdminAdUsersCrudRepository> SetupAdminAdUsersCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin()
        {
            var adminAdUsersCrudRepository = new Mock<IAdminAdUsersCrudRepository>(MockBehavior.Strict);
            adminAdUsersCrudRepository.Setup(repository => repository.GetAdminAdUser(AdminAdUserTestValues.IdDefault)).Returns(DbAdminAdUserTest.Default());
            adminAdUsersCrudRepository.Setup(repository => repository.UpdateAdminAdUser(It.IsAny<IDbAdminAdUser>())).Callback((IDbAdminAdUser dbAdminAdUser) =>
            {
                DbAdminAdUserTest.AssertUpdatedPermissionGlobalAdmin(dbAdminAdUser);
            });
            return adminAdUsersCrudRepository;
        }

        private Mock<IAdminAdUsersCrudRepository> SetupAdminAdUsersCrudRepositoryEmpty()
        {
            var adminAdUsersCrudRepository = new Mock<IAdminAdUsersCrudRepository>(MockBehavior.Strict);
            adminAdUsersCrudRepository.Setup(repository => repository.DoesAdminAdUserExist(AdminAdUserTestValues.DnForCreate)).Returns(false);
            adminAdUsersCrudRepository.Setup(repository => repository.DoesAdminAdUserExist(AdminAdUserTestValues.DnForUpdate)).Returns(false);
            adminAdUsersCrudRepository.Setup(repository => repository.GetAdminAdUser(AdminAdUserTestValues.IdDefault)).Returns(() => null);
            adminAdUsersCrudRepository.Setup(repository => repository.CreateAdminAdUser(It.IsAny<IDbAdminAdUser>())).Callback((IDbAdminAdUser dbAdminAdUser) =>
            {
                DbAdminAdUserTest.AssertCreated(dbAdminAdUser);
            });
            return adminAdUsersCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(AdminAdUserTestValues.IdForCreate);
            return guidGeneration;
        }
    }
}