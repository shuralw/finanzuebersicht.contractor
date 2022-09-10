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

        private readonly ILogger<SaldenLogic> logger;

        public SaldenLogic(
            IAccountingEntriesCrudRepository accountingEntriesCrudRepository,
            IStartSaldenCrudRepository startSaldenCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<SaldenLogic> logger)
        {
            this.accountingEntriesCrudRepository = accountingEntriesCrudRepository;
            this.startSaldenCrudRepository = startSaldenCrudRepository;

            this.logger = logger;
        }

        public ILogicResult<IEnumerable<IDbBuchungssummeAmTag>> GetBuchungssummeAnTagen(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<IDbBuchungssummeAmTag> tagesSalden = this.accountingEntriesCrudRepository.GetBuchungsSummeAnTagen(fromDate, toDate);
            IDbStartSaldo startSaldo = this.startSaldenCrudRepository.GetStartSaldo();

            decimal currentSaldo = startSaldo.Betrag;

            var liste = new List<BuchungssummeAmTag>();

            if (fromDate > startSaldo.AmDatum)
            {
                throw new Exception("Das FromDate darf nicht größer als Startsaldo Date sein.");
            }

            if (toDate < startSaldo.AmDatum)
            {
                throw new Exception("Das FromDate darf nicht größer als Startsaldo Date sein.");
            }

            IEnumerable<DateTime> tageMitRückwärtsrechnung = this.DateRange(fromDate, startSaldo.AmDatum.AddDays(-1))
                .Reverse();

            foreach (var date in tageMitRückwärtsrechnung)
            {
                var buchungsSummeAtDate = tagesSalden.ToList().SingleOrDefault(tagesSaldo =>
                     tagesSaldo.Buchungsdatum
                     .AddDays(-1)
                     .ToShortDateString().Equals(date.ToShortDateString()));

                if (buchungsSummeAtDate != null)
                {
                    currentSaldo -= buchungsSummeAtDate.Summe;
                }

                liste.Add(new BuchungssummeAmTag
                {
                    Buchungsdatum = date,
                    Summe = currentSaldo,
                });
            }

            currentSaldo = startSaldo.Betrag;

            IEnumerable<DateTime> tageMitVorwärtsrechnung = this.DateRange(startSaldo.AmDatum, toDate);
            foreach (var date in tageMitVorwärtsrechnung)
            {
                var buchungsSummeAtDate = tagesSalden.ToList().SingleOrDefault(tagesSaldo =>
                   tagesSaldo.Buchungsdatum.ToShortDateString().Equals(date.ToShortDateString()));

                if (buchungsSummeAtDate != null)
                {
                    currentSaldo += buchungsSummeAtDate.Summe;
                }

                liste.Add(new BuchungssummeAmTag
                {
                    Buchungsdatum = date,
                    Summe = currentSaldo,
                });
            }

            this.logger.LogDebug("AccountingEntries wurden geladen");
            return LogicResult<IEnumerable<IDbBuchungssummeAmTag>>.Ok(liste);
        }

        private IEnumerable<DateTime> DateRange(DateTime fromDate, DateTime toDate)
        {
            return Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1)
                .Select(d => fromDate.AddDays(d));
        }
    }
}