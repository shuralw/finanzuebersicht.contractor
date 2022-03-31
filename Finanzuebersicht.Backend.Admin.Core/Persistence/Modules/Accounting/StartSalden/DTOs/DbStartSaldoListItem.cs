using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoListItem : IDbStartSaldoListItem
    {
        public Guid Id { get; set; }

        public decimal Betrag { get; set; }

        public DateTime AmDatum { get; set; }

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
                AmDatum = efStartSaldo.AmDatum,
            };
        }
    }
}