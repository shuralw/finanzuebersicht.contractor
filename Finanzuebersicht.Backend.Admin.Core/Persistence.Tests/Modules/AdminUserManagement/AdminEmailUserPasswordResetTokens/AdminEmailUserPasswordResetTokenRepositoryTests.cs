using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens
{
    [TestClass]
    public class AdminEmailUserPasswordResetTokenRepositoryTests
    {
        [TestMethod]
        public void CreateTokenTest()
        {
            // Arrange
            AdminEmailUserPasswordResetTokenRepository adminEmailUserPasswordResetTokenRepository = this.GetAdminEmailUserPasswordResetTokenRepositoryDefault();

            // Act
            adminEmailUserPasswordResetTokenRepository.CreateToken(DbAdminEmailUserPasswordResetTokenTest.ForCreate());

            // Assert
            var adminEmailUserPasswordResetToken = adminEmailUserPasswordResetTokenRepository
                .GetToken(AdminEmailUserPasswordResetTokenTestValues.TokenForCreate);

            DbAdminEmailUserPasswordResetTokenTest.AssertForCreate(adminEmailUserPasswordResetToken);
        }

        [TestMethod]
        public void DeleteTokenTest()
        {
            // Arrange
            AdminEmailUserPasswordResetTokenRepository adminEmailUserPasswordResetTokenRepository = this.GetAdminEmailUserPasswordResetTokenRepositoryDefault();

            // Act
            adminEmailUserPasswordResetTokenRepository.DeleteToken(AdminEmailUserPasswordResetTokenTestValues.TokenDbDefault);

            // Assert
            var adminEmailUserPasswordResetToken = adminEmailUserPasswordResetTokenRepository
                .GetToken(AdminEmailUserPasswordResetTokenTestValues.TokenDbDefault);

            Assert.IsNull(adminEmailUserPasswordResetToken);
        }

        [TestMethod]
        public void DeleteTokenOlderThanTest()
        {
            // Arrange
            AdminEmailUserPasswordResetTokenRepository adminEmailUserPasswordResetTokenRepository = this.GetAdminEmailUserPasswordResetTokenRepositoryDefault();

            // Act
            adminEmailUserPasswordResetTokenRepository.DeleteToken(AdminEmailUserPasswordResetTokenTestValues.ExpiresOnDbDefault);

            // Assert
            var adminEmailUserPasswordResetToken = adminEmailUserPasswordResetTokenRepository
                .GetToken(AdminEmailUserPasswordResetTokenTestValues.TokenDbDefault2);

            Assert.IsNull(adminEmailUserPasswordResetToken);
        }

        private AdminEmailUserPasswordResetTokenRepository GetAdminEmailUserPasswordResetTokenRepositoryDefault()
        {
            return new AdminEmailUserPasswordResetTokenRepository(InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }
    }
}