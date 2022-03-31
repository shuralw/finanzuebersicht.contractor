using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntryUpdate : IDbAccountingEntryUpdate
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

        internal static IDbAccountingEntryUpdate FromAccountingEntryUpdate(IAccountingEntryUpdate accountingEntryUpdate)
        {
            return new DbAccountingEntryUpdate()
            {
                Id = accountingEntryUpdate.Id,
                CategoryId = accountingEntryUpdate.CategoryId,
                Auftragskonto = accountingEntryUpdate.Auftragskonto,
                Buchungsdatum = accountingEntryUpdate.Buchungsdatum,
                ValutaDatum = accountingEntryUpdate.ValutaDatum,
                Buchungstext = accountingEntryUpdate.Buchungstext,
                Verwendungszweck = accountingEntryUpdate.Verwendungszweck,
                GlaeubigerId = accountingEntryUpdate.GlaeubigerId,
                Mandatsreferenz = accountingEntryUpdate.Mandatsreferenz,
                Sammlerreferenz = accountingEntryUpdate.Sammlerreferenz,
                LastschriftUrsprungsbetrag = accountingEntryUpdate.LastschriftUrsprungsbetrag,
                AuslagenersatzRuecklastschrift = accountingEntryUpdate.AuslagenersatzRuecklastschrift,
                Beguenstigter = accountingEntryUpdate.Beguenstigter,
                IBAN = accountingEntryUpdate.IBAN,
                BIC = accountingEntryUpdate.BIC,
                Betrag = accountingEntryUpdate.Betrag,
                Waehrung = accountingEntryUpdate.Waehrung,
                Info = accountingEntryUpdate.Info,
            };
        }
    }
}