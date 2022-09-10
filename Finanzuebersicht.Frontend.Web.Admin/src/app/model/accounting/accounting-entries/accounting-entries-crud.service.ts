import { Binary } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { IPagedResult, IPaginationOptions, toPaginationParams } from '@krz/material';
import { CsvDictionary } from 'src/app/helpers/csv-helper';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IAccountingEntryCreate } from './dtos/i-accounting-entry-create';
import { IAccountingEntryDetail } from './dtos/i-accounting-entry-detail';
import { IAccountingEntryListItem } from './dtos/i-accounting-entry-list-item';
import { IAccountingEntryUpdate } from './dtos/i-accounting-entry-update';

@Injectable()
export class AccountingEntriesCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getPagedAccountingEntries(paginationOptions: IPaginationOptions): Promise<IPagedResult<IAccountingEntryListItem>> {
        const url = '/api/accounting/accounting-entries?' + toPaginationParams(paginationOptions);
        return await this.backendCoreService.get<IPagedResult<IAccountingEntryListItem>>(url);
    }

    public async getAccountingEntryDetail(accountingEntryId: string): Promise<IAccountingEntryDetail> {
        return await this.backendCoreService.get<IAccountingEntryDetail>('/api/accounting/accounting-entries/' + accountingEntryId);
    }

    public async createAccountingEntry(accountingEntryCreate: IAccountingEntryCreate): Promise<string> {
        const options = {
            body: accountingEntryCreate
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/accounting/accounting-entries', options);

        const newAccountingEntryId = result.data;
        return newAccountingEntryId;
    }

    public async createAccountingEntries(formData: FormData): Promise<string> {
        const options = {
            body: formData
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/accounting/accounting-entries/multiple', options);

        const newAccountingEntryId = result.data;
        return newAccountingEntryId;
    }

    public async UploadCsv(content: Blob): Promise<void> {
        await this.backendCoreService
            .post('/api/accounting/accounting-entries/csv-upload', {
                body: {},
                blob: {
                    name: 'testname',
                    content
                },
            });
    }

    public async updateAccountingEntry(accountingEntryUpdate: IAccountingEntryUpdate): Promise<void> {
        const options = {
            body: accountingEntryUpdate
        };

        await this.backendCoreService.put('/api/accounting/accounting-entries', options);
    }

    public async deleteAccountingEntry(accountingEntryId: string): Promise<void> {
        await this.backendCoreService.delete('/api/accounting/accounting-entries/' + accountingEntryId);
    }

}
