using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.StartSalden
{
    internal class StartSaldoListItem : IStartSaldoListItem
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        internal static IStartSaldoListItem FromDbStartSaldoListItem(IDbStartSaldoListItem dbStartSaldoListItem)
        {
            if (dbStartSaldoListItem == null)
            {
                return null;
            }

            return new StartSaldoListItem()
            {
                Id = dbStartSaldoListItem.Id,
                Betrag = dbStartSaldoListItem.Betrag,
                DatumAm = dbStartSaldoListItem.DatumAm,
            };
        }
    }
}