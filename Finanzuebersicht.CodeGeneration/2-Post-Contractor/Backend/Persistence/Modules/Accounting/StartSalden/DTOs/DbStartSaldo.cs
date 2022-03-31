using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.StartSalden
{
    internal class DbStartSaldo : IDbStartSaldo
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        internal static void UpdateEfStartSaldo(EfStartSaldo efStartSaldo, IDbStartSaldoUpdate dbStartSaldoUpdate)
        {
            efStartSaldo.Betrag = dbStartSaldoUpdate.Betrag;
            efStartSaldo.DatumAm = dbStartSaldoUpdate.DatumAm;
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
                DatumAm = efStartSaldo.DatumAm,
            };
        }

        internal static EfStartSaldo ToEfStartSaldo(IDbStartSaldo dbStartSaldo, Guid emailUserId)
        {
            return new EfStartSaldo()
            {
                Id = dbStartSaldo.Id,
                EmailUserId = emailUserId,
                Betrag = dbStartSaldo.Betrag,
                DatumAm = dbStartSaldo.DatumAm,
            };
        }
    }
}