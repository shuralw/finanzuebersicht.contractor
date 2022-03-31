using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class StartSaldoDetailTest : IStartSaldoDetail
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IStartSaldoDetail Default()
        {
            return new StartSaldoDetailTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragDefault,
                DatumAm = StartSaldoTestValues.DatumAmDefault,
            };
        }

        public static IStartSaldoDetail Default2()
        {
            return new StartSaldoDetailTest()
            {
                Id = StartSaldoTestValues.IdDefault2,
                Betrag = StartSaldoTestValues.BetragDefault2,
                DatumAm = StartSaldoTestValues.DatumAmDefault2,
            };
        }

        public static void AssertDefault(IStartSaldoDetail startSaldoDetail)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault, startSaldoDetail.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault, startSaldoDetail.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault, startSaldoDetail.DatumAm);
        }

        public static void AssertDefault2(IStartSaldoDetail startSaldoDetail)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault2, startSaldoDetail.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault2, startSaldoDetail.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault2, startSaldoDetail.DatumAm);
        }
    }
}