using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntryDetailTest : IDbAccountingEntryDetail
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

        public static void AssertDbDefault(IDbAccountingEntryDetail dbAccountingEntryDetail)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDbDefault, dbAccountingEntryDetail.Id);
            DbCategoryTest.AssertDbDefault(dbAccountingEntryDetail.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDbDefault, dbAccountingEntryDetail.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDbDefault, dbAccountingEntryDetail.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDbDefault, dbAccountingEntryDetail.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDbDefault, dbAccountingEntryDetail.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDbDefault, dbAccountingEntryDetail.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDbDefault, dbAccountingEntryDetail.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDbDefault, dbAccountingEntryDetail.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDbDefault, dbAccountingEntryDetail.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDbDefault, dbAccountingEntryDetail.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDbDefault, dbAccountingEntryDetail.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDbDefault, dbAccountingEntryDetail.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDbDefault, dbAccountingEntryDetail.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDbDefault, dbAccountingEntryDetail.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDbDefault, dbAccountingEntryDetail.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDbDefault, dbAccountingEntryDetail.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDbDefault, dbAccountingEntryDetail.Info);
        }
    }
}