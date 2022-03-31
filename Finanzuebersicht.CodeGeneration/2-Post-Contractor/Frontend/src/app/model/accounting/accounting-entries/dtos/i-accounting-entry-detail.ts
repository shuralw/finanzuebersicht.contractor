import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';

export interface IAccountingEntryDetail {
    id: string;
    category: ICategory;
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
    iBAN: string;
    bIC: string;
    betrag: number;
    waehrung: string;
    info: string;
}
