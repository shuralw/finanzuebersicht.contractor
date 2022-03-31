using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntryDetailTest : IAccountingEntryDetail
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

        public static IAccountingEntryDetail Default()
        {
            return new AccountingEntryDetailTest()
            {
                Id = AccountingEntryTestValues.IdDefault,
                Auftragskonto = AccountingEntryTestValues.AuftragskontoDefault,
                Buchungsdatum = AccountingEntryTestValues.BuchungsdatumDefault,
                ValutaDatum = AccountingEntryTestValues.ValutaDatumDefault,
                Buchungstext = AccountingEntryTestValues.BuchungstextDefault,
                Verwendungszweck = AccountingEntryTestValues.VerwendungszweckDefault,
                GlaeubigerId = AccountingEntryTestValues.GlaeubigerIdDefault,
                Mandatsreferenz = AccountingEntryTestValues.MandatsreferenzDefault,
                Sammlerreferenz = AccountingEntryTestValues.SammlerreferenzDefault,
                LastschriftUrsprungsbetrag = AccountingEntryTestValues.LastschriftUrsprungsbetragDefault,
                AuslagenersatzRuecklastschrift = AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault,
                Beguenstigter = AccountingEntryTestValues.BeguenstigterDefault,
                IBAN = AccountingEntryTestValues.IBANDefault,
                BIC = AccountingEntryTestValues.BICDefault,
                Betrag = AccountingEntryTestValues.BetragDefault,
                Waehrung = AccountingEntryTestValues.WaehrungDefault,
                Info = AccountingEntryTestValues.InfoDefault,
            };
        }

        public static IAccountingEntryDetail Default2()
        {
            return new AccountingEntryDetailTest()
            {
                Id = AccountingEntryTestValues.IdDefault2,
                Auftragskonto = AccountingEntryTestValues.AuftragskontoDefault2,
                Buchungsdatum = AccountingEntryTestValues.BuchungsdatumDefault2,
                ValutaDatum = AccountingEntryTestValues.ValutaDatumDefault2,
                Buchungstext = AccountingEntryTestValues.BuchungstextDefault2,
                Verwendungszweck = AccountingEntryTestValues.VerwendungszweckDefault2,
                GlaeubigerId = AccountingEntryTestValues.GlaeubigerIdDefault2,
                Mandatsreferenz = AccountingEntryTestValues.MandatsreferenzDefault2,
                Sammlerreferenz = AccountingEntryTestValues.SammlerreferenzDefault2,
                LastschriftUrsprungsbetrag = AccountingEntryTestValues.LastschriftUrsprungsbetragDefault2,
                AuslagenersatzRuecklastschrift = AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault2,
                Beguenstigter = AccountingEntryTestValues.BeguenstigterDefault2,
                IBAN = AccountingEntryTestValues.IBANDefault2,
                BIC = AccountingEntryTestValues.BICDefault2,
                Betrag = AccountingEntryTestValues.BetragDefault2,
                Waehrung = AccountingEntryTestValues.WaehrungDefault2,
                Info = AccountingEntryTestValues.InfoDefault2,
            };
        }

        public static void AssertDefault(IAccountingEntryDetail accountingEntryDetail)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault, accountingEntryDetail.Id);
            CategoryTest.AssertDefault(accountingEntryDetail.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault, accountingEntryDetail.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault, accountingEntryDetail.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault, accountingEntryDetail.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault, accountingEntryDetail.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault, accountingEntryDetail.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault, accountingEntryDetail.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault, accountingEntryDetail.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault, accountingEntryDetail.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault, accountingEntryDetail.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault, accountingEntryDetail.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault, accountingEntryDetail.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault, accountingEntryDetail.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault, accountingEntryDetail.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault, accountingEntryDetail.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault, accountingEntryDetail.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault, accountingEntryDetail.Info);
        }

        public static void AssertDefault2(IAccountingEntryDetail accountingEntryDetail)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault2, accountingEntryDetail.Id);
            CategoryTest.AssertDefault2(accountingEntryDetail.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault2, accountingEntryDetail.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault2, accountingEntryDetail.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault2, accountingEntryDetail.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault2, accountingEntryDetail.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault2, accountingEntryDetail.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault2, accountingEntryDetail.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault2, accountingEntryDetail.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault2, accountingEntryDetail.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault2, accountingEntryDetail.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault2, accountingEntryDetail.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault2, accountingEntryDetail.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault2, accountingEntryDetail.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault2, accountingEntryDetail.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault2, accountingEntryDetail.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault2, accountingEntryDetail.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault2, accountingEntryDetail.Info);
        }
    }
}