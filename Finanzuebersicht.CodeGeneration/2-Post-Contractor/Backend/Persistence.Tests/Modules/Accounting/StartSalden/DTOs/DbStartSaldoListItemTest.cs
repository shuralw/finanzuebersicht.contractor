using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoListItemTest : IDbStartSaldoListItem
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static void AssertDbDefault(IDbStartSaldoListItem dbStartSaldoListItem)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDbDefault, dbStartSaldoListItem.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDbDefault, dbStartSaldoListItem.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDbDefault, dbStartSaldoListItem.DatumAm);
        }

        public static void AssertDbDefault2(IDbStartSaldoListItem dbStartSaldoListItem)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDbDefault2, dbStartSaldoListItem.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDbDefault2, dbStartSaldoListItem.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDbDefault2, dbStartSaldoListItem.DatumAm);
        }
    }
}