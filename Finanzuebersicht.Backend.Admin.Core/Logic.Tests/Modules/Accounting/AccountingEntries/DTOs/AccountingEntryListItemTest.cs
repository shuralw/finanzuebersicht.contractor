using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntryListItemTest : IAccountingEntryListItem
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

        public static void AssertDefault(IAccountingEntryListItem accountingEntryListItem)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault, accountingEntryListItem.Id);
            CategoryTest.AssertDefault(accountingEntryListItem.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault, accountingEntryListItem.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault, accountingEntryListItem.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault, accountingEntryListItem.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault, accountingEntryListItem.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault, accountingEntryListItem.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault, accountingEntryListItem.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault, accountingEntryListItem.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault, accountingEntryListItem.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault, accountingEntryListItem.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault, accountingEntryListItem.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault, accountingEntryListItem.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault, accountingEntryListItem.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault, accountingEntryListItem.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault, accountingEntryListItem.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault, accountingEntryListItem.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault, accountingEntryListItem.Info);
        }

        public static void AssertDefault2(IAccountingEntryListItem accountingEntryListItem)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault2, accountingEntryListItem.Id);
            CategoryTest.AssertDefault2(accountingEntryListItem.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault2, accountingEntryListItem.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault2, accountingEntryListItem.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault2, accountingEntryListItem.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault2, accountingEntryListItem.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault2, accountingEntryListItem.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault2, accountingEntryListItem.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault2, accountingEntryListItem.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault2, accountingEntryListItem.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault2, accountingEntryListItem.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault2, accountingEntryListItem.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault2, accountingEntryListItem.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault2, accountingEntryListItem.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault2, accountingEntryListItem.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault2, accountingEntryListItem.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault2, accountingEntryListItem.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault2, accountingEntryListItem.Info);
        }
    }
}