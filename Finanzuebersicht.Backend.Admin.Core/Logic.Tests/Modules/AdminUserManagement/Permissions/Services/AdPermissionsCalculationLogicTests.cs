using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.Permissions
{
    [TestClass]
    public class AdPermissionsCalculationLogicTests
    {
        [TestMethod]
        public void CalculateStrictPermissionsForAdForAdminAdGroup()
        {
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefault();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = this.SetupAdminUserGroupPermissionsCalculationLogicForAdminAdGroup();

            AdPermissionsCalculationLogic adPermissionsCalculationLogic =
                new AdPermissionsCalculationLogic(
                    null,
                    adminAdGroupsCrudRepository.Object,
                    null,
                    adminAdGroupMembershipRepository.Object,
                    adminUserGroupPermissionsCalculationLogic.Object);

            // Act
            IDictionary<string, PermissionStatus> permissions = adPermissionsCalculationLogic.CalculateStrictPermissionsForAd(null, new List<Guid>() { AdminAdGroupTestValues.IdDefault });

            // Assert
            AssertExtension.AreDictionariesEqual(PermissionsTestValues.CalculatedStrictPermissions1And2, permissions);
        }

        [TestMethod]
        public void CalculateStrictPermissionsForAdForAdminAdUser()
        {
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefault();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = this.SetupAdminUserGroupPermissionsCalculationLogicForAdminAdUser();

            AdPermissionsCalculationLogic adPermissionsCalculationLogic =
                new AdPermissionsCalculationLogic(
                    adminAdUsersCrudRepository.Object,
                    null,
                    adminAdUserMembershipRepository.Object,
                    null,
                    adminUserGroupPermissionsCalculationLogic.Object);

            // Act
            IDictionary<string, PermissionStatus> permissions = adPermissionsCalculationLogic.CalculateStrictPermissionsForAd(AdminAdUserTestValues.IdDefault, new List<Guid>() { });

            // Assert
            AssertExtension.AreDictionariesEqual(PermissionsTestValues.CalculatedStrictPermissions1And3, permissions);
        }

        [TestMethod]
        public void CalculateStrictPermissionsForAdForAdminAdUserAndAdminAdGroup()
        {
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = this.SetupAdminAdUsersCrudRepositoryDefault();
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = this.SetupAdminAdGroupsCrudRepositoryDefault();
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = this.SetupAdminAdUserMembershipRepositoryDefault();
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = this.SetupAdminAdGroupMembershipRepositoryDefault();
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = this.SetupAdminUserGroupPermissionsCalculationLogicForAdminAdUserAndAdminAdGroup();

            AdPermissionsCalculationLogic adPermissionsCalculationLogic =
                new AdPermissionsCalculationLogic(
                    adminAdUsersCrudRepository.Object,
                    adminAdGroupsCrudRepository.Object,
                    adminAdUserMembershipRepository.Object,
                    adminAdGroupMembershipRepository.Object,
                    adminUserGroupPermissionsCalculationLogic.Object);

            // Act
            IDictionary<string, PermissionStatus> permissions = adPermissionsCalculationLogic.CalculateStrictPermissionsForAd(AdminAdUserTestValues.IdDefault, new List<Guid>() { AdminAdGroupTestValues.IdDefault });

            // Assert
            AssertExtension.AreDictionariesEqual(PermissionsTestValues.CalculatedStrictPermissions1And2And3, permissions);
        }

        private Mock<IAdminAdGroupsCrudRepository> SetupAdminAdGroupsCrudRepositoryDefault()
        {
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = new Mock<IAdminAdGroupsCrudRepository>(MockBehavior.Strict);
            adminAdGroupsCrudRepository
                .Setup(repository => repository.GetGlobalAdminAdGroup(AdminAdGroupTestValues.IdDefault))
                .Returns(DbAdminAdGroupTest.Default());
            return adminAdGroupsCrudRepository;
        }

        private Mock<IAdminAdGroupMembershipRepository> SetupAdminAdGroupMembershipRepositoryDefault()
        {
            Mock<IAdminAdGroupMembershipRepository> adminAdGroupMembershipRepository = new Mock<IAdminAdGroupMembershipRepository>(MockBehavior.Strict);
            adminAdGroupMembershipRepository
                .Setup(repository => repository.GetAdminUserGroupsOfAdminAdGroup(AdminAdGroupTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default2() });
            return adminAdGroupMembershipRepository;
        }

        private Mock<IAdminAdUsersCrudRepository> SetupAdminAdUsersCrudRepositoryDefault()
        {
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = new Mock<IAdminAdUsersCrudRepository>(MockBehavior.Strict);
            adminAdUsersCrudRepository
                .Setup(repository => repository.GetGlobalAdminAdUser(AdminAdUserTestValues.IdDefault))
                .Returns(DbAdminAdUserTest.Default());
            return adminAdUsersCrudRepository;
        }

        private Mock<IAdminAdUserMembershipRepository> SetupAdminAdUserMembershipRepositoryDefault()
        {
            Mock<IAdminAdUserMembershipRepository> adminAdUserMembershipRepository = new Mock<IAdminAdUserMembershipRepository>(MockBehavior.Strict);
            adminAdUserMembershipRepository
                .Setup(repository => repository.GetAdminUserGroupsOfAdminAdUser(AdminAdUserTestValues.IdDefault))
                .Returns(new List<IDbAdminUserGroup>() { DbAdminUserGroupTest.Default3() });
            return adminAdUserMembershipRepository;
        }

        private Mock<IAdminUserGroupPermissionsCalculationLogic> SetupAdminUserGroupPermissionsCalculationLogicForAdminAdGroup()
        {
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = new Mock<IAdminUserGroupPermissionsCalculationLogic>(MockBehavior.Strict);
            adminUserGroupPermissionsCalculationLogic
                .Setup(logic => logic.CalculatePermissionsForAdminUserGroups(It.IsAny<IEnumerable<IDbAdminUserGroup>>()))
                .Returns(AdminUserGroupTestValues.PermissionsDefault2);
            return adminUserGroupPermissionsCalculationLogic;
        }

        private Mock<IAdminUserGroupPermissionsCalculationLogic> SetupAdminUserGroupPermissionsCalculationLogicForAdminAdUser()
        {
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = new Mock<IAdminUserGroupPermissionsCalculationLogic>(MockBehavior.Strict);
            adminUserGroupPermissionsCalculationLogic
                .Setup(logic => logic.CalculatePermissionsForAdminUserGroups(It.IsAny<IEnumerable<IDbAdminUserGroup>>()))
                .Returns(AdminUserGroupTestValues.PermissionsDefault3);
            return adminUserGroupPermissionsCalculationLogic;
        }

        private Mock<IAdminUserGroupPermissionsCalculationLogic> SetupAdminUserGroupPermissionsCalculationLogicForAdminAdUserAndAdminAdGroup()
        {
            Mock<IAdminUserGroupPermissionsCalculationLogic> adminUserGroupPermissionsCalculationLogic = new Mock<IAdminUserGroupPermissionsCalculationLogic>(MockBehavior.Strict);
            adminUserGroupPermissionsCalculationLogic
                .Setup(logic => logic.CalculatePermissionsForAdminUserGroups(It.IsAny<IEnumerable<IDbAdminUserGroup>>()))
                .Returns(AdminUserGroupTestValues.PermissionsDefault3);
            return adminUserGroupPermissionsCalculationLogic;
        }
    }
}