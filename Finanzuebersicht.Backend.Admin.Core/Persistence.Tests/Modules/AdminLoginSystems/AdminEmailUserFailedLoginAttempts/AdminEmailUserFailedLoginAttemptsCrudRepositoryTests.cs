using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    [TestClass]
    public class AdminEmailUserFailedLoginAttemptsCrudRepositoryTests
    {
        [TestMethod]
        public void CreateFailedLoginAttemptTest()
        {
            // Arrange
            AdminEmailUserFailedLoginAttemptsCrudRepository adminEmailUserFailedLoginAttemptsCrudRepository = this.GetAdminEmailUserFailedLoginAttemptsCrudRepositoryEmpty();

            // Act
            adminEmailUserFailedLoginAttemptsCrudRepository.CreateFailedLoginAttempt(DbAdminEmailUserFailedLoginAttemptTest.ForCreate());

            // Assert
            List<IDbAdminEmailUserFailedLoginAttempt> dbAdminEmailUserFailedLoginAttempts = adminEmailUserFailedLoginAttemptsCrudRepository
                .GetFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdForCreate);
            DbAdminEmailUserFailedLoginAttemptTest.AssertForCreate(dbAdminEmailUserFailedLoginAttempts[0]);
        }

        [TestMethod]
        public void GetFailedLoginAttemptsTest()
        {
            // Arrange
            AdminEmailUserFailedLoginAttemptsCrudRepository adminEmailUserFailedLoginAttemptsCrudRepository = this.GetAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault();

            // Act
            List<IDbAdminEmailUserFailedLoginAttempt> dbAdminEmailUserFailedLoginAttempts = adminEmailUserFailedLoginAttemptsCrudRepository
                .GetFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault);

            // Assert
            DbAdminEmailUserFailedLoginAttemptTest.AssertDbDefault(dbAdminEmailUserFailedLoginAttempts[0]);
            DbAdminEmailUserFailedLoginAttemptTest.AssertDbDefault3(dbAdminEmailUserFailedLoginAttempts[1]);
        }

        [TestMethod]
        public void DeleteFailedLoginAttemptsTest()
        {
            // Arrange
            AdminEmailUserFailedLoginAttemptsCrudRepository adminEmailUserFailedLoginAttemptsCrudRepository = this.GetAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault();

            // Act
            adminEmailUserFailedLoginAttemptsCrudRepository
                .DeleteFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault);

            // Assert
            List<IDbAdminEmailUserFailedLoginAttempt> dbAdminEmailUserFailedLoginAttempts = adminEmailUserFailedLoginAttemptsCrudRepository
                .GetFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault);

            Assert.AreEqual(0, dbAdminEmailUserFailedLoginAttempts.Count);

            dbAdminEmailUserFailedLoginAttempts = adminEmailUserFailedLoginAttemptsCrudRepository
                .GetFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault2);

            Assert.AreEqual(1, dbAdminEmailUserFailedLoginAttempts.Count);
        }

        [TestMethod]
        public void DeleteFailedLoginAttemptsOlderThanTest()
        {
            // Arrange
            AdminEmailUserFailedLoginAttemptsCrudRepository adminEmailUserFailedLoginAttemptsCrudRepository = this.GetAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault();

            // Act
            adminEmailUserFailedLoginAttemptsCrudRepository
                .DeleteFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.OccurredAtDbDefault2);

            // Assert
            List<IDbAdminEmailUserFailedLoginAttempt> dbAdminEmailUserFailedLoginAttempts = adminEmailUserFailedLoginAttemptsCrudRepository
                .GetFailedLoginAttempts(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault);

            Assert.AreEqual(1, dbAdminEmailUserFailedLoginAttempts.Count);
        }

        private AdminEmailUserFailedLoginAttemptsCrudRepository GetAdminEmailUserFailedLoginAttemptsCrudRepositoryDefault()
        {
            return new AdminEmailUserFailedLoginAttemptsCrudRepository(InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AdminEmailUserFailedLoginAttemptsCrudRepository GetAdminEmailUserFailedLoginAttemptsCrudRepositoryEmpty()
        {
            return new AdminEmailUserFailedLoginAttemptsCrudRepository(InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }
    }
}