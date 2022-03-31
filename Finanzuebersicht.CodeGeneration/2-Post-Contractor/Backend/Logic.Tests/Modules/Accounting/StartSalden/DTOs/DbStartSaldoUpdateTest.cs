using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoUpdateTest : IDbStartSaldoUpdate
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IDbStartSaldoUpdate ForUpdate()
        {
            return new DbStartSaldoUpdateTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragForUpdate,
                DatumAm = StartSaldoTestValues.DatumAmForUpdate,
            };
        }

        public static void AssertUpdated(IDbStartSaldoUpdate dbStartSaldoUpdate)
        {
            Assert.AreEqual(StartSaldoTestValues.IdDefault, dbStartSaldoUpdate.Id);
            Assert.AreEqual(StartSaldoTestValues.BetragForUpdate, dbStartSaldoUpdate.Betrag);
            Assert.AreEqual(StartSaldoTestValues.DatumAmForUpdate, dbStartSaldoUpdate.DatumAm);
        }
    }
}