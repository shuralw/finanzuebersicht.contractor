using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntryDetail : IDbAccountingEntryDetail
    {
        public Guid Id { get; set; }

        public IDbCategory Category { get; set; }

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

        internal static IDbAccountingEntryDetail FromEfAccountingEntry(EfAccountingEntry efAccountingEntry)
        {
            if (efAccountingEntry == null)
            {
                return null;
            }

            return new DbAccountingEntryDetail()
            {
                Id = efAccountingEntry.Id,
                Category = DbCategory.FromEfCategory(efAccountingEntry.Category),
                Auftragskonto = efAccountingEntry.Auftragskonto,
                Buchungsdatum = efAccountingEntry.Buchungsdatum,
                ValutaDatum = efAccountingEntry.ValutaDatum,
                Buchungstext = efAccountingEntry.Buchungstext,
                Verwendungszweck = efAccountingEntry.Verwendungszweck,
                GlaeubigerId = efAccountingEntry.GlaeubigerId,
                Mandatsreferenz = efAccountingEntry.Mandatsreferenz,
                Sammlerreferenz = efAccountingEntry.Sammlerreferenz,
                LastschriftUrsprungsbetrag = efAccountingEntry.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = efAccountingEntry.AuslagenersatzRuecklastschrift,
                Beguenstigter = efAccountingEntry.Beguenstigter,
                IBAN = efAccountingEntry.IBAN,
                BIC = efAccountingEntry.BIC,
                Betrag = efAccountingEntry.Betrag,
                Waehrung = efAccountingEntry.Waehrung,
                Info = efAccountingEntry.Info,
            };
        }
    }
}