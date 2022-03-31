using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.AccountingEntries
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

        public static IDbAccountingEntryListItem Default()
        {
            return new DbAccountingEntryListItemTest()
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

        public static IDbAccountingEntryListItem Default2()
        {
            return new DbAccountingEntryListItemTest()
            {
                Id = AccountingEntryTestValues.IdDefault2,
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

        public static IDbPagedResult<IDbAccountingEntryListItem> ForPaged()
        {
            return new DbPagedResult<IDbAccountingEntryListItem>()
            {
                Data = new List<IDbAccountingEntryListItem>()
                {
                    Default(),
                    Default2()
                },
                TotalCount = 2,
                Count = 2,
                Limit = 10,
                Offset = 0
            };
        }
    }
}