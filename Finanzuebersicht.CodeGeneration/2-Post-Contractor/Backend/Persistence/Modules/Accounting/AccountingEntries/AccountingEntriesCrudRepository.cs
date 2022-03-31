using Contract.Architecture.Backend.Common.Contract;
using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence;
using Finanzuebersicht.Backend.Generated.Contract.Contexts;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntriesCrudRepository : IAccountingEntriesCrudRepository
    {
        private readonly ISessionContext sessionContext;
        private readonly IPaginationContext paginationContext;

        private readonly PersistenceDbContext dbContext;

        public AccountingEntriesCrudRepository(
            ISessionContext sessionContext,
            IPaginationContext paginationContext,
            PersistenceDbContext dbContext)
        {
            this.sessionContext = sessionContext;
            this.paginationContext = paginationContext;

            this.dbContext = dbContext;
        }

        public void CreateAccountingEntry(IDbAccountingEntry dbAccountingEntry)
        {
            this.dbContext.AccountingEntries.Add(DbAccountingEntry.ToEfAccountingEntry(dbAccountingEntry, this.sessionContext.EmailUserId));
            this.dbContext.SaveChanges();
        }

        public void DeleteAccountingEntry(Guid accountingEntryId)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Where(efAccountingEntry => efAccountingEntry.Id == accountingEntryId)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.EmailUserId)
                .Single();

            this.dbContext.AccountingEntries.Remove(efAccountingEntry);
            this.dbContext.SaveChanges();
        }

        public bool DoesAccountingEntryExist(Guid accountingEntryId)
        {
            return this.dbContext.AccountingEntries
                .Any(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.EmailUserId && efAccountingEntry.Id == accountingEntryId);
        }

        public IDbAccountingEntry GetAccountingEntry(Guid accountingEntryId)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Where(efAccountingEntry => efAccountingEntry.Id == accountingEntryId)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbAccountingEntry.FromEfAccountingEntry(efAccountingEntry);
        }

        public IDbAccountingEntryDetail GetAccountingEntryDetail(Guid accountingEntryId)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Include(efAccountingEntry => efAccountingEntry.Category)
                .Where(efAccountingEntry => efAccountingEntry.Id == accountingEntryId)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbAccountingEntryDetail.FromEfAccountingEntry(efAccountingEntry);
        }

        public IDbPagedResult<IDbAccountingEntryListItem> GetPagedAccountingEntries()
        {
            var efAccountingEntries = this.dbContext.AccountingEntries
                .Include(efAccountingEntry => efAccountingEntry.Category)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.EmailUserId);

            return Pagination.Filter(
                efAccountingEntries,
                this.paginationContext,
                efAccountingEntry => DbAccountingEntryListItem.FromEfAccountingEntry(efAccountingEntry));
        }

        public IEnumerable<IDbAccountingEntry> GetAllAccountingEntries()
        {
            return this.dbContext.AccountingEntries
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.EmailUserId)
                .Select(efAccountingEntry => DbAccountingEntry.FromEfAccountingEntry(efAccountingEntry));
        }

        public void UpdateAccountingEntry(IDbAccountingEntryUpdate dbAccountingEntryUpdate)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Where(efAccountingEntry => efAccountingEntry.Id == dbAccountingEntryUpdate.Id)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            DbAccountingEntry.UpdateEfAccountingEntry(efAccountingEntry, dbAccountingEntryUpdate);

            this.dbContext.SaveChanges();
        }
    }
}