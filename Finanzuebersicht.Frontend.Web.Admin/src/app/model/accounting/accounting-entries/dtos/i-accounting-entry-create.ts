export interface IAccountingEntryCreate {
    categoryId: string;
    auftragskonto: string;
    buchungsdatum: Date;
    valutaDatum: Date;
    buchungstext: string;
    verwendungszweck: string;
    glaeubigerId: string;
    mandatsreferenz: string;
    sammlerreferenz: string;
    lastschriftUrsprungsbetrag: number;
    auslagenersatzRuecklastschrift: string;
    beguenstigter: string;
    iban: string;
    bic: string;
    betrag: number;
    waehrung: string;
    info: string;
}
