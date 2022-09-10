using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntry : IAccountingEntry
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

        internal static void UpdateDbAccountingEntry(IDbAccountingEntry dbAccountingEntry, IAccountingEntryUpdate accountingEntryUpdate)
        {
            dbAccountingEntry.CategoryId = accountingEntryUpdate.CategoryId;
            dbAccountingEntry.Auftragskonto = accountingEntryUpdate.Auftragskonto;
            dbAccountingEntry.Buchungsdatum = accountingEntryUpdate.Buchungsdatum;
            dbAccountingEntry.ValutaDatum = accountingEntryUpdate.ValutaDatum;
            dbAccountingEntry.Buchungstext = accountingEntryUpdate.Buchungstext;
            dbAccountingEntry.Verwendungszweck = accountingEntryUpdate.Verwendungszweck;
            dbAccountingEntry.GlaeubigerId = accountingEntryUpdate.GlaeubigerId;
            dbAccountingEntry.Mandatsreferenz = accountingEntryUpdate.Mandatsreferenz;
            dbAccountingEntry.Sammlerreferenz = accountingEntryUpdate.Sammlerreferenz;
            dbAccountingEntry.LastschriftUrsprungsbetrag = accountingEntryUpdate.LastschriftUrsprungsbetrag;
            dbAccountingEntry.AuslagenersatzRuecklastschrift = accountingEntryUpdate.AuslagenersatzRuecklastschrift;
            dbAccountingEntry.Beguenstigter = accountingEntryUpdate.Beguenstigter;
            dbAccountingEntry.IBAN = accountingEntryUpdate.IBAN;
            dbAccountingEntry.BIC = accountingEntryUpdate.BIC;
            dbAccountingEntry.Betrag = accountingEntryUpdate.Betrag;
            dbAccountingEntry.Waehrung = accountingEntryUpdate.Waehrung;
            dbAccountingEntry.Info = accountingEntryUpdate.Info;
        }

        internal static IAccountingEntry FromDbAccountingEntry(IDbAccountingEntry dbAccountingEntry)
        {
            if (dbAccountingEntry == null)
            {
                return null;
            }

            return new AccountingEntry()
            {
                Id = dbAccountingEntry.Id,
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

        internal static IDbAccountingEntry CreateDbAccountingEntry(Guid accountingEntryId, IAccountingEntryCreate accountingEntryCreate)
        {
            return new DbAccountingEntry()
            {
                Id = accountingEntryId,
                CategoryId = accountingEntryCreate.CategoryId,
                Auftragskonto = accountingEntryCreate.Auftragskonto,
                Buchungsdatum = accountingEntryCreate.Buchungsdatum,
                ValutaDatum = accountingEntryCreate.ValutaDatum,
                Buchungstext = accountingEntryCreate.Buchungstext,
                Verwendungszweck = accountingEntryCreate.Verwendungszweck,
                GlaeubigerId = accountingEntryCreate.GlaeubigerId,
                Mandatsreferenz = accountingEntryCreate.Mandatsreferenz,
                Sammlerreferenz = accountingEntryCreate.Sammlerreferenz,
                LastschriftUrsprungsbetrag = accountingEntryCreate.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = accountingEntryCreate.AuslagenersatzRuecklastschrift,
                Beguenstigter = accountingEntryCreate.Beguenstigter,
                IBAN = accountingEntryCreate.IBAN,
                BIC = accountingEntryCreate.BIC,
                Betrag = accountingEntryCreate.Betrag,
                Waehrung = accountingEntryCreate.Waehrung,
                Info = accountingEntryCreate.Info,
            };
        }

        internal static IDbAccountingEntry CreateDbAccountingEntry(Guid accountingEntryId, IAccountingEntryMultipleCreate accountingEntryCreate)
        {
            try
            {

            return new DbAccountingEntry()
            {
                Id = accountingEntryId,
                CategoryId = accountingEntryCreate.CategoryId,
                Auftragskonto = accountingEntryCreate.Auftragskonto,
                Buchungsdatum = accountingEntryCreate.Buchungsdatum.Value,
                ValutaDatum = accountingEntryCreate.ValutaDatum.Value,
                Buchungstext = accountingEntryCreate.Buchungstext,
                Verwendungszweck = accountingEntryCreate.Verwendungszweck,
                GlaeubigerId = accountingEntryCreate.GlaeubigerId,
                Mandatsreferenz = accountingEntryCreate.Mandatsreferenz,
                Sammlerreferenz = accountingEntryCreate.Sammlerreferenz,
                LastschriftUrsprungsbetrag = accountingEntryCreate.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = accountingEntryCreate.AuslagenersatzRuecklastschrift,
                Beguenstigter = accountingEntryCreate.Beguenstigter,
                IBAN = accountingEntryCreate.IBAN,
                BIC = accountingEntryCreate.BIC,
                Betrag = accountingEntryCreate.Betrag,
                Waehrung = accountingEntryCreate.Waehrung,
                Info = accountingEntryCreate.Info,
            };
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}