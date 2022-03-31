using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoUpdate : IDbStartSaldoUpdate
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        internal static IDbStartSaldoUpdate FromStartSaldoUpdate(IStartSaldoUpdate startSaldoUpdate)
        {
            return new DbStartSaldoUpdate()
            {
                Id = startSaldoUpdate.Id,
                Betrag = startSaldoUpdate.Betrag,
                DatumAm = startSaldoUpdate.DatumAm,
            };
        }
    }
}