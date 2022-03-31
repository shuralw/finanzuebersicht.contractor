using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries
{
    internal class SaldenLogic : ISaldenLogic
    {
        private readonly IAccountingEntriesCrudRepository accountingEntriesCrudRepository;
        private readonly IStartSaldenCrudRepository startSaldenCrudRepository;

        private readonly ILogger<AccountingEntriesCrudLogic> logger;

        public SaldenLogic(
            IAccountingEntriesCrudRepository accountingEntriesCrudRepository,
            IStartSaldenCrudRepository startSaldenCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<AccountingEntriesCrudLogic> logger)
        {
            this.accountingEntriesCrudRepository = accountingEntriesCrudRepository;
            this.startSaldenCrudRepository = startSaldenCrudRepository;

            this.logger = logger;
        }

        public ILogicResult<IEnumerable<IBuchungsSummeAmTag>> GetBuchungssummeAnTagen(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<IBuchungsSummeAmTag> tagesSalden = this.accountingEntriesCrudRepository.GetBuchungsSummeAnTagen(fromDate, toDate);
            IDbStartSaldo startSaldo = this.startSaldenCrudRepository.GetStartSaldo();

            decimal currentSaldo = startSaldo.Betrag;

            // Takes each day and increments the current saldo at each day
            List<BuchungsSummeAmTag> result = this.DateRange(fromDate, toDate)
                .Where(date => date <= startSaldo.AmDatum)
                .Reverse()
                .Select(date =>
                {
                    var buchungsSummeAtDate = tagesSalden.ToList().Find(tagesSaldo =>
                       tagesSaldo.Buchungsdatum.ToShortDateString().Equals(date.ToShortDateString()));

                    if (buchungsSummeAtDate != null)
                    {
                        currentSaldo -= buchungsSummeAtDate.Summe;
                    }

                    return new BuchungsSummeAmTag { Buchungsdatum = date, Summe = currentSaldo };
                })
                .ToList();

            result.Concat(this.DateRange(fromDate, toDate)
                .Where(date => date > startSaldo.AmDatum)
                .Select(date =>
                {
                    var buchungsSummeAtDate = tagesSalden.ToList().Find(tagesSaldo =>
                       tagesSaldo.Buchungsdatum.ToShortDateString().Equals(date.ToShortDateString()));

                    if (buchungsSummeAtDate != null)
                    {
                        currentSaldo += buchungsSummeAtDate.Summe;
                    }

                    return new BuchungsSummeAmTag { Buchungsdatum = date, Summe = currentSaldo };
                })
                .ToList());

            this.logger.LogDebug("AccountingEntries wurden geladen");
            return LogicResult<IEnumerable<IBuchungsSummeAmTag>>.Ok(result);
        }

        private IEnumerable<DateTime> DateRange(DateTime fromDate, DateTime toDate)
        {
            return Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1)
                .Select(d => fromDate.AddDays(d));
        }
    }
}