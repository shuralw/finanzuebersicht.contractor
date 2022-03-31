using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden
{
    public interface IDbStartSaldoUpdate
    {
        Guid Id { get; set; }

        double Betrag { get; set; }

        DateTime DatumAm { get; set; }
    }
}