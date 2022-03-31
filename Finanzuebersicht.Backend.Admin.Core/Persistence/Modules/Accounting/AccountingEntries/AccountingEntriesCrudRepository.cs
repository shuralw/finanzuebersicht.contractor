using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries
{
    internal partial class AccountingEntriesCrudRepository : IAccountingEntriesCrudRepository
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
            this.dbContext.AccountingEntries.Add(DbAccountingEntry.ToEfAccountingEntry(dbAccountingEntry, this.sessionContext.AdminEmailUserId.Value));
            this.dbContext.SaveChanges();
        }

        public void DeleteAccountingEntry(Guid accountingEntryId)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Where(efAccountingEntry => efAccountingEntry.Id == accountingEntryId)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Single();

            this.dbContext.AccountingEntries.Remove(efAccountingEntry);
            this.dbContext.SaveChanges();
        }

        public bool DoesAccountingEntryExist(Guid accountingEntryId)
        {
            return this.dbContext.AccountingEntries
                .Any(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId && efAccountingEntry.Id == accountingEntryId);
        }

        public IDbAccountingEntry GetAccountingEntry(Guid accountingEntryId)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Where(efAccountingEntry => efAccountingEntry.Id == accountingEntryId)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbAccountingEntry.FromEfAccountingEntry(efAccountingEntry);
        }

        public IDbAccountingEntryDetail GetAccountingEntryDetail(Guid accountingEntryId)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Include(efAccountingEntry => efAccountingEntry.Category)
                .Where(efAccountingEntry => efAccountingEntry.Id == accountingEntryId)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbAccountingEntryDetail.FromEfAccountingEntry(efAccountingEntry);
        }

        public IDbPagedResult<IDbAccountingEntryListItem> GetPagedAccountingEntries()
        {
            var efAccountingEntries = this.dbContext.AccountingEntries
                .Include(efAccountingEntry => efAccountingEntry.Category)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId);

            return Pagination.Filter(
                efAccountingEntries,
                this.paginationContext,
                efAccountingEntry => DbAccountingEntryListItem.FromEfAccountingEntry(efAccountingEntry));
        }

        public IEnumerable<IDbAccountingEntryListItem> GetAccountingEntries(DateTime fromDate, DateTime toDate)
        {
            var efAccountingEntries = this.dbContext.AccountingEntries
                .Include(efAccountingEntry => efAccountingEntry.Category)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Where(efAccountingEntry => efAccountingEntry.Buchungsdatum >= fromDate && efAccountingEntry.Buchungsdatum < toDate);

            return efAccountingEntries.Select(efAccountingEntry => DbAccountingEntryListItem.FromEfAccountingEntry(efAccountingEntry));
        }


        public IEnumerable<IDbAccountingEntryChartItem> GetAllAccountingEntries()
        {
            return this.dbContext.AccountingEntries
                .Include(efAccountingEntry => efAccountingEntry.Category)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Select(efAccountingEntry => DbAccountingEntryChartItem.FromEfAccountingEntry(efAccountingEntry));
        }

        public void UpdateAccountingEntry(IDbAccountingEntryUpdate dbAccountingEntryUpdate)
        {
            EfAccountingEntry efAccountingEntry = this.dbContext.AccountingEntries
                .Where(efAccountingEntry => efAccountingEntry.Id == dbAccountingEntryUpdate.Id)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            DbAccountingEntry.UpdateEfAccountingEntry(efAccountingEntry, dbAccountingEntryUpdate);

            this.dbContext.SaveChanges();
        }

        public IEnumerable<IBuchungsSummeAmTag> GetBuchungsSummeAnTagen(DateTime fromDate, DateTime toDate)
        {
            var x = this.dbContext.AccountingEntries
                .Where(accountingEntry => accountingEntry.Buchungsdatum >= fromDate && accountingEntry.Buchungsdatum <= toDate)
                .Where(efAccountingEntry => efAccountingEntry.EmailUserId == this.sessionContext.AdminEmailUserId)
                .ToList()
                .GroupBy(accountingEntry => accountingEntry.Buchungsdatum)
                .ToList()
                .Select(groupedAccountingEntry => new BuchungsSummeAmTag()
                {
                    Buchungsdatum = groupedAccountingEntry.First().Buchungsdatum,
                    Summe = groupedAccountingEntry.Sum(accountingEntry => (accountingEntry.Betrag == null ? 0 : accountingEntry.Betrag.Value))
                });
            x.ToList();
            return x;
        }
    }
}