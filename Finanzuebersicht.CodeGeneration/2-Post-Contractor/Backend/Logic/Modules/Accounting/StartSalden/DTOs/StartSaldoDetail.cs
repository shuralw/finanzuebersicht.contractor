using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.StartSalden
{
    internal class StartSaldoDetail : IStartSaldoDetail
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        internal static IStartSaldoDetail FromDbStartSaldoDetail(IDbStartSaldoDetail dbStartSaldoDetail)
        {
            if (dbStartSaldoDetail == null)
            {
                return null;
            }

            return new StartSaldoDetail()
            {
                Id = dbStartSaldoDetail.Id,
                Betrag = dbStartSaldoDetail.Betrag,
                DatumAm = dbStartSaldoDetail.DatumAm,
            };
        }
    }
}