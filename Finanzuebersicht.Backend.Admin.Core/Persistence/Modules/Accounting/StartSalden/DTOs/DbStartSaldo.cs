using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.StartSalden
{
    internal class DbStartSaldo : IDbStartSaldo
    {
        public Guid Id { get; set; }

        public decimal Betrag { get; set; }

        public DateTime AmDatum { get; set; }

        internal static void UpdateEfStartSaldo(EfStartSaldo efStartSaldo, IDbStartSaldoUpdate dbStartSaldoUpdate)
        {
            efStartSaldo.Betrag = dbStartSaldoUpdate.Betrag;
            efStartSaldo.AmDatum = dbStartSaldoUpdate.AmDatum;
        }

        internal static IDbStartSaldo FromEfStartSaldo(EfStartSaldo efStartSaldo)
        {
            if (efStartSaldo == null)
            {
                return null;
            }

            return new DbStartSaldo()
            {
                Id = efStartSaldo.Id,
                Betrag = efStartSaldo.Betrag,
                AmDatum = efStartSaldo.AmDatum,
            };
        }

        internal static EfStartSaldo ToEfStartSaldo(IDbStartSaldo dbStartSaldo, Guid emailUserId)
        {
            return new EfStartSaldo()
            {
                Id = dbStartSaldo.Id,
                EmailUserId = emailUserId,
                Betrag = dbStartSaldo.Betrag,
                AmDatum = dbStartSaldo.AmDatum,
            };
        }
    }
}