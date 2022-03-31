using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
{
    [TestClass]
    public class AccountingEntriesCrudLogicTests
    {
        [TestMethod]
        public void CreateAccountingEntryDefaultTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryEmpty();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                categoriesCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = accountingEntriesCrudLogic.CreateAccountingEntry(AccountingEntryCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(AccountingEntryTestValues.IdForCreate, result.Data);
            accountingEntriesCrudRepository.Verify((repository) => repository.CreateAccountingEntry(It.IsAny<IDbAccountingEntry>()), Times.Once);
        }

        [TestMethod]
        public void DeleteAccountingEntryConflictTest()
        {
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                null,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = accountingEntriesCrudLogic.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteAccountingEntryDefaultTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = accountingEntriesCrudLogic.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            accountingEntriesCrudRepository.Verify((repository) => repository.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteAccountingEntryNotExistsTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = accountingEntriesCrudLogic.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            accountingEntriesCrudRepository.Verify((repository) => repository.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetAccountingEntryDetailDefaultTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IAccountingEntryDetail> result = accountingEntriesCrudLogic.GetAccountingEntryDetail(AccountingEntryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            AccountingEntryDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetAccountingEntryDetailNotExistsTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IAccountingEntryDetail> result = accountingEntriesCrudLogic.GetAccountingEntryDetail(AccountingEntryTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetPagedAccountingEntriesDefaultTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<IAccountingEntryListItem>> accountingEntriesPagedResult = accountingEntriesCrudLogic.GetPagedAccountingEntries();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, accountingEntriesPagedResult.State);
            IAccountingEntryListItem[] accountingEntryResults = accountingEntriesPagedResult.Data.Data.ToArray();
            Assert.AreEqual(2, accountingEntryResults.Length);
            AccountingEntryListItemTest.AssertDefault(accountingEntryResults[0]);
            AccountingEntryListItemTest.AssertDefault2(accountingEntryResults[1]);
        }

        [TestMethod]
        public void UpdateAccountingEntryNotExistsTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryEmpty();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                categoriesCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = accountingEntriesCrudLogic.UpdateAccountingEntry(AccountingEntryUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            accountingEntriesCrudRepository.Verify((repository) => repository.UpdateAccountingEntry(It.IsAny<IDbAccountingEntryUpdate>()), Times.Never);
        }

        [TestMethod]
        public void UpdateAccountingEntryDefaultTest()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepositoryDefaultExists();
            Mock<ICategoriesCrudRepository> categoriesCrudRepository = this.SetupCategoriesCrudRepositoryDefault();
            var logger = Mock.Of<ILogger<AccountingEntriesCrudLogic>>();

            AccountingEntriesCrudLogic accountingEntriesCrudLogic = new AccountingEntriesCrudLogic(
                accountingEntriesCrudRepository.Object,
                categoriesCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = accountingEntriesCrudLogic.UpdateAccountingEntry(AccountingEntryUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            accountingEntriesCrudRepository.Verify((repository) => repository.UpdateAccountingEntry(It.IsAny<IDbAccountingEntryUpdate>()), Times.Once);
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepositoryDefaultExists()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);
            accountingEntriesCrudRepository.Setup(repository => repository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDefault)).Returns(true);
            accountingEntriesCrudRepository.Setup(repository => repository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDefault2)).Returns(true);
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntry(AccountingEntryTestValues.IdDefault)).Returns(DbAccountingEntryTest.Default());
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntry(AccountingEntryTestValues.IdDefault2)).Returns(DbAccountingEntryTest.Default2());
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntryDetail(AccountingEntryTestValues.IdDefault)).Returns(DbAccountingEntryDetailTest.Default());
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntryDetail(AccountingEntryTestValues.IdDefault2)).Returns(DbAccountingEntryDetailTest.Default2());
            accountingEntriesCrudRepository.Setup(repository => repository.GetPagedAccountingEntries()).Returns(DbAccountingEntryListItemTest.ForPaged());
            accountingEntriesCrudRepository.Setup(repository => repository.UpdateAccountingEntry(It.IsAny<IDbAccountingEntryUpdate>())).Callback((IDbAccountingEntryUpdate dbAccountingEntryUpdate) =>
            {
                DbAccountingEntryUpdateTest.AssertUpdated(dbAccountingEntryUpdate);
            });
            accountingEntriesCrudRepository.Setup(repository => repository.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault));
            accountingEntriesCrudRepository.Setup(repository => repository.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault2));
            return accountingEntriesCrudRepository;
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepositoryEmpty()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);
            accountingEntriesCrudRepository.Setup(repository => repository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDefault)).Returns(false);
            accountingEntriesCrudRepository.Setup(repository => repository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDefault2)).Returns(false);
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntry(AccountingEntryTestValues.IdDefault)).Returns(() => null);
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntry(AccountingEntryTestValues.IdDefault2)).Returns(() => null);
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntryDetail(AccountingEntryTestValues.IdDefault)).Returns(() => null);
            accountingEntriesCrudRepository.Setup(repository => repository.GetAccountingEntryDetail(AccountingEntryTestValues.IdDefault2)).Returns(() => null);
            accountingEntriesCrudRepository.Setup(repository => repository.CreateAccountingEntry(It.IsAny<IDbAccountingEntry>())).Callback((IDbAccountingEntry dbAccountingEntry) =>
            {
                DbAccountingEntryTest.AssertCreated(dbAccountingEntry);
            });
            return accountingEntriesCrudRepository;
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepositoryDeleteConflict()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);
            accountingEntriesCrudRepository.Setup(repository => repository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDefault)).Returns(true);
            accountingEntriesCrudRepository.Setup(repository => repository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDefault2)).Returns(true);
            accountingEntriesCrudRepository.Setup(repository => repository.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault)).Throws(new DbUpdateException());
            accountingEntriesCrudRepository.Setup(repository => repository.DeleteAccountingEntry(AccountingEntryTestValues.IdDefault2)).Throws(new DbUpdateException());
            return accountingEntriesCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(AccountingEntryTestValues.IdForCreate);
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