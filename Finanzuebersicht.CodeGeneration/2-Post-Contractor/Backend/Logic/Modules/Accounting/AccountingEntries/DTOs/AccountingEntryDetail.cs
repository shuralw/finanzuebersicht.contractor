using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.AccountingEntries
{
    internal class AccountingEntryDetail : IAccountingEntryDetail
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

        public double LastschriftUrsprungsbetrag { get; set; }

        public string AuslagenersatzRuecklastschrift { get; set; }

        public string Beguenstigter { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        public double Betrag { get; set; }

        public string Waehrung { get; set; }

        public string Info { get; set; }

        internal static IAccountingEntryDetail FromDbAccountingEntryDetail(IDbAccountingEntryDetail dbAccountingEntryDetail)
        {
            if (dbAccountingEntryDetail == null)
            {
                return null;
            }

            return new AccountingEntryDetail()
            {
                Id = dbAccountingEntryDetail.Id,
                Category = Accounting.Categories.Category.FromDbCategory(dbAccountingEntryDetail.Category),
                Auftragskonto = dbAccountingEntryDetail.Auftragskonto,
                Buchungsdatum = dbAccountingEntryDetail.Buchungsdatum,
                ValutaDatum = dbAccountingEntryDetail.ValutaDatum,
                Buchungstext = dbAccountingEntryDetail.Buchungstext,
                Verwendungszweck = dbAccountingEntryDetail.Verwendungszweck,
                GlaeubigerId = dbAccountingEntryDetail.GlaeubigerId,
                Mandatsreferenz = dbAccountingEntryDetail.Mandatsreferenz,
                Sammlerreferenz = dbAccountingEntryDetail.Sammlerreferenz,
                LastschriftUrsprungsbetrag = dbAccountingEntryDetail.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = dbAccountingEntryDetail.AuslagenersatzRuecklastschrift,
                Beguenstigter = dbAccountingEntryDetail.Beguenstigter,
                IBAN = dbAccountingEntryDetail.IBAN,
                BIC = dbAccountingEntryDetail.BIC,
                Betrag = dbAccountingEntryDetail.Betrag,
                Waehrung = dbAccountingEntryDetail.Waehrung,
                Info = dbAccountingEntryDetail.Info,
            };
        }
    }
}