using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Tools.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.Categories
{
    [TestClass]
    public class CategoriesCrudRepositoryTests
    {
        [TestMethod]
        public void CreateCategoryTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryEmpty();

            // Act
            categoriesCrudRepository.CreateCategory(DbCategoryTest.ForCreate());

            // Assert
            IDbCategory dbCategory = categoriesCrudRepository.GetCategory(CategoryTestValues.IdForCreate);
            DbCategoryTest.AssertForCreate(dbCategory);
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryDefault();

            // Act
            categoriesCrudRepository.DeleteCategory(CategoryTestValues.IdDbDefault);

            // Assert
            bool doesCategoryExist = categoriesCrudRepository.DoesCategoryExist(CategoryTestValues.IdDbDefault);
            Assert.IsFalse(doesCategoryExist);
        }

        [TestMethod]
        public void DoesCategoryExistFalseTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryEmpty();

            // Act
            bool doesCategoryExist = categoriesCrudRepository.DoesCategoryExist(CategoryTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesCategoryExist);
        }

        [TestMethod]
        public void DoesCategoryExistTrueTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryDefault();

            // Act
            bool doesCategoryExist = categoriesCrudRepository.DoesCategoryExist(CategoryTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesCategoryExist);
        }

        [TestMethod]
        public void GetCategoryDefaultTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryDefault();

            // Act
            IDbCategory dbCategory = categoriesCrudRepository.GetCategory(CategoryTestValues.IdDbDefault);

            // Assert
            DbCategoryTest.AssertDbDefault(dbCategory);
        }

        [TestMethod]
        public void GetCategoryDetailDefaultTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryDefault();

            // Act
            IDbCategoryDetail dbCategoryDetail = categoriesCrudRepository.GetCategoryDetail(CategoryTestValues.IdDbDefault);

            // Assert
            DbCategoryDetailTest.AssertDbDefault(dbCategoryDetail);
        }

        [TestMethod]
        public void GetCategoryDetailNullTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryEmpty();

            // Act
            IDbCategoryDetail dbCategoryDetail = categoriesCrudRepository.GetCategoryDetail(CategoryTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbCategoryDetail);
        }

        [TestMethod]
        public void GetAllCategoriesDefaultTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryDefault();

            // Act
            IDbCategory[] dbCategories = categoriesCrudRepository.GetAllCategories().ToArray();

            // Assert
            Assert.AreEqual(2, dbCategories.Length);
            DbCategoryTest.AssertDbDefault(dbCategories[0]);
            DbCategoryTest.AssertDbDefault2(dbCategories[1]);
        }

        [TestMethod]
        public void GetPagedCategoriesDefaultTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbCategoryListItem> dbCategoriesPagedResult =
                categoriesCrudRepository.GetPagedCategories();

            // Assert
            IDbCategoryListItem[] dbCategories = dbCategoriesPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbCategories.Length);
            DbCategoryListItemTest.AssertDbDefault(dbCategories[0]);
            DbCategoryListItemTest.AssertDbDefault2(dbCategories[1]);
        }

        [TestMethod]
        public void GetCategoryNullTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryEmpty();

            // Act
            IDbCategory dbCategory = categoriesCrudRepository.GetCategory(CategoryTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbCategory);
        }

        [TestMethod]
        public void UpdateCategoryTest()
        {
            // Arrange
            CategoriesCrudRepository categoriesCrudRepository = this.GetCategoriesCrudRepositoryDefault();

            // Act
            categoriesCrudRepository.UpdateCategory(DbCategoryUpdateTest.ForUpdate());

            // Assert
            IDbCategory dbCategory = categoriesCrudRepository.GetCategory(CategoryTestValues.IdDbDefault);
            DbCategoryTest.AssertForUpdate(dbCategory);
        }

        private CategoriesCrudRepository GetCategoriesCrudRepositoryDefault()
        {
            return new CategoriesCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private CategoriesCrudRepository GetCategoriesCrudRepositoryEmpty()
        {
            return new CategoriesCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }

        private ISessionContext GetSessionContext()
        {
            Mock<ISessionContext> sessionContext = new Mock<ISessionContext>(MockBehavior.Strict);
            sessionContext.Setup(sessionContext => sessionContext.AdminEmailUserId)
                .Returns(CategoryTestValues.EmailUserIdDbDefault);
            return sessionContext.Object;
        }
    }
}