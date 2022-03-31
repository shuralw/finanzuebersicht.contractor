using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden
{
    public interface IStartSaldo
    {
        Guid Id { get; set; }

        double Betrag { get; set; }

        DateTime DatumAm { get; set; }
    }
}