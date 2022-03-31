using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.StartSalden
{
    public class EfStartSaldo
    {
        public EfStartSaldo()
        {
        }

        public Guid Id { get; set; }

        public Guid EmailUserId { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }
    }
}