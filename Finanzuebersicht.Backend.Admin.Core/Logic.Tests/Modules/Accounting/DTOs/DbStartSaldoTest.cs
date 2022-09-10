using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.DTOs
{
    internal class DbStartSaldoTest : IDbStartSaldo
    {
        public Guid Id { get; set; }

        public decimal Betrag { get; set; }

        public DateTime AmDatum { get; set; }

        public static IDbStartSaldo Default()
        {
            return new DbStartSaldoTest()
            {
                Id = StartSaldenTestValues.IdDefault,
                Betrag = StartSaldenTestValues.BetragDefault,
                AmDatum = StartSaldenTestValues.AmDatumDefault,
            };
        }
    }
}
