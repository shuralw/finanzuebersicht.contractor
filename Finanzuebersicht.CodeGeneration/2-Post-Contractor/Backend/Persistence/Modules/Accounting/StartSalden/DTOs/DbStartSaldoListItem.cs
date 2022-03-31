using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoListItem : IDbStartSaldoListItem
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        internal static IDbStartSaldoListItem FromEfStartSaldo(EfStartSaldo efStartSaldo)
        {
            if (efStartSaldo == null)
            {
                return null;
            }

            return new DbStartSaldoListItem()
            {
                Id = efStartSaldo.Id,
                Betrag = efStartSaldo.Betrag,
                DatumAm = efStartSaldo.DatumAm,
            };
        }
    }
}