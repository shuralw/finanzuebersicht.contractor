using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntryListItem : IAccountingEntryListItem
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

        public double LastschriftUrsprungsbetrag { get; set; }

        public string AuslagenersatzRuecklastschrift { get; set; }

        public string Beguenstigter { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        public double Betrag { get; set; }

        public string Waehrung { get; set; }

        public string Info { get; set; }

        internal static IAccountingEntryListItem FromDbAccountingEntryListItem(IDbAccountingEntryListItem dbAccountingEntryListItem)
        {
            if (dbAccountingEntryListItem == null)
            {
                return null;
            }

            return new AccountingEntryListItem()
            {
                Id = dbAccountingEntryListItem.Id,
                Category = Accounting.Categories.Category.FromDbCategory(dbAccountingEntryListItem.Category),
                Auftragskonto = dbAccountingEntryListItem.Auftragskonto,
                Buchungsdatum = dbAccountingEntryListItem.Buchungsdatum,
                ValutaDatum = dbAccountingEntryListItem.ValutaDatum,
                Buchungstext = dbAccountingEntryListItem.Buchungstext,
                Verwendungszweck = dbAccountingEntryListItem.Verwendungszweck,
                GlaeubigerId = dbAccountingEntryListItem.GlaeubigerId,
                Mandatsreferenz = dbAccountingEntryListItem.Mandatsreferenz,
                Sammlerreferenz = dbAccountingEntryListItem.Sammlerreferenz,
                LastschriftUrsprungsbetrag = dbAccountingEntryListItem.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = dbAccountingEntryListItem.AuslagenersatzRuecklastschrift,
                Beguenstigter = dbAccountingEntryListItem.Beguenstigter,
                IBAN = dbAccountingEntryListItem.IBAN,
                BIC = dbAccountingEntryListItem.BIC,
                Betrag = dbAccountingEntryListItem.Betrag,
                Waehrung = dbAccountingEntryListItem.Waehrung,
                Info = dbAccountingEntryListItem.Info,
            };
        }
    }
}