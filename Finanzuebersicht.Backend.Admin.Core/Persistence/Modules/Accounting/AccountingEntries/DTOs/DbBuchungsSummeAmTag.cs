using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries
{
    internal class DbBuchungssummeAmTag : IDbBuchungssummeAmTag
    {
        public decimal Summe { get; set; }

        public DateTime Buchungsdatum { get; set; }
    }
}