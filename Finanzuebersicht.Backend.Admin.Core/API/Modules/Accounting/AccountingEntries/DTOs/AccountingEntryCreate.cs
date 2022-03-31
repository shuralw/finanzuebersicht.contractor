using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.Accounting.AccountingEntries
{
    public class AccountingEntryCreate : IAccountingEntryCreate
    {
        public Guid? CategoryId { get; set; }

        [StringLength(30)]
        public string Auftragskonto { get; set; }

        [Required]
        public DateTime Buchungsdatum { get; set; }

        public DateTime ValutaDatum { get; set; }

        [StringLength(300)]
        public string Buchungstext { get; set; }

        [StringLength(4000)]
        public string Verwendungszweck { get; set; }

        [StringLength(100)]
        public string GlaeubigerId { get; set; }

        [StringLength(100)]
        public string Mandatsreferenz { get; set; }

        [StringLength(100)]
        public string Sammlerreferenz { get; set; }

        public decimal? LastschriftUrsprungsbetrag { get; set; }

        [StringLength(100)]
        public string AuslagenersatzRuecklastschrift { get; set; }

        [StringLength(200)]
        public string Beguenstigter { get; set; }

        [StringLength(40)]
        public string IBAN { get; set; }

        [StringLength(20)]
        public string BIC { get; set; }

        [Required]
        public decimal? Betrag { get; set; }

        [StringLength(10)]
        public string Waehrung { get; set; }

        [StringLength(100)]
        public string Info { get; set; }
    }
}