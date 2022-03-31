import { Injectable } from '@angular/core';
import { IPagedResult, IPaginationOptions, toPaginationParams } from '@krz/material';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IStartSaldoCreate } from './dtos/i-start-saldo-create';
import { IStartSaldoDetail } from './dtos/i-start-saldo-detail';
import { IStartSaldoListItem } from './dtos/i-start-saldo-list-item';
import { IStartSaldoUpdate } from './dtos/i-start-saldo-update';

@Injectable()
export class StartSaldenCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getPagedStartSalden(paginationOptions: IPaginationOptions): Promise<IPagedResult<IStartSaldoListItem>> {
        const url = '/api/accounting/start-salden?' + toPaginationParams(paginationOptions);
        return await this.backendCoreService.get<IPagedResult<IStartSaldoListItem>>(url);
    }

    public async getStartSaldoDetail(startSaldoId: string): Promise<IStartSaldoDetail> {
        return await this.backendCoreService.get<IStartSaldoDetail>('/api/accounting/start-salden/' + startSaldoId);
    }

    public async createStartSaldo(startSaldoCreate: IStartSaldoCreate): Promise<string> {
        const options = {
            body: startSaldoCreate
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/accounting/start-salden', options);

        const newStartSaldoId = result.data;
        return newStartSaldoId;
    }

    public async updateStartSaldo(startSaldoUpdate: IStartSaldoUpdate): Promise<void> {
        const options = {
            body: startSaldoUpdate
        };

        await this.backendCoreService.put('/api/accounting/start-salden', options);
    }

    public async deleteStartSaldo(startSaldoId: string): Promise<void> {
        await this.backendCoreService.delete('/api/accounting/start-salden/' + startSaldoId);
    }

}
