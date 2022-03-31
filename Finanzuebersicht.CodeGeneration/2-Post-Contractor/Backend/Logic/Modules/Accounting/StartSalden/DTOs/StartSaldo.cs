using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.StartSalden
{
    internal class StartSaldo : IStartSaldo
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        internal static void UpdateDbStartSaldo(IDbStartSaldo dbStartSaldo, IStartSaldoUpdate startSaldoUpdate)
        {
            dbStartSaldo.Betrag = startSaldoUpdate.Betrag;
            dbStartSaldo.DatumAm = startSaldoUpdate.DatumAm;
        }

        internal static IStartSaldo FromDbStartSaldo(IDbStartSaldo dbStartSaldo)
        {
            if (dbStartSaldo == null)
            {
                return null;
            }

            return new StartSaldo()
            {
                Id = dbStartSaldo.Id,
                Betrag = dbStartSaldo.Betrag,
                DatumAm = dbStartSaldo.DatumAm,
            };
        }

        internal static IDbStartSaldo CreateDbStartSaldo(Guid startSaldoId, IStartSaldoCreate startSaldoCreate)
        {
            return new DbStartSaldo()
            {
                Id = startSaldoId,
                Betrag = startSaldoCreate.Betrag,
                DatumAm = startSaldoCreate.DatumAm,
            };
        }
    }
}