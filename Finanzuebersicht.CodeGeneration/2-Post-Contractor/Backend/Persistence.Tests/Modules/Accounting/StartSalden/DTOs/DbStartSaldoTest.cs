using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoTest : IDbStartSaldo
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IDbStartSaldo DbDefault()
        {
            return new DbStartSaldoTest()
            {
                Id = StartSaldoTestValues.IdDbDefault,
                Betrag = StartSaldoTestValues.BetragDbDefault,
                DatumAm = StartSaldoTestValues.DatumAmDbDefault,
            };
        }

        public static IDbStartSaldo DbDefault2()
        {
            return new DbStartSaldoTest()
            {
                Id = StartSaldoTestValues.IdDbDefault2,
                Betrag = StartSaldoTestValues.BetragDbDefault2,
                DatumAm = StartSaldoTestValues.DatumAmDbDefault2,
            };
        }

        public static IDbStartSaldo ForCreate()
        {
            return new DbStartSaldoTest()
            {
                Id = StartSaldoTestValues.IdForCreate,
                Betrag = StartSaldoTestValues.BetragForCreate,
                DatumAm = StartSaldoTestValues.DatumAmForCreate,
            };
        }

        public static void AssertDbDefault(IDbStartSaldo dbStartSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDbDefault, dbStartSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDbDefault, dbStartSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDbDefault, dbStartSaldo.DatumAm);
        }

        public static void AssertDbDefault2(IDbStartSaldo dbStartSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDbDefault2, dbStartSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDbDefault2, dbStartSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDbDefault2, dbStartSaldo.DatumAm);
        }

        public static void AssertForCreate(IDbStartSaldo dbStartSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdForCreate, dbStartSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragForCreate, dbStartSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmForCreate, dbStartSaldo.DatumAm);
        }

        public static void AssertForUpdate(IDbStartSaldo dbStartSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDbDefault, dbStartSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragForUpdate, dbStartSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmForUpdate, dbStartSaldo.DatumAm);
        }
    }
}