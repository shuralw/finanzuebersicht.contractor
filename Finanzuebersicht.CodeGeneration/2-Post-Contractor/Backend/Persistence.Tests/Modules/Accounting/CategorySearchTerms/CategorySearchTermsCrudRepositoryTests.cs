using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence.Tests;
using Finanzuebersicht.Backend.Generated.Contract.Contexts;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.CategorySearchTerms
{
    [TestClass]
    public class CategorySearchTermsCrudRepositoryTests
    {
        [TestMethod]
        public void CreateCategorySearchTermTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryEmpty();

            // Act
            categorySearchTermsCrudRepository.CreateCategorySearchTerm(DbCategorySearchTermTest.ForCreate());

            // Assert
            IDbCategorySearchTerm dbCategorySearchTerm = categorySearchTermsCrudRepository.GetCategorySearchTerm(CategorySearchTermTestValues.IdForCreate);
            DbCategorySearchTermTest.AssertForCreate(dbCategorySearchTerm);
        }

        [TestMethod]
        public void DeleteCategorySearchTermTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryDefault();

            // Act
            categorySearchTermsCrudRepository.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDbDefault);

            // Assert
            bool doesCategorySearchTermExist = categorySearchTermsCrudRepository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDbDefault);
            Assert.IsFalse(doesCategorySearchTermExist);
        }

        [TestMethod]
        public void DoesCategorySearchTermExistFalseTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryEmpty();

            // Act
            bool doesCategorySearchTermExist = categorySearchTermsCrudRepository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesCategorySearchTermExist);
        }

        [TestMethod]
        public void DoesCategorySearchTermExistTrueTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryDefault();

            // Act
            bool doesCategorySearchTermExist = categorySearchTermsCrudRepository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesCategorySearchTermExist);
        }

        [TestMethod]
        public void GetCategorySearchTermDefaultTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryDefault();

            // Act
            IDbCategorySearchTerm dbCategorySearchTerm = categorySearchTermsCrudRepository.GetCategorySearchTerm(CategorySearchTermTestValues.IdDbDefault);

            // Assert
            DbCategorySearchTermTest.AssertDbDefault(dbCategorySearchTerm);
        }

        [TestMethod]
        public void GetCategorySearchTermDetailDefaultTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryDefault();

            // Act
            IDbCategorySearchTermDetail dbCategorySearchTermDetail = categorySearchTermsCrudRepository.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDbDefault);

            // Assert
            DbCategorySearchTermDetailTest.AssertDbDefault(dbCategorySearchTermDetail);
        }

        [TestMethod]
        public void GetCategorySearchTermDetailNullTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryEmpty();

            // Act
            IDbCategorySearchTermDetail dbCategorySearchTermDetail = categorySearchTermsCrudRepository.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbCategorySearchTermDetail);
        }

        [TestMethod]
        public void GetAllCategorySearchTermsDefaultTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryDefault();

            // Act
            IDbCategorySearchTerm[] dbCategorySearchTerms = categorySearchTermsCrudRepository.GetAllCategorySearchTerms().ToArray();

            // Assert
            Assert.AreEqual(2, dbCategorySearchTerms.Length);
            DbCategorySearchTermTest.AssertDbDefault(dbCategorySearchTerms[0]);
            DbCategorySearchTermTest.AssertDbDefault2(dbCategorySearchTerms[1]);
        }

        [TestMethod]
        public void GetPagedCategorySearchTermsDefaultTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbCategorySearchTermListItem> dbCategorySearchTermsPagedResult =
                categorySearchTermsCrudRepository.GetPagedCategorySearchTerms();

            // Assert
            IDbCategorySearchTermListItem[] dbCategorySearchTerms = dbCategorySearchTermsPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbCategorySearchTerms.Length);
            DbCategorySearchTermListItemTest.AssertDbDefault(dbCategorySearchTerms[0]);
            DbCategorySearchTermListItemTest.AssertDbDefault2(dbCategorySearchTerms[1]);
        }

        [TestMethod]
        public void GetCategorySearchTermNullTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryEmpty();

            // Act
            IDbCategorySearchTerm dbCategorySearchTerm = categorySearchTermsCrudRepository.GetCategorySearchTerm(CategorySearchTermTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbCategorySearchTerm);
        }

        [TestMethod]
        public void UpdateCategorySearchTermTest()
        {
            // Arrange
            CategorySearchTermsCrudRepository categorySearchTermsCrudRepository = this.GetCategorySearchTermsCrudRepositoryDefault();

            // Act
            categorySearchTermsCrudRepository.UpdateCategorySearchTerm(DbCategorySearchTermUpdateTest.ForUpdate());

            // Assert
            IDbCategorySearchTerm dbCategorySearchTerm = categorySearchTermsCrudRepository.GetCategorySearchTerm(CategorySearchTermTestValues.IdDbDefault);
            DbCategorySearchTermTest.AssertForUpdate(dbCategorySearchTerm);
        }

        private CategorySearchTermsCrudRepository GetCategorySearchTermsCrudRepositoryDefault()
        {
            return new CategorySearchTermsCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private CategorySearchTermsCrudRepository GetCategorySearchTermsCrudRepositoryEmpty()
        {
            return new CategorySearchTermsCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }

        private ISessionContext GetSessionContext()
        {
            Mock<ISessionContext> sessionContext = new Mock<ISessionContext>(MockBehavior.Strict);
            sessionContext.Setup(sessionContext => sessionContext.EmailUserId)
                .Returns(CategorySearchTermTestValues.EmailUserIdDbDefault);
            return sessionContext.Object;
        }
    }
}