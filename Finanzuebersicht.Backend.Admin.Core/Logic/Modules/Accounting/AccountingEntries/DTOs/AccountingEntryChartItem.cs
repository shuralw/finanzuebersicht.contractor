using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntryChartItem : IAccountingEntryChartItem
    {
        public Guid Id { get; set; }

        public ICategory Category { get; set; }

        public string Auftragskonto { get; set; }

        public DateTime Buchungsdatum { get; set; }

        public DateTime ValutaDatum { get; set; }

        public string Buchungstext { get; set; }

        public string Verwendungszweck { get; set; }

        public string GlaeubigerId { get; set; }

        public string Mandatsreferenz { get; set; }

        public string Sammlerreferenz { get; set; }

        public decimal? LastschriftUrsprungsbetrag { get; set; }

        public string AuslagenersatzRuecklastschrift { get; set; }

        public string Beguenstigter { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        public decimal? Betrag { get; set; }

        public string Waehrung { get; set; }

        public string Info { get; set; }

        internal static IAccountingEntryChartItem FromDbAccountingEntryChartItem(IDbAccountingEntryChartItem dbAccountingEntryChartItem)
        {
            if (dbAccountingEntryChartItem == null)
            {
                return null;
            }

            return new AccountingEntryChartItem()
            {
                Id = dbAccountingEntryChartItem.Id,
                Category = Accounting.Categories.Category.FromDbCategory(dbAccountingEntryChartItem.Category),
                Auftragskonto = dbAccountingEntryChartItem.Auftragskonto,
                Buchungsdatum = dbAccountingEntryChartItem.Buchungsdatum,
                ValutaDatum = dbAccountingEntryChartItem.ValutaDatum,
                Buchungstext = dbAccountingEntryChartItem.Buchungstext,
                Verwendungszweck = dbAccountingEntryChartItem.Verwendungszweck,
                GlaeubigerId = dbAccountingEntryChartItem.GlaeubigerId,
                Mandatsreferenz = dbAccountingEntryChartItem.Mandatsreferenz,
                Sammlerreferenz = dbAccountingEntryChartItem.Sammlerreferenz,
                LastschriftUrsprungsbetrag = dbAccountingEntryChartItem.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = dbAccountingEntryChartItem.AuslagenersatzRuecklastschrift,
                Beguenstigter = dbAccountingEntryChartItem.Beguenstigter,
                IBAN = dbAccountingEntryChartItem.IBAN,
                BIC = dbAccountingEntryChartItem.BIC,
                Betrag = dbAccountingEntryChartItem.Betrag,
                Waehrung = dbAccountingEntryChartItem.Waehrung,
                Info = dbAccountingEntryChartItem.Info,
            };
        }
    }
}