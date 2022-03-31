using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class StartSaldoTest : IStartSaldo
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IStartSaldo Default()
        {
            return new StartSaldoTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragDefault,
                DatumAm = StartSaldoTestValues.DatumAmDefault,
            };
        }

        public static IStartSaldo Default2()
        {
            return new StartSaldoTest()
            {
                Id = StartSaldoTestValues.IdDefault2,
                Betrag = StartSaldoTestValues.BetragDefault2,
                DatumAm = StartSaldoTestValues.DatumAmDefault2,
            };
        }

        public static void AssertDefault(IStartSaldo startSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault, startSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault, startSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault, startSaldo.DatumAm);
        }

        public static void AssertDefault2(IStartSaldo startSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault2, startSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault2, startSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault2, startSaldo.DatumAm);
        }
    }
}