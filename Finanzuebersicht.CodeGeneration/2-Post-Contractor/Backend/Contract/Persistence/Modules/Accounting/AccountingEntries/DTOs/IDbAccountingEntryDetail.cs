using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries
{
    public interface IDbAccountingEntryDetail
    {
        Guid Id { get; set; }

        IDbCategory Category { get; set; }

        string Auftragskonto { get; set; }

        DateTime Buchungsdatum { get; set; }

        DateTime ValutaDatum { get; set; }

        string Buchungstext { get; set; }

        string Verwendungszweck { get; set; }

        string GlaeubigerId { get; set; }

        string Mandatsreferenz { get; set; }

        string Sammlerreferenz { get; set; }

        double LastschriftUrsprungsbetrag { get; set; }

        string AuslagenersatzRuecklastschrift { get; set; }

        string Beguenstigter { get; set; }

        string IBAN { get; set; }

        string BIC { get; set; }

        double Betrag { get; set; }

        string Waehrung { get; set; }

        string Info { get; set; }
    }
}