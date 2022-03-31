using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups
{
    [TestClass]
    public class AdminUserGroupsCrudLogicTests
    {
        [TestMethod]
        public void AddAdminUserGroupToAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminUserGroupMembershipRepository.Verify((repository) => repository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Once);
        }

        [TestMethod]
        public void AddAdminUserGroupToAdminUserGroupConflictTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryConflict();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminUserGroupMembershipRepository.Verify((repository) => repository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Once);
            adminUserGroupMembershipRepository.Verify((repository) => repository.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Once);
        }

        [TestMethod]
        public void AddAdminUserGroupToAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminUserGroupMembershipRepository.Verify((repository) => repository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Never);
        }

        [TestMethod]
        public void AddAdminUserGroupToAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty2();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminUserGroupMembershipRepository.Verify((repository) => repository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Never);
        }

        [TestMethod]
        public void CreateAdminUserGroupAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<Guid> result = adminUserGroupsCrudLogic.CreateAdminUserGroup(AdminUserGroupTestValues.NameForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.CreateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Never);
        }

        [TestMethod]
        public void CreateAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = adminUserGroupsCrudLogic.CreateAdminUserGroup(AdminUserGroupTestValues.NameForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(AdminUserGroupTestValues.IdForCreate, result.Data);
            adminUserGroupsCrudRepository.Verify((repository) => repository.CreateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.DeleteAdminUserGroup(AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.DeleteAdminUserGroup(AdminUserGroupTestValues.IdDefault), Times.Once);
            adminAccessTokensCrudRepository.Verify((repository) => repository.DeleteAllAdminAccessTokens(), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminUserGroupNotExistsTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.DeleteAdminUserGroup(AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.DeleteAdminUserGroup(AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetAdminUserGroupDetailDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryDefault();
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = this.SetupAdminUserGroupPermissionsCalculationLogicDefault();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                adminUserGroupPermissionsCalculationLogic.Object,
                null, // adminAccessTokensCrudRepository
                null, // guidGenerator
                logger);

            // Act
            ILogicResult<IAdminUserGroupDetail> result = adminUserGroupsCrudLogic.GetAdminUserGroupDetail(AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AdminUserGroupDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAdminUserGroupDetailNotExistsTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<IAdminUserGroupDetail> result = adminUserGroupsCrudLogic.GetAdminUserGroupDetail(AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetAdminUserGroupsDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<IAdminUserGroup>> adminUserGroupsResult = adminUserGroupsCrudLogic.GetPagedAdminUserGroups();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, adminUserGroupsResult.State);
            IAdminUserGroup[] adminUserGroupResults = adminUserGroupsResult.Data.Data.ToArray();
            Assert.AreEqual(2, adminUserGroupResults.Length);
            AdminUserGroupTest.AssertDefault(adminUserGroupResults[0]);
            AdminUserGroupTest.AssertDefault2(adminUserGroupResults[1]);
        }

        [TestMethod]
        public void RemoveAdminUserGroupFromAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminUserGroupMembershipRepository.Verify((repository) => repository.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Once);
        }

        [TestMethod]
        public void RemoveAdminUserGroupFromAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminUserGroupMembershipRepository.Verify((repository) => repository.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Never);
        }

        [TestMethod]
        public void RemoveAdminUserGroupFromAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty2();
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                adminUserGroupMembershipRepository.Object,
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminUserGroupMembershipRepository.Verify((repository) => repository.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminUserGroupAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.UpdateAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.NameForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.UpdateAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.NameForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminUserGroupNotExistsTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.UpdateAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.NameForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminUserGroupPermissionsDefaultTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExistsForPermissionUpdate();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.UpdateAdminUserGroupPermissions(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminUserGroupPermissionsGlobalAdminTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.UpdateAdminUserGroupPermissions(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.PermissionsForUpdateGlobalAdmin);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminUserGroupPermissionsNotExistsTest()
        {
            // Arrange
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminUserGroupsCrudLogic>>();

            AdminUserGroupsCrudLogic adminUserGroupsCrudLogic = new AdminUserGroupsCrudLogic(
                adminUserGroupsCrudRepository.Object,
                null, // adminUserGroupMembershipRepository
                null, // adminUserGroupPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminUserGroupsCrudLogic.UpdateAdminUserGroupPermissions(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminUserGroupsCrudRepository.Verify((repository) => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>()), Times.Never);
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryEmpty()
        {
            Mock<IAdminAccessTokensCrudRepository> adminRefreshTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.DeleteAllAdminAccessTokens());
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminUserGroupMembershipRepository> SetupAdminUserGroupMembershipRepositoryDefault()
        {
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = new Mock<IAdminUserGroupMembershipRepository>(MockBehavior.Strict);

            adminUserGroupMembershipRepository.Setup(repository => repository.HasCircularMembership(AdminUserGroupTestValues.IdDefault)).Returns(false);

            adminUserGroupMembershipRepository
                .Setup(repository => repository.GetAdminUserGroupsOfAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default2() });

            adminUserGroupMembershipRepository
                .Setup(repository => repository.GetAdminUserGroupParentsOfAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default2() });

            adminUserGroupMembershipRepository
                .Setup(repository => repository.GetAdminEmailUsersOfAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminEmailUser>() { DbAdminEmailUserTest.Default() });

            adminUserGroupMembershipRepository
                .Setup(repository => repository.GetAdminAdUsersOfAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminAdUser>() { DbAdminAdUserTest.Default() });

            adminUserGroupMembershipRepository
                .Setup(repository => repository.GetAdminAdGroupsOfAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminAdGroup>() { DbAdminAdGroupTest.Default() });

            adminUserGroupMembershipRepository
                .Setup(repository => repository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2));

            adminUserGroupMembershipRepository
                .Setup(repository => repository.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2));

            return adminUserGroupMembershipRepository;
        }

        private Mock<IAdminUserGroupMembershipRepository> SetupAdminUserGroupMembershipRepositoryConflict()
        {
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = new Mock<IAdminUserGroupMembershipRepository>(MockBehavior.Strict);

            adminUserGroupMembershipRepository.Setup(repository => repository.AddAdminUserGroupToAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2));

            adminUserGroupMembershipRepository.Setup(repository => repository.HasCircularMembership(AdminUserGroupTestValues.IdDefault)).Returns(true);

            adminUserGroupMembershipRepository.Setup(repository => repository.RemoveAdminUserGroupFromAdminUserGroup(AdminUserGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault2));

            return adminUserGroupMembershipRepository;
        }

        private Mock<IAdminUserGroupPermissionsCalculationLogic> SetupAdminUserGroupPermissionsCalculationLogicDefault()
        {
            var adminUserGroupPermissionsCalculationLogic = new Mock<IAdminUserGroupPermissionsCalculationLogic>(MockBehavior.Strict);
            adminUserGroupPermissionsCalculationLogic
                .Setup(logic => logic.CalculatePermissionsForAdminUserGroups(It.IsAny<IEnumerable<IDbAdminUserGroup>>()))
                .Returns((IEnumerable<IDbAdminUserGroup> adminUserGroupIds) =>
                {
                    Assert.IsTrue(adminUserGroupIds.Any());
                    Assert.AreEqual(1, adminUserGroupIds.Count());
                    DbAdminUserGroupTest.AssertDefault(adminUserGroupIds.ElementAt(0));
                    return AdminUserGroupTestValues.PermissionsDefault;
                });
            return adminUserGroupPermissionsCalculationLogic;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryAlreadyExists()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.DoesAdminUserGroupExist(AdminUserGroupTestValues.NameForCreate)).Returns(true);
            adminUserGroupsCrudRepository.Setup(repository => repository.DoesAdminUserGroupExist(AdminUserGroupTestValues.NameForUpdate)).Returns(true);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault)).Returns(DbAdminUserGroupTest.Default());
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault2)).Returns(DbAdminUserGroupTest.Default2());
            return adminUserGroupsCrudRepository;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryDefaultExists()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.DoesAdminUserGroupExist(AdminUserGroupTestValues.NameForUpdate)).Returns(false);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault)).Returns(DbAdminUserGroupTest.Default());
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault2)).Returns(DbAdminUserGroupTest.Default2());
            adminUserGroupsCrudRepository.Setup(repository => repository.GetPagedAdminUserGroups()).Returns(DbAdminUserGroupTest.ForPaged());
            adminUserGroupsCrudRepository.Setup(repository => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>())).Callback((IDbAdminUserGroup dbAdminUserGroup) =>
            {
                DbAdminUserGroupTest.AssertUpdatedName(dbAdminUserGroup);
            });
            adminUserGroupsCrudRepository.Setup(repository => repository.DeleteAdminUserGroup(AdminUserGroupTestValues.IdDefault));
            return adminUserGroupsCrudRepository;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryEmpty()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.DoesAdminUserGroupExist(AdminUserGroupTestValues.NameForCreate)).Returns(false);
            adminUserGroupsCrudRepository.Setup(repository => repository.DoesAdminUserGroupExist(AdminUserGroupTestValues.NameForUpdate)).Returns(false);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault)).Returns(() => null);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault2)).Returns(() => null);
            adminUserGroupsCrudRepository.Setup(repository => repository.CreateAdminUserGroup(It.IsAny<IDbAdminUserGroup>())).Callback((IDbAdminUserGroup dbAdminUserGroup) =>
            {
                DbAdminUserGroupTest.AssertCreated(dbAdminUserGroup);
            });
            return adminUserGroupsCrudRepository;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryEmpty2()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault)).Returns(DbAdminUserGroupTest.Default());
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault2)).Returns(() => null);
            return adminUserGroupsCrudRepository;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryDefaultExistsForPermissionUpdate()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault)).Returns(DbAdminUserGroupTest.Default());
            adminUserGroupsCrudRepository.Setup(repository => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>())).Callback((IDbAdminUserGroup dbAdminUserGroup) =>
            {
                DbAdminUserGroupTest.AssertUpdatedPermission(dbAdminUserGroup);
            });
            return adminUserGroupsCrudRepository;
        }

        private Mock<IAdminUserGroupsCrudRepository> SetupAdminUserGroupsCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin()
        {
            var adminUserGroupsCrudRepository = new Mock<IAdminUserGroupsCrudRepository>(MockBehavior.Strict);
            adminUserGroupsCrudRepository.Setup(repository => repository.GetAdminUserGroup(AdminUserGroupTestValues.IdDefault)).Returns(DbAdminUserGroupTest.Default());
            adminUserGroupsCrudRepository.Setup(repository => repository.UpdateAdminUserGroup(It.IsAny<IDbAdminUserGroup>())).Callback((IDbAdminUserGroup dbAdminUserGroup) =>
            {
                DbAdminUserGroupTest.AssertUpdatedPermissionGlobalAdmin(dbAdminUserGroup);
            });
            return adminUserGroupsCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(AdminUserGroupTestValues.IdForCreate);
            return guidGeneration;
        }
    }
}