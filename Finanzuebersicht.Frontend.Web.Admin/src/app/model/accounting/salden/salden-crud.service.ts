import { Injectable } from '@angular/core';
import { IPagedResult, IPaginationOptions, toPaginationParams } from '@krz/material';
import * as moment from 'moment';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { ISaldoDetail } from './dtos/i-saldo-detail';
import { ISaldoListItem } from './dtos/i-saldo-list-item';

@Injectable()
export class SaldenCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getPagedSalden(fromDate: Date, toDate: Date): Promise<ISaldoListItem[]> {
        const url = '/api/accounting/salden?fromDate='
            +  moment(fromDate).format('YYYY-MM-DD') + '&toDate=' + moment(toDate).format('YYYY-MM-DD');
        return await this.backendCoreService.get<ISaldoListItem[]>(url);
    }

    public async getSaldoDetail(saldoId: string): Promise<ISaldoDetail> {
        return await this.backendCoreService.get<ISaldoDetail>('/api/accounting/accounting-entries/' + saldoId);
    }
}
