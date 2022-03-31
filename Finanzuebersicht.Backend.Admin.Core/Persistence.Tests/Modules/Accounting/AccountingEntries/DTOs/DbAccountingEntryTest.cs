using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntryTest : IDbAccountingEntry
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

        public static IDbAccountingEntry DbDefault()
        {
            return new DbAccountingEntryTest()
            {
                Id = AccountingEntryTestValues.IdDbDefault,
                CategoryId = AccountingEntryTestValues.CategoryIdDbDefault,
                Auftragskonto = AccountingEntryTestValues.AuftragskontoDbDefault,
                Buchungsdatum = AccountingEntryTestValues.BuchungsdatumDbDefault,
                ValutaDatum = AccountingEntryTestValues.ValutaDatumDbDefault,
                Buchungstext = AccountingEntryTestValues.BuchungstextDbDefault,
                Verwendungszweck = AccountingEntryTestValues.VerwendungszweckDbDefault,
                GlaeubigerId = AccountingEntryTestValues.GlaeubigerIdDbDefault,
                Mandatsreferenz = AccountingEntryTestValues.MandatsreferenzDbDefault,
                Sammlerreferenz = AccountingEntryTestValues.SammlerreferenzDbDefault,
                LastschriftUrsprungsbetrag = AccountingEntryTestValues.LastschriftUrsprungsbetragDbDefault,
                AuslagenersatzRuecklastschrift = AccountingEntryTestValues.AuslagenersatzRuecklastschriftDbDefault,
                Beguenstigter = AccountingEntryTestValues.BeguenstigterDbDefault,
                IBAN = AccountingEntryTestValues.IBANDbDefault,
                BIC = AccountingEntryTestValues.BICDbDefault,
                Betrag = AccountingEntryTestValues.BetragDbDefault,
                Waehrung = AccountingEntryTestValues.WaehrungDbDefault,
                Info = AccountingEntryTestValues.InfoDbDefault,
            };
        }

        public static IDbAccountingEntry DbDefault2()
        {
            return new DbAccountingEntryTest()
            {
                Id = AccountingEntryTestValues.IdDbDefault2,
                CategoryId = AccountingEntryTestValues.CategoryIdDbDefault2,
                Auftragskonto = AccountingEntryTestValues.AuftragskontoDbDefault2,
                Buchungsdatum = AccountingEntryTestValues.BuchungsdatumDbDefault2,
                ValutaDatum = AccountingEntryTestValues.ValutaDatumDbDefault2,
                Buchungstext = AccountingEntryTestValues.BuchungstextDbDefault2,
                Verwendungszweck = AccountingEntryTestValues.VerwendungszweckDbDefault2,
                GlaeubigerId = AccountingEntryTestValues.GlaeubigerIdDbDefault2,
                Mandatsreferenz = AccountingEntryTestValues.MandatsreferenzDbDefault2,
                Sammlerreferenz = AccountingEntryTestValues.SammlerreferenzDbDefault2,
                LastschriftUrsprungsbetrag = AccountingEntryTestValues.LastschriftUrsprungsbetragDbDefault2,
                AuslagenersatzRuecklastschrift = AccountingEntryTestValues.AuslagenersatzRuecklastschriftDbDefault2,
                Beguenstigter = AccountingEntryTestValues.BeguenstigterDbDefault2,
                IBAN = AccountingEntryTestValues.IBANDbDefault2,
                BIC = AccountingEntryTestValues.BICDbDefault2,
                Betrag = AccountingEntryTestValues.BetragDbDefault2,
                Waehrung = AccountingEntryTestValues.WaehrungDbDefault2,
                Info = AccountingEntryTestValues.InfoDbDefault2,
            };
        }

        public static IDbAccountingEntry ForCreate()
        {
            return new DbAccountingEntryTest()
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

        public static void AssertDbDefault(IDbAccountingEntry dbAccountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDbDefault, dbAccountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdDbDefault, dbAccountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDbDefault, dbAccountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDbDefault, dbAccountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDbDefault, dbAccountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDbDefault, dbAccountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDbDefault, dbAccountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDbDefault, dbAccountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDbDefault, dbAccountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDbDefault, dbAccountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDbDefault, dbAccountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDbDefault, dbAccountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDbDefault, dbAccountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDbDefault, dbAccountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDbDefault, dbAccountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDbDefault, dbAccountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDbDefault, dbAccountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDbDefault, dbAccountingEntry.Info);
        }

        public static void AssertDbDefault2(IDbAccountingEntry dbAccountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDbDefault2, dbAccountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdDbDefault2, dbAccountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDbDefault2, dbAccountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDbDefault2, dbAccountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDbDefault2, dbAccountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDbDefault2, dbAccountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDbDefault2, dbAccountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDbDefault2, dbAccountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDbDefault2, dbAccountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDbDefault2, dbAccountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDbDefault2, dbAccountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDbDefault2, dbAccountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDbDefault2, dbAccountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDbDefault2, dbAccountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDbDefault2, dbAccountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDbDefault2, dbAccountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDbDefault2, dbAccountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDbDefault2, dbAccountingEntry.Info);
        }

        public static void AssertForCreate(IDbAccountingEntry dbAccountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdForCreate, dbAccountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdForCreate, dbAccountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoForCreate, dbAccountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumForCreate, dbAccountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumForCreate, dbAccountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextForCreate, dbAccountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckForCreate, dbAccountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdForCreate, dbAccountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzForCreate, dbAccountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzForCreate, dbAccountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragForCreate, dbAccountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftForCreate, dbAccountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterForCreate, dbAccountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANForCreate, dbAccountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICForCreate, dbAccountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragForCreate, dbAccountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungForCreate, dbAccountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoForCreate, dbAccountingEntry.Info);
        }

        public static void AssertForUpdate(IDbAccountingEntry dbAccountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDbDefault, dbAccountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdForUpdate, dbAccountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoForUpdate, dbAccountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumForUpdate, dbAccountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumForUpdate, dbAccountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextForUpdate, dbAccountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckForUpdate, dbAccountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdForUpdate, dbAccountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzForUpdate, dbAccountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzForUpdate, dbAccountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragForUpdate, dbAccountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftForUpdate, dbAccountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterForUpdate, dbAccountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANForUpdate, dbAccountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICForUpdate, dbAccountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragForUpdate, dbAccountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungForUpdate, dbAccountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoForUpdate, dbAccountingEntry.Info);
        }
    }
}