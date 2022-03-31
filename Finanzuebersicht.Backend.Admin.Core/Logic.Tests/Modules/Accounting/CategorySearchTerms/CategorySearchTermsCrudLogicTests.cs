using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    [TestClass]
    public class CategorySearchTermsCrudLogicTests
    {
        [TestMethod]
        public void CreateCategorySearchTermDefaultTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryEmpty();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                categoriesCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = categorySearchTermsCrudLogic.CreateCategorySearchTerm(CategorySearchTermCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(CategorySearchTermTestValues.IdForCreate, result.Data);
            categorySearchTermsCrudRepository.Verify((repository) => repository.CreateCategorySearchTerm(It.IsAny<IDbCategorySearchTerm>()), Times.Once);
        }

        [TestMethod]
        public void DeleteCategorySearchTermConflictTest()
        {
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                null,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = categorySearchTermsCrudLogic.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteCategorySearchTermDefaultTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = categorySearchTermsCrudLogic.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            categorySearchTermsCrudRepository.Verify((repository) => repository.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteCategorySearchTermNotExistsTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = categorySearchTermsCrudLogic.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            categorySearchTermsCrudRepository.Verify((repository) => repository.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetCategorySearchTermDetailDefaultTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<ICategorySearchTermDetail> result = categorySearchTermsCrudLogic.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            CategorySearchTermDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetCategorySearchTermDetailNotExistsTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<ICategorySearchTermDetail> result = categorySearchTermsCrudLogic.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetPagedCategorySearchTermsDefaultTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<ICategorySearchTermListItem>> categorySearchTermsPagedResult = categorySearchTermsCrudLogic.GetPagedCategorySearchTerms();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, categorySearchTermsPagedResult.State);
            ICategorySearchTermListItem[] categorySearchTermResults = categorySearchTermsPagedResult.Data.Data.ToArray();
            Assert.AreEqual(2, categorySearchTermResults.Length);
            CategorySearchTermListItemTest.AssertDefault(categorySearchTermResults[0]);
            CategorySearchTermListItemTest.AssertDefault2(categorySearchTermResults[1]);
        }

        [TestMethod]
        public void UpdateCategorySearchTermNotExistsTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryEmpty();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                categoriesCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = categorySearchTermsCrudLogic.UpdateCategorySearchTerm(CategorySearchTermUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            categorySearchTermsCrudRepository.Verify((repository) => repository.UpdateCategorySearchTerm(It.IsAny<IDbCategorySearchTermUpdate>()), Times.Never);
        }

        [TestMethod]
        public void UpdateCategorySearchTermDefaultTest()
        {
            // Arrange
            Mock<ICategorySearchTermsCrudRepository> categorySearchTermsCrudRepository = this.SetupCategorySearchTermsCrudRepositoryDefaultExists();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            var logger = Mock.Of<ILogger<CategorySearchTermsCrudLogic>>();

            CategorySearchTermsCrudLogic categorySearchTermsCrudLogic = new CategorySearchTermsCrudLogic(
                categorySearchTermsCrudRepository.Object,
                categoriesCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = categorySearchTermsCrudLogic.UpdateCategorySearchTerm(CategorySearchTermUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            categorySearchTermsCrudRepository.Verify((repository) => repository.UpdateCategorySearchTerm(It.IsAny<IDbCategorySearchTermUpdate>()), Times.Once);
        }

        private Mock<ICategorySearchTermsCrudRepository> SetupCategorySearchTermsCrudRepositoryDefaultExists()
        {
            var categorySearchTermsCrudRepository = new Mock<ICategorySearchTermsCrudRepository>(MockBehavior.Strict);
            categorySearchTermsCrudRepository.Setup(repository => repository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDefault)).Returns(true);
            categorySearchTermsCrudRepository.Setup(repository => repository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDefault2)).Returns(true);
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTerm(CategorySearchTermTestValues.IdDefault)).Returns(DbCategorySearchTermTest.Default());
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTerm(CategorySearchTermTestValues.IdDefault2)).Returns(DbCategorySearchTermTest.Default2());
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDefault)).Returns(DbCategorySearchTermDetailTest.Default());
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDefault2)).Returns(DbCategorySearchTermDetailTest.Default2());
            categorySearchTermsCrudRepository.Setup(repository => repository.GetPagedCategorySearchTerms()).Returns(DbCategorySearchTermListItemTest.ForPaged());
            categorySearchTermsCrudRepository.Setup(repository => repository.UpdateCategorySearchTerm(It.IsAny<IDbCategorySearchTermUpdate>())).Callback((IDbCategorySearchTermUpdate dbCategorySearchTermUpdate) =>
            {
                DbCategorySearchTermUpdateTest.AssertUpdated(dbCategorySearchTermUpdate);
            });
            categorySearchTermsCrudRepository.Setup(repository => repository.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault));
            categorySearchTermsCrudRepository.Setup(repository => repository.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault2));
            return categorySearchTermsCrudRepository;
        }

        private Mock<ICategorySearchTermsCrudRepository> SetupCategorySearchTermsCrudRepositoryEmpty()
        {
            var categorySearchTermsCrudRepository = new Mock<ICategorySearchTermsCrudRepository>(MockBehavior.Strict);
            categorySearchTermsCrudRepository.Setup(repository => repository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDefault)).Returns(false);
            categorySearchTermsCrudRepository.Setup(repository => repository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDefault2)).Returns(false);
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTerm(CategorySearchTermTestValues.IdDefault)).Returns(() => null);
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTerm(CategorySearchTermTestValues.IdDefault2)).Returns(() => null);
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDefault)).Returns(() => null);
            categorySearchTermsCrudRepository.Setup(repository => repository.GetCategorySearchTermDetail(CategorySearchTermTestValues.IdDefault2)).Returns(() => null);
            categorySearchTermsCrudRepository.Setup(repository => repository.CreateCategorySearchTerm(It.IsAny<IDbCategorySearchTerm>())).Callback((IDbCategorySearchTerm dbCategorySearchTerm) =>
            {
                DbCategorySearchTermTest.AssertCreated(dbCategorySearchTerm);
            });
            return categorySearchTermsCrudRepository;
        }

        private Mock<ICategorySearchTermsCrudRepository> SetupCategorySearchTermsCrudRepositoryDeleteConflict()
        {
            var categorySearchTermsCrudRepository = new Mock<ICategorySearchTermsCrudRepository>(MockBehavior.Strict);
            categorySearchTermsCrudRepository.Setup(repository => repository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDefault)).Returns(true);
            categorySearchTermsCrudRepository.Setup(repository => repository.DoesCategorySearchTermExist(CategorySearchTermTestValues.IdDefault2)).Returns(true);
            categorySearchTermsCrudRepository.Setup(repository => repository.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault)).Throws(new DbUpdateException());
            categorySearchTermsCrudRepository.Setup(repository => repository.DeleteCategorySearchTerm(CategorySearchTermTestValues.IdDefault2)).Throws(new DbUpdateException());
            return categorySearchTermsCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(CategorySearchTermTestValues.IdForCreate);
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