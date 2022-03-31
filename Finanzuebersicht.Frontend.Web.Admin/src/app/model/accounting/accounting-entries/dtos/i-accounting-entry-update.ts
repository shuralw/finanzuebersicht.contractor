import { IAccountingEntryDetail } from './i-accounting-entry-detail';

export interface IAccountingEntryUpdate {
    id: string;
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

export abstract class AccountingEntryUpdate {
    public static fromAccountingEntryDetail(iAccountingEntryDetail: IAccountingEntryDetail): IAccountingEntryUpdate {
        return {
            id: iAccountingEntryDetail.id,
            categoryId: iAccountingEntryDetail.category?.id,
            auftragskonto: iAccountingEntryDetail.auftragskonto,
            buchungsdatum: iAccountingEntryDetail.buchungsdatum,
            valutaDatum: iAccountingEntryDetail.valutaDatum,
            buchungstext: iAccountingEntryDetail.buchungstext,
            verwendungszweck: iAccountingEntryDetail.verwendungszweck,
            glaeubigerId: iAccountingEntryDetail.glaeubigerId,
            mandatsreferenz: iAccountingEntryDetail.mandatsreferenz,
            sammlerreferenz: iAccountingEntryDetail.sammlerreferenz,
            lastschriftUrsprungsbetrag: iAccountingEntryDetail.lastschriftUrsprungsbetrag,
            auslagenersatzRuecklastschrift: iAccountingEntryDetail.auslagenersatzRuecklastschrift,
            beguenstigter: iAccountingEntryDetail.beguenstigter,
            iban: iAccountingEntryDetail.iban,
            bic: iAccountingEntryDetail.bic,
            betrag: iAccountingEntryDetail.betrag,
            waehrung: iAccountingEntryDetail.waehrung,
            info: iAccountingEntryDetail.info,
        };
    }
}
