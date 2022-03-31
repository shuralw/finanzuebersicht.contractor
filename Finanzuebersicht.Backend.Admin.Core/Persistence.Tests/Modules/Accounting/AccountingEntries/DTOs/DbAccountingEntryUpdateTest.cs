using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntryUpdateTest : IDbAccountingEntryUpdate
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

        public static IDbAccountingEntryUpdate ForUpdate()
        {
            return new DbAccountingEntryUpdateTest()
            {
                Id = AccountingEntryTestValues.IdDbDefault,
                CategoryId = AccountingEntryTestValues.CategoryIdForUpdate,
                Auftragskonto = AccountingEntryTestValues.AuftragskontoForUpdate,
                Buchungsdatum = AccountingEntryTestValues.BuchungsdatumForUpdate,
                ValutaDatum = AccountingEntryTestValues.ValutaDatumForUpdate,
                Buchungstext = AccountingEntryTestValues.BuchungstextForUpdate,
                Verwendungszweck = AccountingEntryTestValues.VerwendungszweckForUpdate,
                GlaeubigerId = AccountingEntryTestValues.GlaeubigerIdForUpdate,
                Mandatsreferenz = AccountingEntryTestValues.MandatsreferenzForUpdate,
                Sammlerreferenz = AccountingEntryTestValues.SammlerreferenzForUpdate,
                LastschriftUrsprungsbetrag = AccountingEntryTestValues.LastschriftUrsprungsbetragForUpdate,
                AuslagenersatzRuecklastschrift = AccountingEntryTestValues.AuslagenersatzRuecklastschriftForUpdate,
                Beguenstigter = AccountingEntryTestValues.BeguenstigterForUpdate,
                IBAN = AccountingEntryTestValues.IBANForUpdate,
                BIC = AccountingEntryTestValues.BICForUpdate,
                Betrag = AccountingEntryTestValues.BetragForUpdate,
                Waehrung = AccountingEntryTestValues.WaehrungForUpdate,
                Info = AccountingEntryTestValues.InfoForUpdate,
            };
        }
    }
}