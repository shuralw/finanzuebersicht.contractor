using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoDetail : IDbStartSaldoDetail
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        internal static IDbStartSaldoDetail FromEfStartSaldo(EfStartSaldo efStartSaldo)
        {
            if (efStartSaldo == null)
            {
                return null;
            }

            return new DbStartSaldoDetail()
            {
                Id = efStartSaldo.Id,
                Betrag = efStartSaldo.Betrag,
                DatumAm = efStartSaldo.DatumAm,
            };
        }
    }
}