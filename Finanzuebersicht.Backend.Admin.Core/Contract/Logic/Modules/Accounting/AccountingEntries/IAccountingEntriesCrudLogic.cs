using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries
{
    public interface IAccountingEntriesCrudLogic
    {
        ILogicResult<Guid> CreateAccountingEntry(IAccountingEntryCreate accountingEntryCreate);

        Task<ILogicResult<Guid[]>> CreateAccountingEntries(IAsyncEnumerable<IAccountingEntryCreate> accountingEntryCreates);

        ILogicResult DeleteAccountingEntry(Guid accountingEntryId);

        ILogicResult<IAccountingEntryDetail> GetAccountingEntryDetail(Guid accountingEntryId);

        ILogicResult<IPagedResult<IAccountingEntryListItem>> GetPagedAccountingEntries();

        ILogicResult UpdateAccountingEntry(IAccountingEntryUpdate accountingEntryUpdate);
    }
}