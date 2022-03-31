using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class StartSaldoUpdateTest : IStartSaldoUpdate
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IStartSaldoUpdate ForUpdate()
        {
            return new StartSaldoUpdateTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragForUpdate,
                DatumAm = StartSaldoTestValues.DatumAmForUpdate,
            };
        }
    }
}