using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoDetailTest : IDbStartSaldoDetail
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static void AssertDbDefault(IDbStartSaldoDetail dbStartSaldoDetail)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDbDefault, dbStartSaldoDetail.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDbDefault, dbStartSaldoDetail.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDbDefault, dbStartSaldoDetail.DatumAm);
        }
    }
}