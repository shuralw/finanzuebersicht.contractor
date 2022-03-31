using Contract.Architecture.Backend.Common.Contract.Logic;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories
{
    [TestClass]
    public class CategoriesCrudLogicTests
    {
        [TestMethod]
        public void CreateCategoryDefaultTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryEmpty();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                categoriesCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = categoriesCrudLogic.CreateCategory(CategoryCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(CategoryTestValues.IdForCreate, result.Data);
            categoriesCrudRepository.Verify((repository) => repository.CreateCategory(It.IsAny<IDbCategory>()), Times.Once);
        }

        [TestMethod]
        public void DeleteCategoryConflictTest()
        {
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                null,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = categoriesCrudLogic.DeleteCategory(CategoryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteCategoryDefaultTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = categoriesCrudLogic.DeleteCategory(CategoryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            categoriesCrudRepository.Verify((repository) => repository.DeleteCategory(CategoryTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteCategoryNotExistsTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = categoriesCrudLogic.DeleteCategory(CategoryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            categoriesCrudRepository.Verify((repository) => repository.DeleteCategory(CategoryTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetCategoryDetailDefaultTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<ICategoryDetail> result = categoriesCrudLogic.GetCategoryDetail(CategoryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            CategoryDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetCategoryDetailNotExistsTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<ICategoryDetail> result = categoriesCrudLogic.GetCategoryDetail(CategoryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetPagedCategoriesDefaultTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<ICategoryListItem>> categoriesPagedResult = categoriesCrudLogic.GetPagedCategories();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, categoriesPagedResult.State);
            ICategoryListItem[] categoryResults = categoriesPagedResult.Data.Data.ToArray();
            Assert.AreEqual(2, categoryResults.Length);
            CategoryListItemTest.AssertDefault(categoryResults[0]);
            CategoryListItemTest.AssertDefault2(categoryResults[1]);
        }

        [TestMethod]
        public void UpdateCategoryNotExistsTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryEmpty();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                categoriesCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = categoriesCrudLogic.UpdateCategory(CategoryUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            categoriesCrudRepository.Verify((repository) => repository.UpdateCategory(It.IsAny<IDbCategoryUpdate>()), Times.Never);
        }

        [TestMethod]
        public void UpdateCategoryDefaultTest()
        {
            // Arrange
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefaultExists();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            var logger = Mock.Of<ILogger<CategoriesCrudLogic>>();

            CategoriesCrudLogic categoriesCrudLogic = new CategoriesCrudLogic(
                categoriesCrudRepository.Object,
                categoriesCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = categoriesCrudLogic.UpdateCategory(CategoryUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            categoriesCrudRepository.Verify((repository) => repository.UpdateCategory(It.IsAny<IDbCategoryUpdate>()), Times.Once);
        }

        private Mock<ICategoriesCrudRepository> SetupCategoriesCrudRepositoryDefaultExists()
        {
            var categoriesCrudRepository = new Mock<ICategoriesCrudRepository>(MockBehavior.Strict);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault)).Returns(true);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault2)).Returns(true);
            categoriesCrudRepository.Setup(repository => repository.GetCategory(CategoryTestValues.IdDefault)).Returns(DbCategoryTest.Default());
            categoriesCrudRepository.Setup(repository => repository.GetCategory(CategoryTestValues.IdDefault2)).Returns(DbCategoryTest.Default2());
            categoriesCrudRepository.Setup(repository => repository.GetCategoryDetail(CategoryTestValues.IdDefault)).Returns(DbCategoryDetailTest.Default());
            categoriesCrudRepository.Setup(repository => repository.GetCategoryDetail(CategoryTestValues.IdDefault2)).Returns(DbCategoryDetailTest.Default2());
            categoriesCrudRepository.Setup(repository => repository.GetPagedCategories()).Returns(DbCategoryListItemTest.ForPaged());
            categoriesCrudRepository.Setup(repository => repository.UpdateCategory(It.IsAny<IDbCategoryUpdate>())).Callback((IDbCategoryUpdate dbCategoryUpdate) =>
            {
                DbCategoryUpdateTest.AssertUpdated(dbCategoryUpdate);
            });
            categoriesCrudRepository.Setup(repository => repository.DeleteCategory(CategoryTestValues.IdDefault));
            categoriesCrudRepository.Setup(repository => repository.DeleteCategory(CategoryTestValues.IdDefault2));
            return categoriesCrudRepository;
        }

        private Mock<ICategoriesCrudRepository> SetupCategoriesCrudRepositoryEmpty()
        {
            var categoriesCrudRepository = new Mock<ICategoriesCrudRepository>(MockBehavior.Strict);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault)).Returns(false);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault2)).Returns(false);
            categoriesCrudRepository.Setup(repository => repository.GetCategory(CategoryTestValues.IdDefault)).Returns(() => null);
            categoriesCrudRepository.Setup(repository => repository.GetCategory(CategoryTestValues.IdDefault2)).Returns(() => null);
            categoriesCrudRepository.Setup(repository => repository.GetCategoryDetail(CategoryTestValues.IdDefault)).Returns(() => null);
            categoriesCrudRepository.Setup(repository => repository.GetCategoryDetail(CategoryTestValues.IdDefault2)).Returns(() => null);
            categoriesCrudRepository.Setup(repository => repository.CreateCategory(It.IsAny<IDbCategory>())).Callback((IDbCategory dbCategory) =>
            {
                DbCategoryTest.AssertCreated(dbCategory);
            });
            return categoriesCrudRepository;
        }

        private Mock<ICategoriesCrudRepository> SetupCategoriesCrudRepositoryDeleteConflict()
        {
            var categoriesCrudRepository = new Mock<ICategoriesCrudRepository>(MockBehavior.Strict);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault)).Returns(true);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault2)).Returns(true);
            categoriesCrudRepository.Setup(repository => repository.DeleteCategory(CategoryTestValues.IdDefault)).Throws(new DbUpdateException());
            categoriesCrudRepository.Setup(repository => repository.DeleteCategory(CategoryTestValues.IdDefault2)).Throws(new DbUpdateException());
            return categoriesCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(CategoryTestValues.IdForCreate);
            return guidGeneration;
        }

        private Mock<ICategoriesCrudRepository> SetupCategoriesCrudRepositoryDefault()
        {
            var categoriesCrudRepository = new Mock<ICategoriesCrudRepository>(MockBehavior.Strict);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault)).Returns(true);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdDefault2)).Returns(true);
            categoriesCrudRepository.Setup(repository => repository.DoesCategoryExist(CategoryTestValues.IdForCreate)).Returns(false);
            return categoriesCrudRepository;
        }
    }
}