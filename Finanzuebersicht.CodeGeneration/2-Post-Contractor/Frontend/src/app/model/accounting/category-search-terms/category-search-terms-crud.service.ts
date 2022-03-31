import { Injectable } from '@angular/core';
import { IPagedResult, IPaginationOptions, toPaginationParams } from '@krz/material';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { ICategorySearchTermCreate } from './dtos/i-category-search-term-create';
import { ICategorySearchTermDetail } from './dtos/i-category-search-term-detail';
import { ICategorySearchTermListItem } from './dtos/i-category-search-term-list-item';
import { ICategorySearchTermUpdate } from './dtos/i-category-search-term-update';

@Injectable()
export class CategorySearchTermsCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getPagedCategorySearchTerms(paginationOptions: IPaginationOptions): Promise<IPagedResult<ICategorySearchTermListItem>> {
        const url = '/api/accounting/category-search-terms?' + toPaginationParams(paginationOptions);
        return await this.backendCoreService.get<IPagedResult<ICategorySearchTermListItem>>(url);
    }

    public async getCategorySearchTermDetail(categorySearchTermId: string): Promise<ICategorySearchTermDetail> {
        return await this.backendCoreService.get<ICategorySearchTermDetail>('/api/accounting/category-search-terms/' + categorySearchTermId);
    }

    public async createCategorySearchTerm(categorySearchTermCreate: ICategorySearchTermCreate): Promise<string> {
        const options = {
            body: categorySearchTermCreate
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/accounting/category-search-terms', options);

        const newCategorySearchTermId = result.data;
        return newCategorySearchTermId;
    }

    public async updateCategorySearchTerm(categorySearchTermUpdate: ICategorySearchTermUpdate): Promise<void> {
        const options = {
            body: categorySearchTermUpdate
        };

        await this.backendCoreService.put('/api/accounting/category-search-terms', options);
    }

    public async deleteCategorySearchTerm(categorySearchTermId: string): Promise<void> {
        await this.backendCoreService.delete('/api/accounting/category-search-terms/' + categorySearchTermId);
    }

}
