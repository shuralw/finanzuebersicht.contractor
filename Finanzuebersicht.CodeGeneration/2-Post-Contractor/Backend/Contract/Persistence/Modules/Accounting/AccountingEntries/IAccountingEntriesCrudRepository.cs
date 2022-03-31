using Contract.Architecture.Backend.Common.Contract.Persistence;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries
{
    public interface IAccountingEntriesCrudRepository
    {
        void CreateAccountingEntry(IDbAccountingEntry dbAccountingEntry);

        void DeleteAccountingEntry(Guid accountingEntryId);

        bool DoesAccountingEntryExist(Guid accountingEntryId);

        IDbAccountingEntry GetAccountingEntry(Guid accountingEntryId);

        IDbAccountingEntryDetail GetAccountingEntryDetail(Guid accountingEntryId);

        IDbPagedResult<IDbAccountingEntryListItem> GetPagedAccountingEntries();

        IEnumerable<IDbAccountingEntry> GetAllAccountingEntries();

        void UpdateAccountingEntry(IDbAccountingEntryUpdate dbAccountingEntryUpdate);
    }
}