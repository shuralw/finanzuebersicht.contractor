using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries
{
    internal class BuchungsSummeAmTag : IBuchungsSummeAmTag
    {
        public decimal Summe { get; set; }

        public DateTime Buchungsdatum { get; set; }
    }
}