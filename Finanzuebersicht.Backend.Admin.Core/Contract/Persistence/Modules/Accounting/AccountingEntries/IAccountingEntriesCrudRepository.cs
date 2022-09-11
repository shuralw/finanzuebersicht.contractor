using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries
{
    public interface IAccountingEntriesCrudRepository
    {
        void CreateAccountingEntry(IDbAccountingEntry dbAccountingEntry);

        void DeleteAccountingEntry(Guid accountingEntryId);

        bool DoesAccountingEntryExist(Guid accountingEntryId);

        IDbAccountingEntry GetAccountingEntry(Guid accountingEntryId);

        IDbAccountingEntryDetail GetAccountingEntryDetail(Guid accountingEntryId);

        IDbPagedResult<IDbAccountingEntryListItem> GetPagedAccountingEntries();

        IEnumerable<IDbAccountingEntryChartItem> GetAccountingEntries(IEnumerable<Guid> categoryId);

        void UpdateAccountingEntry(IDbAccountingEntryUpdate dbAccountingEntryUpdate);

        IEnumerable<IDbBuchungssummeAmTag> GetBuchungsSummeAnTagen(DateTime fromDate, DateTime toDate);

        IEnumerable<IDbAccountingEntryListItem> GetAccountingEntries(DateTime fromDate, DateTime toDate);
    }
}