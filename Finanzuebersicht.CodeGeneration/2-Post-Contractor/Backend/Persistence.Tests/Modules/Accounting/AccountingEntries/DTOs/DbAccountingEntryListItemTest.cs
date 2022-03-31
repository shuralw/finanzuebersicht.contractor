using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntryListItemTest : IDbAccountingEntryListItem
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

        public static void AssertDbDefault(IDbAccountingEntryListItem dbAccountingEntryListItem)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDbDefault, dbAccountingEntryListItem.Id);
            DbCategoryTest.AssertDbDefault(dbAccountingEntryListItem.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDbDefault, dbAccountingEntryListItem.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDbDefault, dbAccountingEntryListItem.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDbDefault, dbAccountingEntryListItem.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDbDefault, dbAccountingEntryListItem.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDbDefault, dbAccountingEntryListItem.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDbDefault, dbAccountingEntryListItem.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDbDefault, dbAccountingEntryListItem.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDbDefault, dbAccountingEntryListItem.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDbDefault, dbAccountingEntryListItem.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDbDefault, dbAccountingEntryListItem.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDbDefault, dbAccountingEntryListItem.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDbDefault, dbAccountingEntryListItem.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDbDefault, dbAccountingEntryListItem.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDbDefault, dbAccountingEntryListItem.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDbDefault, dbAccountingEntryListItem.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDbDefault, dbAccountingEntryListItem.Info);
        }

        public static void AssertDbDefault2(IDbAccountingEntryListItem dbAccountingEntryListItem)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDbDefault2, dbAccountingEntryListItem.Id);
            DbCategoryTest.AssertDbDefault2(dbAccountingEntryListItem.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDbDefault2, dbAccountingEntryListItem.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDbDefault2, dbAccountingEntryListItem.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDbDefault2, dbAccountingEntryListItem.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDbDefault2, dbAccountingEntryListItem.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDbDefault2, dbAccountingEntryListItem.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDbDefault2, dbAccountingEntryListItem.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDbDefault2, dbAccountingEntryListItem.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDbDefault2, dbAccountingEntryListItem.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDbDefault2, dbAccountingEntryListItem.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDbDefault2, dbAccountingEntryListItem.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDbDefault2, dbAccountingEntryListItem.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDbDefault2, dbAccountingEntryListItem.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDbDefault2, dbAccountingEntryListItem.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDbDefault2, dbAccountingEntryListItem.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDbDefault2, dbAccountingEntryListItem.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDbDefault2, dbAccountingEntryListItem.Info);
        }
    }
}