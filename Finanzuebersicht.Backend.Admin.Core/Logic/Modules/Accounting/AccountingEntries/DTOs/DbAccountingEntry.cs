using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;
using System.Globalization;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries
{
    internal class DbAccountingEntry : IDbAccountingEntry
    {
        public DbAccountingEntry()
        {
        }

        public DbAccountingEntry(string[] lineSplit)
        {
            this.Auftragskonto = lineSplit[0];

            if (DateTime.TryParseExact(lineSplit[1], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                this.Buchungsdatum = date;
            }
            else if (DateTime.TryParseExact(lineSplit[1], "dd.MM.yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                this.Buchungsdatum = date;
            }

            if (DateTime.TryParseExact(lineSplit[2], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                this.ValutaDatum = date;
            }
            else if (DateTime.TryParseExact(lineSplit[2], "dd.MM.yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                this.ValutaDatum = date;
            }

            this.Buchungstext = lineSplit[3];
            this.Verwendungszweck = lineSplit[4];
            this.GlaeubigerId = lineSplit[5];
            this.Mandatsreferenz = lineSplit[6];
            this.Sammlerreferenz = lineSplit[8];
            this.LastschriftUrsprungsbetrag = string.IsNullOrEmpty(lineSplit[9]) ? null : Convert.ToDecimal(lineSplit[9]);
            this.AuslagenersatzRuecklastschrift = lineSplit[10];
            this.Beguenstigter = lineSplit[11];
            this.IBAN = lineSplit[12];
            this.BIC = lineSplit[13];
            this.Betrag = string.IsNullOrEmpty(lineSplit[14]) ? null : Convert.ToDecimal(lineSplit[14]);
            this.Waehrung = lineSplit[15];
            this.Info = lineSplit[16];
        }

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
    }
}