using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.AccountingEntries;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.AccountingEntries
{
    public class AccountingEntryCreate : IAccountingEntryCreate
    {
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(30)]
        public string Auftragskonto { get; set; }

        [Required]
        public DateTime Buchungsdatum { get; set; }

        [Required]
        public DateTime ValutaDatum { get; set; }

        [Required]
        [StringLength(300)]
        public string Buchungstext { get; set; }

        [Required]
        [StringLength(300)]
        public string Verwendungszweck { get; set; }

        [Required]
        [StringLength(100)]
        public string GlaeubigerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Mandatsreferenz { get; set; }

        [Required]
        [StringLength(100)]
        public string Sammlerreferenz { get; set; }

        [Required]
        public double LastschriftUrsprungsbetrag { get; set; }

        [Required]
        [StringLength(100)]
        public string AuslagenersatzRuecklastschrift { get; set; }

        [Required]
        [StringLength(200)]
        public string Beguenstigter { get; set; }

        [Required]
        [StringLength(22)]
        public string IBAN { get; set; }

        [Required]
        [StringLength(15)]
        public string BIC { get; set; }

        [Required]
        public double Betrag { get; set; }

        [Required]
        [StringLength(10)]
        public string Waehrung { get; set; }

        [Required]
        [StringLength(100)]
        public string Info { get; set; }
    }
}