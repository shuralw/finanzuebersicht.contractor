using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Tools.Pagination;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdGroups
{
    [TestClass]
    public class AdminAdGroupsCrudRepositoryTests
    {
        [TestMethod]
        public void CreateAdminAdGroupTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryEmpty();

            // Act
            adminAdGroupsCrudRepository.CreateAdminAdGroup(DbAdminAdGroupTest.ForCreate());

            // Assert
            IDbAdminAdGroup dbAdminAdGroup = adminAdGroupsCrudRepository.GetAdminAdGroup(AdminAdGroupTestValues.IdForCreate);
            DbAdminAdGroupTest.AssertForCreate(dbAdminAdGroup);
        }

        [TestMethod]
        public void DeleteAdminAdGroupTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryDefault();

            // Act
            adminAdGroupsCrudRepository.DeleteAdminAdGroup(AdminAdGroupTestValues.IdDbDefault);

            // Assert
            bool doesAdminAdGroupExist = adminAdGroupsCrudRepository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnDbDefault);
            Assert.IsFalse(doesAdminAdGroupExist);
        }

        [TestMethod]
        public void DoesAdminAdGroupExistFalseTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryEmpty();

            // Act
            bool doesAdminAdGroupExist = adminAdGroupsCrudRepository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnDbDefault);

            // Assert
            Assert.IsFalse(doesAdminAdGroupExist);
        }

        [TestMethod]
        public void DoesAdminAdGroupExistTrueTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryDefault();

            // Act
            bool doesAdminAdGroupExist = adminAdGroupsCrudRepository.DoesAdminAdGroupExist(AdminAdGroupTestValues.DnDbDefault);

            // Assert
            Assert.IsTrue(doesAdminAdGroupExist);
        }

        [TestMethod]
        public void GetAdminAdGroupDefaultTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryDefault();

            // Act
            IDbAdminAdGroup dbAdminAdGroup = adminAdGroupsCrudRepository.GetAdminAdGroup(AdminAdGroupTestValues.IdDbDefault);

            // Assert
            DbAdminAdGroupTest.AssertDbDefault(dbAdminAdGroup);
        }

        [TestMethod]
        public void GetAdminAdGroupNullTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryEmpty();

            // Act
            IDbAdminAdGroup dbAdminAdGroup = adminAdGroupsCrudRepository.GetAdminAdGroup(AdminAdGroupTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAdminAdGroup);
        }

        [TestMethod]
        public void GetPagedAdminAdGroupsDefaultTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbAdminAdGroup> dbAdminAdGroupsPagedResult =
                adminAdGroupsCrudRepository.GetPagedAdminAdGroups();

            // Assert
            IDbAdminAdGroup[] dbAdminAdGroups = dbAdminAdGroupsPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbAdminAdGroups.Length);
            DbAdminAdGroupTest.AssertDbDefault(dbAdminAdGroups[0]);
            DbAdminAdGroupTest.AssertDbDefault2(dbAdminAdGroups[1]);
        }

        [TestMethod]
        public void GetGlobalAdminAdGroupsDefaultTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryDefault();

            // Act
            IDbAdminAdGroup[] adminAdGroups = adminAdGroupsCrudRepository.GetGlobalAdminAdGroups(AdminAdGroupTestValues.DnDbDefault).ToArray();

            // Assert
            Assert.AreEqual(1, adminAdGroups.Length);
            DbAdminAdGroupTest.AssertDbDefault(adminAdGroups[0]);
        }

        [TestMethod]
        public void GetGlobalAdminAdGroupsByDnDefaultTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryDefault();

            // Act
            IDbAdminAdGroup[] adminAdGroups = adminAdGroupsCrudRepository.GetGlobalAdminAdGroups().ToArray();

            // Assert
            Assert.AreEqual(2, adminAdGroups.Length);

            // Also tested ordering here, so results are reversed
            DbAdminAdGroupTest.AssertDbDefault2(adminAdGroups[0]);
            DbAdminAdGroupTest.AssertDbDefault(adminAdGroups[1]);
        }

        [TestMethod]
        public void GetGlobalAdminAdGroupByDnDefaultTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryWithoutSessionContext();

            // Act
            IDbAdminAdGroup dbAdminAdGroup = adminAdGroupsCrudRepository.GetGlobalAdminAdGroup(AdminAdGroupTestValues.IdDbDefault);

            // Assert
            DbAdminAdGroupTest.AssertDbDefault(dbAdminAdGroup);
        }

        [TestMethod]
        public void UpdateAdminAdGroupTest()
        {
            // Arrange
            AdminAdGroupsCrudRepository adminAdGroupsCrudRepository = this.GetAdminAdGroupsCrudRepositoryDefault();

            // Act
            adminAdGroupsCrudRepository.UpdateAdminAdGroup(DbAdminAdGroupTest.ForUpdate());

            // Assert
            IDbAdminAdGroup dbAdminAdGroup = adminAdGroupsCrudRepository.GetAdminAdGroup(AdminAdGroupTestValues.IdDbDefault);
            DbAdminAdGroupTest.AssertForUpdate(dbAdminAdGroup);
        }

        private AdminAdGroupsCrudRepository GetAdminAdGroupsCrudRepositoryDefault()
        {
            return new AdminAdGroupsCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AdminAdGroupsCrudRepository GetAdminAdGroupsCrudRepositoryEmpty()
        {
            return new AdminAdGroupsCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }

        private AdminAdGroupsCrudRepository GetAdminAdGroupsCrudRepositoryWithoutSessionContext()
        {
            return new AdminAdGroupsCrudRepository(
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }
    }
}