using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.SsoAuthentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminAdLogin;
using Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.SsoAuthentication;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminAdUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminLoginSystem.AdminAdLogin
{
    [TestClass]
    public class AdminAdLoginLogicTests
    {
        [TestMethod]
        public async Task LoginWithSsoTokenDefaultTest()
        {
            // Arrange
            Mock<IAdminRefreshTokensCrudLogic> adminRefreshTokensCrudLogic = SetupAdminRefreshTokenCrudLogicDefault();
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = SetupAdminAdUsersCrudRepositoryDefault();
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = SetupAdminAdGroupsCrudRepositoryDefault();
            Mock<ISsoAuthenticationClient> ssoAuthenticationClient = SetupSsoAuthenticationClientDefault();
            ILogger<AdminAdLoginLogic> logger = Mock.Of<ILogger<AdminAdLoginLogic>>();

            AdminAdLoginLogic adminAdLoginLogic = new AdminAdLoginLogic(
                adminRefreshTokensCrudLogic.Object,
                adminAdUsersCrudRepository.Object,
                adminAdGroupsCrudRepository.Object,
                ssoAuthenticationClient.Object,
                logger);

            // Act
            ILogicResult<IAdminRefreshTokenDetail> loginWithSsoTokenResult = await adminAdLoginLogic.LoginWithSsoToken(AdminAdLoginTestValues.TokenDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, loginWithSsoTokenResult.State);
            adminRefreshTokensCrudLogic.Verify(logic => logic.CreateAdminRefreshTokenForAd(AdminAdUserTestValues.IdDefault, It.IsAny<List<Guid>>(), AdminAdUserTestValues.DnDefault), Times.Once);
        }

        private static Mock<IAdminAdGroupsCrudRepository> SetupAdminAdGroupsCrudRepositoryDefault()
        {
            Mock<IAdminAdGroupsCrudRepository> adminAdGroupsCrudRepository = new Mock<IAdminAdGroupsCrudRepository>(MockBehavior.Strict);
            adminAdGroupsCrudRepository.Setup(repository => repository.GetGlobalAdminAdGroups()).Returns(new List<IDbAdminAdGroup>()
            {
                DbAdminAdGroupTest.Default(),
            });
            return adminAdGroupsCrudRepository;
        }

        private static Mock<IAdminAdUsersCrudRepository> SetupAdminAdUsersCrudRepositoryDefault()
        {
            Mock<IAdminAdUsersCrudRepository> adminAdUsersCrudRepository = new Mock<IAdminAdUsersCrudRepository>(MockBehavior.Strict);
            adminAdUsersCrudRepository.Setup(repository => repository.GetGlobalAdminAdUsers(AdminAdUserTestValues.DnDefault)).Returns(new List<IDbAdminAdUser>()
            {
                DbAdminAdUserTest.Default(),
            });
            return adminAdUsersCrudRepository;
        }

        private static Mock<IAdminRefreshTokensCrudLogic> SetupAdminRefreshTokenCrudLogicDefault()
        {
            Mock<IAdminRefreshTokensCrudLogic> adminRefreshTokensCrudLogic = new Mock<IAdminRefreshTokensCrudLogic>(MockBehavior.Strict);

            adminRefreshTokensCrudLogic
                .Setup(logic => logic.CreateAdminRefreshTokenForAd(AdminAdUserTestValues.IdDefault, It.IsAny<List<Guid>>(), AdminAdUserTestValues.DnDefault))
                .Returns((Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds, string username) =>
                {
                    Assert.AreEqual(1, adminAdGroupIds.Count());
                    Assert.AreEqual(AdminAdGroupTestValues.IdDefault, adminAdGroupIds.ElementAt(0));
                    return AdminRefreshTokenTestValues.IdDefault;
                });

            adminRefreshTokensCrudLogic
                .Setup(logic => logic.GetAdminRefreshToken(AdminRefreshTokenTestValues.IdDefault))
                .Returns(LogicResult<IAdminRefreshTokenDetail>.Ok(AdminRefreshTokenDetailTest.Default()));

            return adminRefreshTokensCrudLogic;
        }

        private static Mock<ISsoAuthenticationClient> SetupSsoAuthenticationClientDefault()
        {
            Mock<ISsoAuthenticationClient> ssoAuthenticationClient = new Mock<ISsoAuthenticationClient>(MockBehavior.Strict);
            ssoAuthenticationClient
                .Setup(client => client.GetUsernameAndAdminUserGroupsFromSsoToken(AdminAdLoginTestValues.TokenDefault, It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(new SsoValidationResponse()
                {
                    EnthalteneGruppen = new List<string>() { AdminAdGroupTestValues.DnDefault },
                    NichtEnthalteneGruppen = new List<string>() { },
                    Nutzername = AdminAdUserTestValues.DnDefault
                });
            return ssoAuthenticationClient;
        }
    }
}