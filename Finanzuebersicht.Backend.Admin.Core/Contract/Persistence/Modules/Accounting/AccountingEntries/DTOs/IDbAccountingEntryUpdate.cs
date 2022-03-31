using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries
{
    public interface IDbAccountingEntryUpdate
    {
        Guid Id { get; set; }

        Guid? CategoryId { get; set; }

        string Auftragskonto { get; set; }

        DateTime Buchungsdatum { get; set; }

        DateTime ValutaDatum { get; set; }

        string Buchungstext { get; set; }

        string Verwendungszweck { get; set; }

        string GlaeubigerId { get; set; }

        string Mandatsreferenz { get; set; }

        string Sammlerreferenz { get; set; }

        decimal? LastschriftUrsprungsbetrag { get; set; }

        string AuslagenersatzRuecklastschrift { get; set; }

        string Beguenstigter { get; set; }

        string IBAN { get; set; }

        string BIC { get; set; }

        decimal? Betrag { get; set; }

        string Waehrung { get; set; }

        string Info { get; set; }
    }
}