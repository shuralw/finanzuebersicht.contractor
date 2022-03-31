using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden
{
    public interface IDbStartSaldoDetail
    {
        Guid Id { get; set; }

        decimal Betrag { get; set; }

        DateTime AmDatum { get; set; }
    }
}