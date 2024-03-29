﻿using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries
{
    internal class BuchungssummeAmTag : IDbBuchungssummeAmTag
    {
        public decimal Summe { get; set; }

        public DateTime Buchungsdatum { get; set; }
    }
}