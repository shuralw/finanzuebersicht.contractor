using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence.Tests;
using Finanzuebersicht.Backend.Generated.Contract.Contexts;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.AccountingEntries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.AccountingEntries
{
    [TestClass]
    public class AccountingEntriesCrudRepositoryTests
    {
        [TestMethod]
        public void CreateAccountingEntryTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryEmpty();

            // Act
            accountingEntriesCrudRepository.CreateAccountingEntry(DbAccountingEntryTest.ForCreate());

            // Assert
            IDbAccountingEntry dbAccountingEntry = accountingEntriesCrudRepository.GetAccountingEntry(AccountingEntryTestValues.IdForCreate);
            DbAccountingEntryTest.AssertForCreate(dbAccountingEntry);
        }

        [TestMethod]
        public void DeleteAccountingEntryTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryDefault();

            // Act
            accountingEntriesCrudRepository.DeleteAccountingEntry(AccountingEntryTestValues.IdDbDefault);

            // Assert
            bool doesAccountingEntryExist = accountingEntriesCrudRepository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDbDefault);
            Assert.IsFalse(doesAccountingEntryExist);
        }

        [TestMethod]
        public void DoesAccountingEntryExistFalseTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryEmpty();

            // Act
            bool doesAccountingEntryExist = accountingEntriesCrudRepository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesAccountingEntryExist);
        }

        [TestMethod]
        public void DoesAccountingEntryExistTrueTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryDefault();

            // Act
            bool doesAccountingEntryExist = accountingEntriesCrudRepository.DoesAccountingEntryExist(AccountingEntryTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesAccountingEntryExist);
        }

        [TestMethod]
        public void GetAccountingEntryDefaultTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryDefault();

            // Act
            IDbAccountingEntry dbAccountingEntry = accountingEntriesCrudRepository.GetAccountingEntry(AccountingEntryTestValues.IdDbDefault);

            // Assert
            DbAccountingEntryTest.AssertDbDefault(dbAccountingEntry);
        }

        [TestMethod]
        public void GetAccountingEntryDetailDefaultTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryDefault();

            // Act
            IDbAccountingEntryDetail dbAccountingEntryDetail = accountingEntriesCrudRepository.GetAccountingEntryDetail(AccountingEntryTestValues.IdDbDefault);

            // Assert
            DbAccountingEntryDetailTest.AssertDbDefault(dbAccountingEntryDetail);
        }

        [TestMethod]
        public void GetAccountingEntryDetailNullTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryEmpty();

            // Act
            IDbAccountingEntryDetail dbAccountingEntryDetail = accountingEntriesCrudRepository.GetAccountingEntryDetail(AccountingEntryTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAccountingEntryDetail);
        }

        [TestMethod]
        public void GetAllAccountingEntriesDefaultTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryDefault();

            // Act
            IDbAccountingEntry[] dbAccountingEntries = accountingEntriesCrudRepository.GetAllAccountingEntries().ToArray();

            // Assert
            Assert.AreEqual(2, dbAccountingEntries.Length);
            DbAccountingEntryTest.AssertDbDefault(dbAccountingEntries[0]);
            DbAccountingEntryTest.AssertDbDefault2(dbAccountingEntries[1]);
        }

        [TestMethod]
        public void GetPagedAccountingEntriesDefaultTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbAccountingEntryListItem> dbAccountingEntriesPagedResult =
                accountingEntriesCrudRepository.GetPagedAccountingEntries();

            // Assert
            IDbAccountingEntryListItem[] dbAccountingEntries = dbAccountingEntriesPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbAccountingEntries.Length);
            DbAccountingEntryListItemTest.AssertDbDefault(dbAccountingEntries[0]);
            DbAccountingEntryListItemTest.AssertDbDefault2(dbAccountingEntries[1]);
        }

        [TestMethod]
        public void GetAccountingEntryNullTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryEmpty();

            // Act
            IDbAccountingEntry dbAccountingEntry = accountingEntriesCrudRepository.GetAccountingEntry(AccountingEntryTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbAccountingEntry);
        }

        [TestMethod]
        public void UpdateAccountingEntryTest()
        {
            // Arrange
            AccountingEntriesCrudRepository accountingEntriesCrudRepository = this.GetAccountingEntriesCrudRepositoryDefault();

            // Act
            accountingEntriesCrudRepository.UpdateAccountingEntry(DbAccountingEntryUpdateTest.ForUpdate());

            // Assert
            IDbAccountingEntry dbAccountingEntry = accountingEntriesCrudRepository.GetAccountingEntry(AccountingEntryTestValues.IdDbDefault);
            DbAccountingEntryTest.AssertForUpdate(dbAccountingEntry);
        }

        private AccountingEntriesCrudRepository GetAccountingEntriesCrudRepositoryDefault()
        {
            return new AccountingEntriesCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private AccountingEntriesCrudRepository GetAccountingEntriesCrudRepositoryEmpty()
        {
            return new AccountingEntriesCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }

        private ISessionContext GetSessionContext()
        {
            Mock<ISessionContext> sessionContext = new Mock<ISessionContext>(MockBehavior.Strict);
            sessionContext.Setup(sessionContext => sessionContext.EmailUserId)
                .Returns(AccountingEntryTestValues.EmailUserIdDbDefault);
            return sessionContext.Object;
        }
    }
}