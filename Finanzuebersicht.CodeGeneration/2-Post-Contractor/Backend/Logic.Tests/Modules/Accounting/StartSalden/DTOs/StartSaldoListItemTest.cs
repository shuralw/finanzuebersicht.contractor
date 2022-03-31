using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class StartSaldoListItemTest : IStartSaldoListItem
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static void AssertDefault(IStartSaldoListItem startSaldoListItem)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault, startSaldoListItem.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault, startSaldoListItem.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault, startSaldoListItem.DatumAm);
        }

        public static void AssertDefault2(IStartSaldoListItem startSaldoListItem)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault2, startSaldoListItem.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault2, startSaldoListItem.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault2, startSaldoListItem.DatumAm);
        }
    }
}