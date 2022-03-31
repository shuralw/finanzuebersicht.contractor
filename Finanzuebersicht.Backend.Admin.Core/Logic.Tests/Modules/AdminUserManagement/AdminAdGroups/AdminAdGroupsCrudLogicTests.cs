using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    [TestClass]
    public class AdminAdGroupsCrudLogicTests
    {
        [TestMethod]
        public void AddAdminAdGroupToAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdGroupMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdGroupMembershipRepository.Verify((repository) => repository.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void AddAdminAdGroupToAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryEmpty();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdGroupMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdGroupMembershipRepository.Verify((repository) => repository.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void AddAdminAdGroupToAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdGroupMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdGroupMembershipRepository.Verify((repository) => repository.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void CreateAdminAdGroupAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<Guid> result = adminAdGroupsCrudLogic.CreateAdminAdGroup(AdminAdGroupTestValues.DnForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.CreateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Never);
        }

        [TestMethod]
        public void CreateAdminAdGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryEmpty();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = adminAdGroupsCrudLogic.CreateAdminAdGroup(AdminAdGroupTestValues.DnForCreate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(AdminAdGroupTestValues.IdForCreate, result.Data);
            adminAdGroupsCrudRepository.Verify((repository) => repository.CreateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminAdGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.DeleteAdminAdGroup(AdminAdGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.DeleteAdminAdGroup(AdminAdGroupTestValues.IdDefault), Times.Once);
            adminAccessTokensCrudRepository.Verify((repository) => repository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups(), Times.Once);
        }

        [TestMethod]
        public void DeleteAdminAdGroupNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.DeleteAdminAdGroup(AdminAdGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.DeleteAdminAdGroup(AdminAdGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetAdminAdGroupDetailDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdPermissionsCalculationLogic> adminAdGroupPermissionsCalculationLogic = this.SetupAdPermissionsCalculationLogicDefault();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                adminAdGroupMembershipRepository.Object,
                adminAdGroupPermissionsCalculationLogic.Object,
                null, // adminAccessTokensCrudRepository
                null, // guidGenerator
                logger);

            // Act
            ILogicResult<IAdminAdGroupDetail> result = adminAdGroupsCrudLogic.GetAdminAdGroupDetail(AdminAdGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AdminAdGroupDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAdminAdGroupDetailNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<IAdminAdGroupDetail> result = adminAdGroupsCrudLogic.GetAdminAdGroupDetail(AdminAdGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetPagedAdminAdGroupsDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adminAdGroupPermissionCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<IAdminAdGroup>> adminAdGroupsPagedResult = adminAdGroupsCrudLogic.GetPagedAdminAdGroups();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, adminAdGroupsPagedResult.State);
            IAdminAdGroup[] entityResults = adminAdGroupsPagedResult.Data.Data.ToArray();
            Assert.AreEqual(2, entityResults.Length);
            AdminAdGroupTest.AssertDefault(entityResults[0]);
            AdminAdGroupTest.AssertDefault2(entityResults[1]);
        }

        [TestMethod]
        public void RemoveAdminAdGroupFromAdminUserGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdGroupMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdGroupMembershipRepository.Verify((repository) => repository.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void RemoveAdminAdGroupFromAdminUserGroupNotFoundTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryEmpty();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdGroupMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdGroupMembershipRepository.Verify((repository) => repository.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void RemoveAdminAdGroupFromAdminUserGroupNotFound2Test()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            Mock<IAdminUserGroupsCrudRepository> adminUserGroupsCrudRepository = this.SetupAdminUserGroupsCrudRepositoryEmpty();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                adminUserGroupsCrudRepository.Object,
                adminAdGroupMembershipRepository.Object,
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null, // guidGenerator,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdGroupMembershipRepository.Verify((repository) => repository.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminAdGroupAlreadyExistsTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryAlreadyExists();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.UpdateAdminAdGroup(AdminAdGroupTestValues.IdDefault, AdminAdGroupTestValues.DnForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminAdGroupDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExists();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.UpdateAdminAdGroup(AdminAdGroupTestValues.IdDefault, AdminAdGroupTestValues.DnForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminAdGroupNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.UpdateAdminAdGroup(AdminAdGroupTestValues.IdDefault, AdminAdGroupTestValues.DnForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAdminAdGroupPermissionsDefaultTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExistsForPermissionUpdate();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.UpdateAdminAdGroupPermissions(AdminAdGroupTestValues.IdDefault, AdminAdGroupTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminAdGroupPermissionsGlobalAdminTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin();
            Mock<IAdminAccessTokensCrudRepository> adminAccessTokensCrudRepository = this.SetupAdminAccessTokensCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                adminAccessTokensCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.UpdateAdminAdGroupPermissions(AdminAdGroupTestValues.IdDefault, AdminAdGroupTestValues.PermissionsForUpdateGlobalAdmin);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdminAdGroupPermissionsNotExistsTest()
        {
            // Arrange
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AdminAdGroupsCrudLogic>>();

            AdminAdGroupsCrudLogic adminAdGroupsCrudLogic = new AdminAdGroupsCrudLogic(
                adminAdGroupsCrudRepository.Object,
                null, // adminUserGroupsCrudRepository
                null, // adminAdGroupMembershipRepository
                null, // adPermissionsCalculationLogic
                null, // adminAccessTokensCrudRepository
                null,
                logger);

            // Act
            ILogicResult result = adminAdGroupsCrudLogic.UpdateAdminAdGroupPermissions(AdminAdGroupTestValues.IdDefault, AdminAdGroupTestValues.PermissionsForUpdate);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            adminAdGroupsCrudRepository.Verify((repository) => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>()), Times.Never);
        }

        private Mock<IAdminAccessTokensCrudRepository> SetupAdminAccessTokensCrudRepositoryEmpty()
        {
            Mock<IAdminAccessTokensCrudRepository> adminRefreshTokensCrudRepository = new Mock<IAdminAccessTokensCrudRepository>(MockBehavior.Strict);
            adminRefreshTokensCrudRepository.Setup(repository => repository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups());
            return adminRefreshTokensCrudRepository;
        }

        private Mock<IAdminAdGroupMembershipRepository> SetupAdminAdGroupMembershipRepositoryDefault()
        {
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = new Mock<IAdminAdGroupMembershipRepository>(MockBehavior.Strict);

            adminAdGroupMembershipRepository
                .Setup(repository => repository.GetAdminUserGroupsOfAdminAdGroup(AdminAdGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default() });

            adminAdGroupMembershipRepository
                .Setup(repository => repository.AddAdminAdGroupToAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault));

            adminAdGroupMembershipRepository
                .Setup(repository => repository.RemoveAdminAdGroupFromAdminUserGroup(AdminAdGroupTestValues.IdDefault, AdminUserGroupTestValues.IdDefault));

            return adminAdGroupMembershipRepository;
        }

        private Mock<IAdPermissionsCalculationLogic> SetupAdPermissionsCalculationLogicDefault()
        {
            var adminAdGroupPermissionsCalculationLogic = new Mock<IAdPermissionsCalculationLogic>(MockBehavior.Strict);
            adminAdGroupPermissionsCalculationLogic
                .Setup(logic => logic.CalculatePermissionsForAd(It.IsAny<Guid?>(), It.IsAny<IEnumerable<Guid>>()))
                .Returns((Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds) =>
                {
                    Assert.IsNull(adminAdUserId);
                    Assert.IsTrue(adminAdGroupIds.Any());
                    Assert.AreEqual(1, adminAdGroupIds.Count());
                    Assert.AreEqual(AdminAdGroupTestValues.IdDefault, adminAdGroupIds.ElementAt(0));
                    return AdminAdGroupTestValues.PermissionsDefault;
                });
            return adminAdGroupPermissionsCalculationLogic;
        }

        private Mock<IAdminAdGroupsCrudRepository> SetupAdminAdGroupsCrudRepositoryAlreadyExists()
        {
            var adminAdGroupsCrudRepository = new Mock<IAdminAdGroupsCrudRepository>(MockBehavior.Strict);
            adminAdGroupsCrudRepository.Setup(repository => repository.GetAdminAdGroup(AdminAdGroupTestValues.IdDefault)).Returns(DbAdminAdGroupTest.Default());
            adminAdGroupsCrudRepository.Setup(repository => repository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnForCreate)).Returns(true);
            adminAdGroupsCrudRepository.Setup(repository => repository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnForUpdate)).Returns(true);
            return adminAdGroupsCrudRepository;
        }

        private Mock<IAdminAdGroupsCrudRepository> SetupAdminAdGroupsCrudRepositoryDefaultExists()
        {
            var adminAdGroupsCrudRepository = new Mock<IAdminAdGroupsCrudRepository>(MockBehavior.Strict);
            adminAdGroupsCrudRepository.Setup(repository => repository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnForUpdate)).Returns(false);
            adminAdGroupsCrudRepository.Setup(repository => repository.GetAdminAdGroup(AdminAdGroupTestValues.IdDefault)).Returns(DbAdminAdGroupTest.Default());
            adminAdGroupsCrudRepository.Setup(repository => repository.GetPagedAdminAdGroups()).Returns(DbAdminAdGroupTest.ForPaged());
            adminAdGroupsCrudRepository.Setup(repository => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>())).Callback((IDbAdminAdGroup dbAdminAdGroup) =>
            {
                DbAdminAdGroupTest.AssertUpdatedMail(dbAdminAdGroup);
            });
            adminAdGroupsCrudRepository.Setup(repository => repository.DeleteAdminAdGroup(AdminAdGroupTestValues.IdDefault));
            return adminAdGroupsCrudRepository;
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

        private Mock<IAdminAdGroupsCrudRepository> SetupAdminAdGroupsCrudRepositoryDefaultExistsForPermissionUpdate()
        {
            var adminAdGroupsCrudRepository = new Mock<IAdminAdGroupsCrudRepository>(MockBehavior.Strict);
            adminAdGroupsCrudRepository.Setup(repository => repository.GetAdminAdGroup(AdminAdGroupTestValues.IdDefault)).Returns(DbAdminAdGroupTest.Default());
            adminAdGroupsCrudRepository.Setup(repository => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>())).Callback((IDbAdminAdGroup dbAdminAdGroup) =>
            {
                DbAdminAdGroupTest.AssertUpdatedPermission(dbAdminAdGroup);
            });
            return adminAdGroupsCrudRepository;
        }

        private Mock<IAdminAdGroupsCrudRepository> SetupAdminAdGroupsCrudRepositoryDefaultExistsForPermissionUpdateGlobalAdmin()
        {
            var adminAdGroupsCrudRepository = new Mock<IAdminAdGroupsCrudRepository>(MockBehavior.Strict);
            adminAdGroupsCrudRepository.Setup(repository => repository.GetAdminAdGroup(AdminAdGroupTestValues.IdDefault)).Returns(DbAdminAdGroupTest.Default());
            adminAdGroupsCrudRepository.Setup(repository => repository.UpdateAdminAdGroup(It.IsAny<IDbAdminAdGroup>())).Callback((IDbAdminAdGroup dbAdminAdGroup) =>
            {
                DbAdminAdGroupTest.AssertUpdatedPermissionGlobalAdmin(dbAdminAdGroup);
            });
            return adminAdGroupsCrudRepository;
        }

        private Mock<IAdminAdGroupsCrudRepository> SetupAdminAdGroupsCrudRepositoryEmpty()
        {
            var adminAdGroupsCrudRepository = new Mock<IAdminAdGroupsCrudRepository>(MockBehavior.Strict);
            adminAdGroupsCrudRepository.Setup(repository => repository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnForCreate)).Returns(false);
            adminAdGroupsCrudRepository.Setup(repository => repository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnForUpdate)).Returns(false);
            adminAdGroupsCrudRepository.Setup(repository => repository.GetAdminAdGroup(AdminAdGroupTestValues.IdDefault)).Returns(() => null);
            adminAdGroupsCrudRepository.Setup(repository => repository.CreateAdminAdGroup(It.IsAny<IDbAdminAdGroup>())).Callback((IDbAdminAdGroup dbAdminAdGroup) =>
            {
                DbAdminAdGroupTest.AssertCreated(dbAdminAdGroup);
            });
            return adminAdGroupsCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(AdminAdGroupTestValues.IdForCreate);
            return guidGeneration;
        }
    }
}