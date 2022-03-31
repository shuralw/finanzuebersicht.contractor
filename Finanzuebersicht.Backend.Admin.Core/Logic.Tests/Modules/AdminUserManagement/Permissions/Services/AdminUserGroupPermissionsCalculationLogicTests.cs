using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.Permissions
{
    [TestClass]
    public class AdminUserGroupPermissionsCalculationLogicTests
    {
        [TestMethod]
        public void CalculatePermissionsForAdminUserGroups()
        {
            // Arrange
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryForAdminUserGroups();

            AdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic = new AdminUserGroupPermissionsCalculationLogic(
                adminUserGroupMembershipRepository.Object);

            // Act
            var permissions = adminUserGroupPermissionsCalculationLogic
                .CalculatePermissionsForAdminUserGroups(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default() });

            // Assert
            Assert.IsNotNull(permissions);
            AssertExtension.AreDictionariesEqual(PermissionsTestValues.CalculatedPermissions1And2And3, permissions);
        }

        [TestMethod]
        public void CalculatePermissionsForAdminUserGroupsNoParents()
        {
            // Arrange
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryNoParents();

            AdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic = new AdminUserGroupPermissionsCalculationLogic(
                adminUserGroupMembershipRepository.Object);

            // Act
            var permissions = adminUserGroupPermissionsCalculationLogic
                .CalculatePermissionsForAdminUserGroups(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default() });

            // Assert
            Assert.IsNotNull(permissions);
            AssertExtension.AreDictionariesEqual(AdminUserGroupTestValues.PermissionsDefault, permissions);
        }

        [TestMethod]
        public void CalculatePermissionsForAdminUserGroupsUnused()
        {
            // Arrange
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = this.SetupAdminUserGroupMembershipRepositoryUnused();

            AdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic = new AdminUserGroupPermissionsCalculationLogic(
                adminUserGroupMembershipRepository.Object);

            // Act
            var permissions = adminUserGroupPermissionsCalculationLogic
                .CalculatePermissionsForAdminUserGroups(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default() });

            // Assert
            Assert.IsNotNull(permissions);
            AssertExtension.AreDictionariesEqual(PermissionsTestValues.CalculatedPermissions1And2, permissions);
        }

        private Mock<IAdminUserGroupMembershipRepository> SetupAdminUserGroupMembershipRepositoryForAdminUserGroups()
        {
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = new Mock<IAdminUserGroupMembershipRepository>(MockBehavior.Strict);
            adminUserGroupMembershipRepository.Setup(repository => repository.GetAdminUserGroupParentsOfAdminUserGroup(It.IsAny<Guid>())).Returns(new List<IDbAdminUserGroup>() { });
            adminUserGroupMembershipRepository.Setup(repository => repository.GetAdminUserGroupParentsOfAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default2(), DbAdminUserGroupTest.Default3() });
            return adminUserGroupMembershipRepository;
        }

        private Mock<IAdminUserGroupMembershipRepository> SetupAdminUserGroupMembershipRepositoryNoParents()
        {
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = new Mock<IAdminUserGroupMembershipRepository>(MockBehavior.Strict);
            adminUserGroupMembershipRepository.Setup(repository => repository.GetAdminUserGroupParentsOfAdminUserGroup(It.IsAny<Guid>()))
                .Returns(new List<IDbAdminUserGroup>() { });
            return adminUserGroupMembershipRepository;
        }

        private Mock<IAdminUserGroupMembershipRepository> SetupAdminUserGroupMembershipRepositoryUnused()
        {
            Mock<IAdminUserGroupMembershipRepository> adminUserGroupMembershipRepository = new Mock<IAdminUserGroupMembershipRepository>(MockBehavior.Strict);
            adminUserGroupMembershipRepository.Setup(repository => repository.GetAdminUserGroupParentsOfAdminUserGroup(It.IsAny<Guid>()))
                .Returns(new List<IDbAdminUserGroup>() { });
            adminUserGroupMembershipRepository.Setup(repository => repository.GetAdminUserGroupParentsOfAdminUserGroup(AdminUserGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default2() });
            return adminUserGroupMembershipRepository;
        }
    }
}