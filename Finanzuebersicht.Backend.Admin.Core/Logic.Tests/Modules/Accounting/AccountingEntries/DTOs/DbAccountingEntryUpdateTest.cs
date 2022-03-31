using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries
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
                Id = AccountingEntryTestValues.IdDefault,
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

        public static void AssertUpdated(IDbAccountingEntryUpdate dbAccountingEntryUpdate)
        {
            Assert.AreEqual(AccountingEntryTestValues.IdDefault, dbAccountingEntryUpdate.Id);
            Assert.AreEqual(AccountingEntryTestValues.CategoryIdForUpdate, dbAccountingEntryUpdate.CategoryId);
            Assert.AreEqual(AccountingEntryTestValues.AuftragskontoForUpdate, dbAccountingEntryUpdate.Auftragskonto);
            Assert.AreEqual(AccountingEntryTestValues.BuchungsdatumForUpdate, dbAccountingEntryUpdate.Buchungsdatum);
            Assert.AreEqual(AccountingEntryTestValues.ValutaDatumForUpdate, dbAccountingEntryUpdate.ValutaDatum);
            Assert.AreEqual(AccountingEntryTestValues.BuchungstextForUpdate, dbAccountingEntryUpdate.Buchungstext);
            Assert.AreEqual(AccountingEntryTestValues.VerwendungszweckForUpdate, dbAccountingEntryUpdate.Verwendungszweck);
            Assert.AreEqual(AccountingEntryTestValues.GlaeubigerIdForUpdate, dbAccountingEntryUpdate.GlaeubigerId);
            Assert.AreEqual(AccountingEntryTestValues.MandatsreferenzForUpdate, dbAccountingEntryUpdate.Mandatsreferenz);
            Assert.AreEqual(AccountingEntryTestValues.SammlerreferenzForUpdate, dbAccountingEntryUpdate.Sammlerreferenz);
            Assert.AreEqual(AccountingEntryTestValues.LastschriftUrsprungsbetragForUpdate, dbAccountingEntryUpdate.LastschriftUrsprungsbetrag);
            Assert.AreEqual(AccountingEntryTestValues.AuslagenersatzRuecklastschriftForUpdate, dbAccountingEntryUpdate.AuslagenersatzRuecklastschrift);
            Assert.AreEqual(AccountingEntryTestValues.BeguenstigterForUpdate, dbAccountingEntryUpdate.Beguenstigter);
            Assert.AreEqual(AccountingEntryTestValues.IBANForUpdate, dbAccountingEntryUpdate.IBAN);
            Assert.AreEqual(AccountingEntryTestValues.BICForUpdate, dbAccountingEntryUpdate.BIC);
            Assert.AreEqual(AccountingEntryTestValues.BetragForUpdate, dbAccountingEntryUpdate.Betrag);
            Assert.AreEqual(AccountingEntryTestValues.WaehrungForUpdate, dbAccountingEntryUpdate.Waehrung);
            Assert.AreEqual(AccountingEntryTestValues.InfoForUpdate, dbAccountingEntryUpdate.Info);
        }
    }
}