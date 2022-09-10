using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
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
            if (StartSaldenTestValues.AmDatumDefault > BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular)
            {
                throw new Exception("Das Saldumsdatum sollte entweder vor dem Buchungsdatum vom Regular liegen oder es müssen die expected Werte angepasst werden.");
            }

            var expected_TagVorDerBuchung = StartSaldenTestValues.BetragDefault;
            var expected_TagDerBuchung = StartSaldenTestValues.BetragDefault + BuchungssummeAmTagTestValues.SummeSecondRegular;
            var expected_TagNachDerBuchung = expected_TagDerBuchung;

            decimal actual_TagVorDerBuchung = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular.AddDays(-1));
            decimal actual_TagDerBuchung = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular);
            decimal actual_TagNachDerBuchung = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular.AddDays(1));

            Assert.AreEqual(29, result.Data.Count());
            Assert.AreEqual(expected_TagVorDerBuchung, actual_TagVorDerBuchung);
            Assert.AreEqual(expected_TagDerBuchung, actual_TagDerBuchung);
            Assert.AreEqual(expected_TagNachDerBuchung, actual_TagNachDerBuchung);
        }

        private static decimal GetSummeAmTag(ILogicResult<IEnumerable<IDbBuchungssummeAmTag>> result, DateTime stichtag)
        {
            return result.Data
                .First(buchungssumme => buchungssumme.Buchungsdatum == stichtag)
                .Summe;
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
            if (StartSaldenTestValues.AmDatumDefault > BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular)
            {
                throw new Exception("Das Saldumsdatum sollte entweder vor dem Buchungsdatum vom Regular liegen oder es müssen die expected Werte angepasst werden.");
            }

            var expected_Tag1 = StartSaldenTestValues.BetragDefault;
            var expected_VorTag1 = StartSaldenTestValues.BetragDefault - BuchungssummeAmTagTestValues.SummeFirstDay1;
            var expected_Tag31 = StartSaldenTestValues.BetragDefault + BuchungssummeAmTagTestValues.SummeFifthFifthDay28;

            decimal actual_Tag1 = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumFirstDay1);
            decimal actual_VorTag1 = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumFirstDay1.AddDays(-1));
            decimal actual_Tag31 = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumFifthDay28);

            Assert.AreEqual(29, result.Data.Count());
            Assert.AreEqual(expected_Tag1, actual_Tag1);
            Assert.AreEqual(expected_VorTag1, actual_VorTag1);
            Assert.AreEqual(expected_Tag31, actual_Tag31);
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
            if (StartSaldenTestValues.AmDatumDefault > BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular)
            {
                throw new Exception("Das Saldumsdatum sollte entweder vor dem Buchungsdatum vom Regular liegen oder es müssen die expected Werte angepasst werden.");
            }

            var expected_TagDerNegativBuchung = StartSaldenTestValues.BetragDefault
                + BuchungssummeAmTagTestValues.SummeSecondRegular
                + BuchungssummeAmTagTestValues.SummeThirdNegative;

            decimal actual_TagDerNegativBuchung = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumThirdNegative);

            Assert.AreEqual(29, result.Data.Count());
            Assert.AreEqual(expected_TagDerNegativBuchung, actual_TagDerNegativBuchung);
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
            if (StartSaldenTestValues.AmDatumDefault > BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular)
            {
                throw new Exception("Das Saldumsdatum sollte entweder vor dem Buchungsdatum vom Regular liegen oder es müssen die expected Werte angepasst werden.");
            }

            var expected_Tag28 = StartSaldenTestValues.BetragDefault
                + BuchungssummeAmTagTestValues.SummeSecondRegular;

            decimal actual_Tag28 = GetSummeAmTag(result, BuchungssummeAmTagTestValues.BuchungsdatumFifthDay28);

            Assert.AreEqual(29, result.Data.Count());
            Assert.AreEqual(expected_Tag28, actual_Tag28);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void GetBuchungssummeAnTagen_TwoAtSameDay_SingleException()
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
