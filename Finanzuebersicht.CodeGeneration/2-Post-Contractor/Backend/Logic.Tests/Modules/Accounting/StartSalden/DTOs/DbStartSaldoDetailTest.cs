using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoDetailTest : IDbStartSaldoDetail
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IDbStartSaldoDetail Default()
        {
            return new DbStartSaldoDetailTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragDefault,
                DatumAm = StartSaldoTestValues.DatumAmDefault,
            };
        }

        public static IDbStartSaldoDetail Default2()
        {
            return new DbStartSaldoDetailTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragDefault2,
                DatumAm = StartSaldoTestValues.DatumAmDefault2,
            };
        }

        public static void AssertDefault(IDbStartSaldoDetail dbStartSaldoDetail)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault, dbStartSaldoDetail.Id);
        }

        public static void AssertDefault2(IDbStartSaldoDetail dbStartSaldoDetail)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault2, dbStartSaldoDetail.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault2, dbStartSaldoDetail.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault2, dbStartSaldoDetail.DatumAm);
        }
    }
}