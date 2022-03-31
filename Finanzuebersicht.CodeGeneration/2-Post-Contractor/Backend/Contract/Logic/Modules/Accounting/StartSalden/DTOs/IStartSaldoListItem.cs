using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden
{
    public interface IStartSaldoListItem
    {
        Guid Id { get; set; }

        double Betrag { get; set; }

        DateTime DatumAm { get; set; }
    }
}