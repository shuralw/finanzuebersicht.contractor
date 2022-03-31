using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
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

        public static IDbAccountingEntry Default()
        {
            return new DbAccountingEntryTest()
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

        public static IDbAccountingEntry Default2()
        {
            return new DbAccountingEntryTest()
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

        public static void AssertDefault(IDbAccountingEntry dbAccountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault, dbAccountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdDefault, dbAccountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault, dbAccountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault, dbAccountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault, dbAccountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault, dbAccountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault, dbAccountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault, dbAccountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault, dbAccountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault, dbAccountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault, dbAccountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault, dbAccountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault, dbAccountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault, dbAccountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault, dbAccountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault, dbAccountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault, dbAccountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault, dbAccountingEntry.Info);
        }

        public static void AssertDefault2(IDbAccountingEntry dbAccountingEntry)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault2, dbAccountingEntry.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdDefault2, dbAccountingEntry.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoDefault2, dbAccountingEntry.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumDefault2, dbAccountingEntry.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumDefault2, dbAccountingEntry.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextDefault2, dbAccountingEntry.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckDefault2, dbAccountingEntry.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdDefault2, dbAccountingEntry.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzDefault2, dbAccountingEntry.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzDefault2, dbAccountingEntry.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragDefault2, dbAccountingEntry.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftDefault2, dbAccountingEntry.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterDefault2, dbAccountingEntry.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANDefault2, dbAccountingEntry.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICDefault2, dbAccountingEntry.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragDefault2, dbAccountingEntry.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungDefault2, dbAccountingEntry.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoDefault2, dbAccountingEntry.Info);
        }

        public static void AssertCreated(IDbAccountingEntry dbAccountingEntry)
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
    }
}