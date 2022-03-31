using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.Permissions
{
    [TestClass]
    public class AdminEmailUserPermissionsCalculationLogicTests
    {
        [TestMethod]
        public void CalculateStrictPermissionsForAdminEmailUserTest()
        {
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = SetupAdminEmailUsersCrudRepositoryDefault();
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = SetupAdminEmailUserMembershipRepositoryDefault();
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = SetupAdminUserGroupPermissionsCalculationLogicDefault();

            AdminEmailUserPermissionsCalculationLogic adminEmailUserPermissionsCalculationLogic =
                new AdminEmailUserPermissionsCalculationLogic(
                    adminEmailUsersCrudRepository.Object,
                    adminEmailUserMembershipRepository.Object,
                    adminUserGroupPermissionsCalculationLogic.Object);

            // Act
            IDictionary<string, PermissionStatus> permissions = adminEmailUserPermissionsCalculationLogic
                .CalculateStrictPermissionsForAdminEmailUser(AdminEmailUserTestValues.IdDefault);

            // Assert
            AssertExtension.AreDictionariesEqual(PermissionsTestValues.CalculatedStrictPermissions1And2, permissions);
        }

        private static Mock<IAdminEmailUsersCrudRepository> SetupAdminEmailUsersCrudRepositoryDefault()
        {
            Mock<IAdminEmailUsersCrudRepository> adminEmailUsersCrudRepository = new Mock<IAdminEmailUsersCrudRepository>(MockBehavior.Strict);
            adminEmailUsersCrudRepository.Setup(repository => repository.GetGlobalAdminEmailUser(AdminEmailUserTestValues.IdDefault))
                .Returns(DbAdminEmailUserTest.Default());
            return adminEmailUsersCrudRepository;
        }

        private static Mock<IAdminEmailUserMembershipRepository> SetupAdminEmailUserMembershipRepositoryDefault()
        {
            Mock<IAdminEmailUserMembershipRepository> adminEmailUserMembershipRepository = new Mock<IAdminEmailUserMembershipRepository>(MockBehavior.Strict);
            adminEmailUserMembershipRepository.Setup(repository => repository.GetAdminUserGroupsOfAdminEmailUser(AdminEmailUserTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default2() });
            return adminEmailUserMembershipRepository;
        }

        private static Mock<IAdminUserGroupPermissionsCalculationLogic> SetupAdminUserGroupPermissionsCalculationLogicDefault()
        {
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = new Mock<IAdminUserGroupPermissionsCalculationLogic>(MockBehavior.Strict);
            adminUserGroupPermissionsCalculationLogic
                .Setup(logic => logic.CalculatePermissionsForAdminUserGroups(It.IsAny<IEnumerable<IDbAdminUserGroup>>()))
                .Returns(AdminUserGroupTestValues.PermissionsDefault2);
            return adminUserGroupPermissionsCalculationLogic;
        }
    }
}