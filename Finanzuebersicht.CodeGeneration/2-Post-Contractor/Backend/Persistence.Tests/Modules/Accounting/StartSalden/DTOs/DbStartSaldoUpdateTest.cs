using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.StartSalden
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
                Id = StartSaldoTestValues.IdDbDefault,
                Betrag = StartSaldoTestValues.BetragForUpdate,
                DatumAm = StartSaldoTestValues.DatumAmForUpdate,
            };
        }
    }
}