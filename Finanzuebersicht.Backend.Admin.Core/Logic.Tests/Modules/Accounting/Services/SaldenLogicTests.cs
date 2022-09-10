using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Services
{
    [TestClass]
    public class SaldenLogicTests
    {
        [TestMethod]
        public void GetBuchungssummeAnTagen_Regular_Regular()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepository_Regular();
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepository();

            var logger = Mock.Of<ILogger<SaldenLogic>>();

            var saldenLogic = new SaldenLogic(
                accountingEntriesCrudRepository.Object,
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            var result = saldenLogic.GetBuchungssummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate);

            // Assert
            var expected = StartSaldenTestValues.BetragDefault + BuchungssummeAmTagTestValues.SummeSecondRegular;
            var actual = result.Data
                .First(buchungssumme => buchungssumme.Buchungsdatum == BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular)
                .Summe;

            Assert.AreEqual(2, result.Data.Count());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBuchungssummeAnTagen_EdgeDays_BothValues()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepository_EdgeDays();
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepository();

            var logger = Mock.Of<ILogger<SaldenLogic>>();

            var saldenLogic = new SaldenLogic(
                accountingEntriesCrudRepository.Object,
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            var result = saldenLogic.GetBuchungssummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate);

            // Assert
            var expected = StartSaldenTestValues.BetragDefault + BuchungssummeAmTagTestValues.SummeFirstDay1 + BuchungssummeAmTagTestValues.SummeFifthFifthDay28;

            Assert.AreEqual(expected, result.Data);
        }

        [TestMethod]
        public void GetBuchungssummeAnTagen_RegularPlusNegative_RegularPlusNegative()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepository_RegularPlusNegative();
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepository();

            var logger = Mock.Of<ILogger<SaldenLogic>>();

            var saldenLogic = new SaldenLogic(
                accountingEntriesCrudRepository.Object,
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            var result = saldenLogic.GetBuchungssummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate);

            // Assert
            var expected = StartSaldenTestValues.BetragDefault + BuchungssummeAmTagTestValues.SummeSecondRegular + BuchungssummeAmTagTestValues.SummeThirdNegative;

            Assert.AreEqual(expected, result.Data);
        }

        [TestMethod]
        public void GetBuchungssummeAnTagen_RegularPlusOutOfRange_OnlyRegular()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepository_RegularPlusOutOfRange();
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepository();

            var logger = Mock.Of<ILogger<SaldenLogic>>();

            var saldenLogic = new SaldenLogic(
                accountingEntriesCrudRepository.Object,
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            var result = saldenLogic.GetBuchungssummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate);

            // Assert
            var expected = StartSaldenTestValues.BetragDefault + BuchungssummeAmTagTestValues.SummeSecondRegular;

            Assert.AreEqual(expected, result.Data);
        }

        [TestMethod]
        public void GetBuchungssummeAnTagen_RegularPlusTwoAtSameDay_AllThreeValues()
        {
            // Arrange
            Mock<IAccountingEntriesCrudRepository> accountingEntriesCrudRepository = this.SetupAccountingEntriesCrudRepository_RegularPlusTwoAtSameDay();
            Mock<IStartSaldenCrudRepository> startSaldenCrudRepository = this.SetupStartSaldenCrudRepository();

            var logger = Mock.Of<ILogger<SaldenLogic>>();

            var saldenLogic = new SaldenLogic(
                accountingEntriesCrudRepository.Object,
                startSaldenCrudRepository.Object,
                null,
                logger);

            // Act
            var result = saldenLogic.GetBuchungssummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate);

            // Assert
            var expected = StartSaldenTestValues.BetragDefault + BuchungssummeAmTagTestValues.SummeSecondRegular
                + BuchungssummeAmTagTestValues.SummeThirdNegative
                + BuchungssummeAmTagTestValues.SummeFourtFourthSameDayAsThird;

            Assert.AreEqual(expected, result.Data);
        }

        private Mock<IStartSaldenCrudRepository> SetupStartSaldenCrudRepository()
        {
            var startSaldenCrudRepository = new Mock<IStartSaldenCrudRepository>(MockBehavior.Strict);

            startSaldenCrudRepository.Setup(repository => repository.GetStartSaldo()).Returns(DbStartSaldoTest.Default());

            return startSaldenCrudRepository;
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepository_Regular()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);

            accountingEntriesCrudRepository.Setup(repository => repository.GetBuchungsSummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate))
                .Returns(DbBuchungssummeAmTagTest.Regular());

            return accountingEntriesCrudRepository;
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepository_EdgeDays()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);

            accountingEntriesCrudRepository.Setup(repository => repository.GetBuchungsSummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate))
                .Returns(DbBuchungssummeAmTagTest.EdgeDays());

            return accountingEntriesCrudRepository;
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepository_RegularPlusNegative()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);

            accountingEntriesCrudRepository.Setup(repository => repository.GetBuchungsSummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate))
                .Returns(DbBuchungssummeAmTagTest.RegularPlusNegative());

            return accountingEntriesCrudRepository;
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepository_RegularPlusOutOfRange()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);

            accountingEntriesCrudRepository.Setup(repository => repository.GetBuchungsSummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate))
                .Returns(DbBuchungssummeAmTagTest.RegularPlusOutOfRange());

            return accountingEntriesCrudRepository;
        }

        private Mock<IAccountingEntriesCrudRepository> SetupAccountingEntriesCrudRepository_RegularPlusTwoAtSameDay()
        {
            var accountingEntriesCrudRepository = new Mock<IAccountingEntriesCrudRepository>(MockBehavior.Strict);

            accountingEntriesCrudRepository.Setup(repository => repository.GetBuchungsSummeAnTagen(BuchungssummeAmTagTestValues.FromDate, BuchungssummeAmTagTestValues.ToDate))
                .Returns(DbBuchungssummeAmTagTest.RegularPlusTwoAtSameDay());

            return accountingEntriesCrudRepository;
        }
    }
}
