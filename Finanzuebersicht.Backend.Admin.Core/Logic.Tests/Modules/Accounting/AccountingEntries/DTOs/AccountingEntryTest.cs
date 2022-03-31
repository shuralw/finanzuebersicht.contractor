using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntryTest : IAccountingEntry
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

        public static IAccountingEntry Default()
        {
            return new AccountingEntryTest()
            {
                Id = AccountingEntryTestValues.IdDefault,
                CategoryId = AccountingEntryTestValues.CategoryIdDefault,
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

        public static IAccountingEntry Default2()
        {
            return new AccountingEntryTest()
            {
                Id = AccountingEntryTestValues.IdDefault2,
                CategoryId = AccountingEntryTestValues.CategoryIdDefault2,
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

        public static void AssertDefault(IAccountingEntry accountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault, accountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdDefault, accountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault, accountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault, accountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault, accountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault, accountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault, accountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault, accountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault, accountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault, accountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault, accountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault, accountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault, accountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault, accountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault, accountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault, accountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault, accountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault, accountingEntry.Info);
        }

        public static void AssertDefault2(IAccountingEntry accountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault2, accountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdDefault2, accountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault2, accountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault2, accountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault2, accountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault2, accountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault2, accountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault2, accountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault2, accountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault2, accountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault2, accountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault2, accountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault2, accountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault2, accountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault2, accountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault2, accountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault2, accountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault2, accountingEntry.Info);
        }
    }
}