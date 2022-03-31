using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class StartSaldoCreateTest : IStartSaldoCreate
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IStartSaldoCreate ForCreate()
        {
            return new StartSaldoCreateTest()
            {
                Id = StartSaldoTestValues.IdForCreate,
                Betrag = StartSaldoTestValues.BetragForCreate,
                DatumAm = StartSaldoTestValues.DatumAmForCreate,
            };
        }
    }
}