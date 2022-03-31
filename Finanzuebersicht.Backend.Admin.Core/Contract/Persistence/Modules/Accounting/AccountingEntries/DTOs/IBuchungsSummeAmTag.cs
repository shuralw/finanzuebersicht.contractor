using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries
{
    public interface IBuchungsSummeAmTag
    {
        DateTime Buchungsdatum { get; set; }

        decimal Summe { get; set; }
    }
}