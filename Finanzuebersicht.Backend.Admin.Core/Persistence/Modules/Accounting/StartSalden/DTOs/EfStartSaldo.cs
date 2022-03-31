using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.StartSalden
{
    public class EfStartSaldo
    {
        public EfStartSaldo()
        {
        }

        public Guid Id { get; set; }

        public Guid EmailUserId { get; set; }

        public decimal Betrag { get; set; }

        public DateTime AmDatum { get; set; }
    }
}