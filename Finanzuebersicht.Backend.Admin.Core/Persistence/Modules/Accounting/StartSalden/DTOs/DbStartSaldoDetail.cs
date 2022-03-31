using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoDetail : IDbStartSaldoDetail
    {
        public Guid Id { get; set; }

        public decimal Betrag { get; set; }

        public DateTime AmDatum { get; set; }

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
                AmDatum = efStartSaldo.AmDatum,
            };
        }
    }
}