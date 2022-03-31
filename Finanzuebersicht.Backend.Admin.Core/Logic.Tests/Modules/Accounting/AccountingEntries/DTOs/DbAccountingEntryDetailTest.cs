using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
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

        public decimal? LastschriftUrsprungsbetrag { get; set; }

        public string AuslagenersatzRuecklastschrift { get; set; }

        public string Beguenstigter { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        public decimal? Betrag { get; set; }

        public string Waehrung { get; set; }

        public string Info { get; set; }

        public static IDbAccountingEntryDetail Default()
        {
            return new DbAccountingEntryDetailTest()
            {
                Id = AccountingEntryTestValues.IdDefault,
                Category = DbCategoryTest.Default(),
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

        public static IDbAccountingEntryDetail Default2()
        {
            return new DbAccountingEntryDetailTest()
            {
                Id = AccountingEntryTestValues.IdDefault,
                Category = DbCategoryTest.Default2(),
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

        public static void AssertDefault(IDbAccountingEntryDetail dbAccountingEntryDetail)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault, dbAccountingEntryDetail.Id);
            DbCategoryTest.AssertDefault(dbAccountingEntryDetail.Category);
        }

        public static void AssertDefault2(IDbAccountingEntryDetail dbAccountingEntryDetail)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault2, dbAccountingEntryDetail.Id);
            DbCategoryTest.AssertDefault2(dbAccountingEntryDetail.Category);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault2, dbAccountingEntryDetail.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault2, dbAccountingEntryDetail.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault2, dbAccountingEntryDetail.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault2, dbAccountingEntryDetail.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault2, dbAccountingEntryDetail.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault2, dbAccountingEntryDetail.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault2, dbAccountingEntryDetail.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault2, dbAccountingEntryDetail.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault2, dbAccountingEntryDetail.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault2, dbAccountingEntryDetail.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault2, dbAccountingEntryDetail.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault2, dbAccountingEntryDetail.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault2, dbAccountingEntryDetail.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault2, dbAccountingEntryDetail.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault2, dbAccountingEntryDetail.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault2, dbAccountingEntryDetail.Info);
        }
    }
}