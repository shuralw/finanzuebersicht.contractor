using Contract.Architecture.Backend.Common.Contract.Logic;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.StartSalden;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    [TestClass]
    public class StartSaldenCrudLogicTests
    {
        [TestMethod]
        public void CreateStartSaldoDefaultTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryEmpty();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = startSaldenCrudLogic.CreateStartSaldo(StartSaldoCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(StartSaldoTestValues.IdForCreate, result.Data);
            startSaldenCrudRepository.Verify((repository) => repository.CreateStartSaldo(It.IsAny<IDbStartSaldo>()), Times.Once);
        }

        [TestMethod]
        public void DeleteStartSaldoConflictTest()
        {
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = startSaldenCrudLogic.DeleteStartSaldo(StartSaldoTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteStartSaldoDefaultTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = startSaldenCrudLogic.DeleteStartSaldo(StartSaldoTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            startSaldenCrudRepository.Verify((repository) => repository.DeleteStartSaldo(StartSaldoTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteStartSaldoNotExistsTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = startSaldenCrudLogic.DeleteStartSaldo(StartSaldoTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            startSaldenCrudRepository.Verify((repository) => repository.DeleteStartSaldo(StartSaldoTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetStartSaldoDetailDefaultTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IStartSaldoDetail> result = startSaldenCrudLogic.GetStartSaldoDetail(StartSaldoTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            StartSaldoDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetStartSaldoDetailNotExistsTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IStartSaldoDetail> result = startSaldenCrudLogic.GetStartSaldoDetail(StartSaldoTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetPagedStartSaldenDefaultTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<IStartSaldoListItem>> startSaldenPagedResult = startSaldenCrudLogic.GetPagedStartSalden();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, startSaldenPagedResult.State);
            IStartSaldoListItem[] startSaldoResults = startSaldenPagedResult.Data.Data.ToArray();
            Assert.AreEqual(2, startSaldoResults.Length);
            StartSaldoListItemTest.AssertDefault(startSaldoResults[0]);
            StartSaldoListItemTest.AssertDefault2(startSaldoResults[1]);
        }

        [TestMethod]
        public void UpdateStartSaldoNotExistsTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = startSaldenCrudLogic.UpdateStartSaldo(StartSaldoUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            startSaldenCrudRepository.Verify((repository) => repository.UpdateStartSaldo(It.IsAny<IDbStartSaldoUpdate>()), Times.Never);
        }

        [TestMethod]
        public void UpdateStartSaldoDefaultTest()
        {
            // Arrange
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<StartSaldenCrudLogic>>();

            StartSaldenCrudLogic startSaldenCrudLogic = new StartSaldenCrudLogic(
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = startSaldenCrudLogic.UpdateStartSaldo(StartSaldoUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            startSaldenCrudRepository.Verify((repository) => repository.UpdateStartSaldo(It.IsAny<IDbStartSaldoUpdate>()), Times.Once);
        }

        private Mock<IStartSaldenCrudRepository> SetupStartSaldenCrudRepositoryDefaultExists()
        {
            var startSaldenCrudRepository = new Mock<IStartSaldenCrudRepository>(MockBehavior.Strict);
            startSaldenCrudRepository.Setup(repository => repository.DoesStartSaldoExist(StartSaldoTestValues.IdDefault)).Returns(true);
            startSaldenCrudRepository.Setup(repository => repository.DoesStartSaldoExist(StartSaldoTestValues.IdDefault2)).Returns(true);
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldo(StartSaldoTestValues.IdDefault)).Returns(DbStartSaldoTest.Default());
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldo(StartSaldoTestValues.IdDefault2)).Returns(DbStartSaldoTest.Default2());
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldoDetail(StartSaldoTestValues.IdDefault)).Returns(DbStartSaldoDetailTest.Default());
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldoDetail(StartSaldoTestValues.IdDefault2)).Returns(DbStartSaldoDetailTest.Default2());
            startSaldenCrudRepository.Setup(repository => repository.GetPagedStartSalden()).Returns(DbStartSaldoListItemTest.ForPaged());
            startSaldenCrudRepository.Setup(repository => repository.UpdateStartSaldo(It.IsAny<IDbStartSaldoUpdate>())).Callback((IDbStartSaldoUpdate dbStartSaldoUpdate) =>
            {
                DbStartSaldoUpdateTest.AssertUpdated(dbStartSaldoUpdate);
            });
            startSaldenCrudRepository.Setup(repository => repository.DeleteStartSaldo(StartSaldoTestValues.IdDefault));
            startSaldenCrudRepository.Setup(repository => repository.DeleteStartSaldo(StartSaldoTestValues.IdDefault2));
            return startSaldenCrudRepository;
        }

        private Mock<IStartSaldenCrudRepository> SetupStartSaldenCrudRepositoryEmpty()
        {
            var startSaldenCrudRepository = new Mock<IStartSaldenCrudRepository>(MockBehavior.Strict);
            startSaldenCrudRepository.Setup(repository => repository.DoesStartSaldoExist(StartSaldoTestValues.IdDefault)).Returns(false);
            startSaldenCrudRepository.Setup(repository => repository.DoesStartSaldoExist(StartSaldoTestValues.IdDefault2)).Returns(false);
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldo(StartSaldoTestValues.IdDefault)).Returns(() => null);
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldo(StartSaldoTestValues.IdDefault2)).Returns(() => null);
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldoDetail(StartSaldoTestValues.IdDefault)).Returns(() => null);
            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldoDetail(StartSaldoTestValues.IdDefault2)).Returns(() => null);
            startSaldenCrudRepository.Setup(repository => repository.CreateStartSaldo(It.IsAny<IDbStartSaldo>())).Callback((IDbStartSaldo dbStartSaldo) =>
            {
                DbStartSaldoTest.AssertCreated(dbStartSaldo);
            });
            return startSaldenCrudRepository;
        }

        private Mock<IStartSaldenCrudRepository> SetupStartSaldenCrudRepositoryDeleteConflict()
        {
            var startSaldenCrudRepository = new Mock<IStartSaldenCrudRepository>(MockBehavior.Strict);
            startSaldenCrudRepository.Setup(repository => repository.DoesStartSaldoExist(StartSaldoTestValues.IdDefault)).Returns(true);
            startSaldenCrudRepository.Setup(repository => repository.DoesStartSaldoExist(StartSaldoTestValues.IdDefault2)).Returns(true);
            startSaldenCrudRepository.Setup(repository => repository.DeleteStartSaldo(StartSaldoTestValues.IdDefault)).Throws(new DbUpdateException());
            startSaldenCrudRepository.Setup(repository => repository.DeleteStartSaldo(StartSaldoTestValues.IdDefault2)).Throws(new DbUpdateException());
            return startSaldenCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(StartSaldoTestValues.IdForCreate);
            return guidGeneration;
        }
    }
}