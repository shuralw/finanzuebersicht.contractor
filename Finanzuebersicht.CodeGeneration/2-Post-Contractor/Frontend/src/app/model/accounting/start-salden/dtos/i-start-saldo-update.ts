import { IStartSaldoDetail } from './i-start-saldo-detail';

export interface IStartSaldoUpdate {
    id: string;
    betrag: number;
    datumAm: Date;
}

export abstract class StartSaldoUpdate {
    public static fromStartSaldoDetail(iStartSaldoDetail: IStartSaldoDetail): IStartSaldoUpdate {
        return {
            id: iStartSaldoDetail.id,
            betrag: iStartSaldoDetail.betrag,
            datumAm: iStartSaldoDetail.datumAm,
        };
    }
}
