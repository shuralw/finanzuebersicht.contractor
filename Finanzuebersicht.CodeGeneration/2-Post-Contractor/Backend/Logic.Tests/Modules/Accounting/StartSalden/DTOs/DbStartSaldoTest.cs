using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoTest : IDbStartSaldo
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IDbStartSaldo Default()
        {
            return new DbStartSaldoTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragDefault,
                DatumAm = StartSaldoTestValues.DatumAmDefault,
            };
        }

        public static IDbStartSaldo Default2()
        {
            return new DbStartSaldoTest()
            {
                Id = StartSaldoTestValues.IdDefault2,
                Betrag = StartSaldoTestValues.BetragDefault2,
                DatumAm = StartSaldoTestValues.DatumAmDefault2,
            };
        }

        public static void AssertDefault(IDbStartSaldo dbStartSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault, dbStartSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault, dbStartSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault, dbStartSaldo.DatumAm);
        }

        public static void AssertDefault2(IDbStartSaldo dbStartSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault2, dbStartSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragDefault2, dbStartSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmDefault2, dbStartSaldo.DatumAm);
        }

        public static void AssertCreated(IDbStartSaldo dbStartSaldo)
        {
            Assert.AreEqual(StartSaldoTestValues.IdForCreate, dbStartSaldo.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragForCreate, dbStartSaldo.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmForCreate, dbStartSaldo.DatumAm);
        }
    }
}