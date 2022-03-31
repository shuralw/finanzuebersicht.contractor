using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntryCreateTest : IAccountingEntryCreate
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

        public static IAccountingEntryCreate ForCreate()
        {
            return new AccountingEntryCreateTest()
            {
                Id = AccountingEntryTestValues.IdForCreate,
                CategoryId = AccountingEntryTestValues.CategoryIdForCreate,
                Auftragskonto = AccountingEntryTestValues.AuftragskontoForCreate,
                Buchungsdatum = AccountingEntryTestValues.BuchungsdatumForCreate,
                ValutaDatum = AccountingEntryTestValues.ValutaDatumForCreate,
                Buchungstext = AccountingEntryTestValues.BuchungstextForCreate,
                Verwendungszweck = AccountingEntryTestValues.VerwendungszweckForCreate,
                GlaeubigerId = AccountingEntryTestValues.GlaeubigerIdForCreate,
                Mandatsreferenz = AccountingEntryTestValues.MandatsreferenzForCreate,
                Sammlerreferenz = AccountingEntryTestValues.SammlerreferenzForCreate,
                LastschriftUrsprungsbetrag = AccountingEntryTestValues.LastschriftUrsprungsbetragForCreate,
                AuslagenersatzRuecklastschrift = AccountingEntryTestValues.AuslagenersatzRuecklastschriftForCreate,
                Beguenstigter = AccountingEntryTestValues.BeguenstigterForCreate,
                IBAN = AccountingEntryTestValues.IBANForCreate,
                BIC = AccountingEntryTestValues.BICForCreate,
                Betrag = AccountingEntryTestValues.BetragForCreate,
                Waehrung = AccountingEntryTestValues.WaehrungForCreate,
                Info = AccountingEntryTestValues.InfoForCreate,
            };
        }
    }
}