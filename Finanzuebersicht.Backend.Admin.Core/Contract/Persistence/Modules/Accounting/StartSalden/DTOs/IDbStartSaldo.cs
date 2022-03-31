using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden
{
    public interface IDbStartSaldo
    {
        Guid Id { get; set; }

        decimal Betrag { get; set; }

        DateTime AmDatum { get; set; }
    }
}