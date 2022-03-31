using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntry : IDbAccountingEntry
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

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

        internal static void UpdateEfAccountingEntry(EfAccountingEntry efAccountingEntry, IDbAccountingEntryUpdate dbAccountingEntryUpdate)
        {
            efAccountingEntry.CategoryId = dbAccountingEntryUpdate.CategoryId;
            efAccountingEntry.Auftragskonto = dbAccountingEntryUpdate.Auftragskonto;
            efAccountingEntry.Buchungsdatum = dbAccountingEntryUpdate.Buchungsdatum;
            efAccountingEntry.ValutaDatum = dbAccountingEntryUpdate.ValutaDatum;
            efAccountingEntry.Buchungstext = dbAccountingEntryUpdate.Buchungstext;
            efAccountingEntry.Verwendungszweck = dbAccountingEntryUpdate.Verwendungszweck;
            efAccountingEntry.GlaeubigerId = dbAccountingEntryUpdate.GlaeubigerId;
            efAccountingEntry.Mandatsreferenz = dbAccountingEntryUpdate.Mandatsreferenz;
            efAccountingEntry.Sammlerreferenz = dbAccountingEntryUpdate.Sammlerreferenz;
            efAccountingEntry.LastschriftUrsprungsbetrag = dbAccountingEntryUpdate.LastschriftUrsprungsbetrag;
            efAccountingEntry.AuslagenersatzRuecklastschrift = dbAccountingEntryUpdate.AuslagenersatzRuecklastschrift;
            efAccountingEntry.Beguenstigter = dbAccountingEntryUpdate.Beguenstigter;
            efAccountingEntry.IBAN = dbAccountingEntryUpdate.IBAN;
            efAccountingEntry.BIC = dbAccountingEntryUpdate.BIC;
            efAccountingEntry.Betrag = dbAccountingEntryUpdate.Betrag;
            efAccountingEntry.Waehrung = dbAccountingEntryUpdate.Waehrung;
            efAccountingEntry.Info = dbAccountingEntryUpdate.Info;
        }

        internal static IDbAccountingEntry FromEfAccountingEntry(EfAccountingEntry efAccountingEntry)
        {
            if (efAccountingEntry == null)
            {
                return null;
            }

            return new DbAccountingEntry()
            {
                Id = efAccountingEntry.Id,
                CategoryId = efAccountingEntry.CategoryId,
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

        internal static EfAccountingEntry ToEfAccountingEntry(IDbAccountingEntry dbAccountingEntry, Guid emailUserId)
        {
            return new EfAccountingEntry()
            {
                Id = dbAccountingEntry.Id,
                EmailUserId = emailUserId,
                CategoryId = dbAccountingEntry.CategoryId,
                Auftragskonto = dbAccountingEntry.Auftragskonto,
                Buchungsdatum = dbAccountingEntry.Buchungsdatum,
                ValutaDatum = dbAccountingEntry.ValutaDatum,
                Buchungstext = dbAccountingEntry.Buchungstext,
                Verwendungszweck = dbAccountingEntry.Verwendungszweck,
                GlaeubigerId = dbAccountingEntry.GlaeubigerId,
                Mandatsreferenz = dbAccountingEntry.Mandatsreferenz,
                Sammlerreferenz = dbAccountingEntry.Sammlerreferenz,
                LastschriftUrsprungsbetrag = dbAccountingEntry.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = dbAccountingEntry.AuslagenersatzRuecklastschrift,
                Beguenstigter = dbAccountingEntry.Beguenstigter,
                IBAN = dbAccountingEntry.IBAN,
                BIC = dbAccountingEntry.BIC,
                Betrag = dbAccountingEntry.Betrag,
                Waehrung = dbAccountingEntry.Waehrung,
                Info = dbAccountingEntry.Info,
            };
        }
    }
}