using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence.Tests;
using Finanzuebersicht.Backend.Generated.Contract.Contexts;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.StartSalden
{
    [TestClass]
    public class StartSaldenCrudRepositoryTests
    {
        [TestMethod]
        public void CreateStartSaldoTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryEmpty();

            // Act
            startSaldenCrudRepository.CreateStartSaldo(DbStartSaldoTest.ForCreate());

            // Assert
            IDbStartSaldo dbStartSaldo = startSaldenCrudRepository.GetStartSaldo(StartSaldoTestValues.IdForCreate);
            DbStartSaldoTest.AssertForCreate(dbStartSaldo);
        }

        [TestMethod]
        public void DeleteStartSaldoTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryDefault();

            // Act
            startSaldenCrudRepository.DeleteStartSaldo(StartSaldoTestValues.IdDbDefault);

            // Assert
            bool doesStartSaldoExist = startSaldenCrudRepository.DoesStartSaldoExist(StartSaldoTestValues.IdDbDefault);
            Assert.IsFalse(doesStartSaldoExist);
        }

        [TestMethod]
        public void DoesStartSaldoExistFalseTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryEmpty();

            // Act
            bool doesStartSaldoExist = startSaldenCrudRepository.DoesStartSaldoExist(StartSaldoTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesStartSaldoExist);
        }

        [TestMethod]
        public void DoesStartSaldoExistTrueTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryDefault();

            // Act
            bool doesStartSaldoExist = startSaldenCrudRepository.DoesStartSaldoExist(StartSaldoTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesStartSaldoExist);
        }

        [TestMethod]
        public void GetStartSaldoDefaultTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryDefault();

            // Act
            IDbStartSaldo dbStartSaldo = startSaldenCrudRepository.GetStartSaldo(StartSaldoTestValues.IdDbDefault);

            // Assert
            DbStartSaldoTest.AssertDbDefault(dbStartSaldo);
        }

        [TestMethod]
        public void GetStartSaldoDetailDefaultTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryDefault();

            // Act
            IDbStartSaldoDetail dbStartSaldoDetail = startSaldenCrudRepository.GetStartSaldoDetail(StartSaldoTestValues.IdDbDefault);

            // Assert
            DbStartSaldoDetailTest.AssertDbDefault(dbStartSaldoDetail);
        }

        [TestMethod]
        public void GetStartSaldoDetailNullTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryEmpty();

            // Act
            IDbStartSaldoDetail dbStartSaldoDetail = startSaldenCrudRepository.GetStartSaldoDetail(StartSaldoTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbStartSaldoDetail);
        }

        [TestMethod]
        public void GetAllStartSaldenDefaultTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryDefault();

            // Act
            IDbStartSaldo[] dbStartSalden = startSaldenCrudRepository.GetAllStartSalden().ToArray();

            // Assert
            Assert.AreEqual(2, dbStartSalden.Length);
            DbStartSaldoTest.AssertDbDefault(dbStartSalden[0]);
            DbStartSaldoTest.AssertDbDefault2(dbStartSalden[1]);
        }

        [TestMethod]
        public void GetPagedStartSaldenDefaultTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbStartSaldoListItem> dbStartSaldenPagedResult =
                startSaldenCrudRepository.GetPagedStartSalden();

            // Assert
            IDbStartSaldoListItem[] dbStartSalden = dbStartSaldenPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbStartSalden.Length);
            DbStartSaldoListItemTest.AssertDbDefault(dbStartSalden[0]);
            DbStartSaldoListItemTest.AssertDbDefault2(dbStartSalden[1]);
        }

        [TestMethod]
        public void GetStartSaldoNullTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryEmpty();

            // Act
            IDbStartSaldo dbStartSaldo = startSaldenCrudRepository.GetStartSaldo(StartSaldoTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbStartSaldo);
        }

        [TestMethod]
        public void UpdateStartSaldoTest()
        {
            // Arrange
            StartSaldenCrudRepository startSaldenCrudRepository = this.GetStartSaldenCrudRepositoryDefault();

            // Act
            startSaldenCrudRepository.UpdateStartSaldo(DbStartSaldoUpdateTest.ForUpdate());

            // Assert
            IDbStartSaldo dbStartSaldo = startSaldenCrudRepository.GetStartSaldo(StartSaldoTestValues.IdDbDefault);
            DbStartSaldoTest.AssertForUpdate(dbStartSaldo);
        }

        private StartSaldenCrudRepository GetStartSaldenCrudRepositoryDefault()
        {
            return new StartSaldenCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextWithDbDefault());
        }

        private StartSaldenCrudRepository GetStartSaldenCrudRepositoryEmpty()
        {
            return new StartSaldenCrudRepository(
                this.GetSessionContext(),
                PaginationContextTest.SetupPaginationContextDefault(),
                InMemoryDbContext.CreatePersistenceDbContextEmpty());
        }

        private ISessionContext GetSessionContext()
        {
            Mock<ISessionContext> sessionContext = new Mock<ISessionContext>(MockBehavior.Strict);
            sessionContext.Setup(sessionContext => sessionContext.EmailUserId)
                .Returns(StartSaldoTestValues.EmailUserIdDbDefault);
            return sessionContext.Object;
        }
    }
}