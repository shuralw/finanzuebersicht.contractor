using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntry : IDbAccountingEntry
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

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
    }
}