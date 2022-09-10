using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries
{
    public interface ISaldenLogic
    {
        ILogicResult<IEnumerable<IDbBuchungssummeAmTag>> GetBuchungssummeAnTagen(DateTime fromDate, DateTime toDate);
    }
}