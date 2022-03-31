import { Injectable } from '@angular/core';
import { IPagedResult, IPaginationOptions, toPaginationParams } from '@krz/material';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { ICategoryCreate } from './dtos/i-category-create';
import { ICategoryDetail } from './dtos/i-category-detail';
import { ICategoryListItem } from './dtos/i-category-list-item';
import { ICategoryUpdate } from './dtos/i-category-update';

@Injectable()
export class CategoriesCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getPagedCategories(paginationOptions: IPaginationOptions): Promise<IPagedResult<ICategoryListItem>> {
        const url = '/api/accounting/categories?' + toPaginationParams(paginationOptions);
        return await this.backendCoreService.get<IPagedResult<ICategoryListItem>>(url);
    }

    public async getCategoryDetail(categoryId: string): Promise<ICategoryDetail> {
        return await this.backendCoreService.get<ICategoryDetail>('/api/accounting/categories/' + categoryId);
    }

    public async createCategory(categoryCreate: ICategoryCreate): Promise<string> {
        const options = {
            body: categoryCreate
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/accounting/categories', options);

        const newCategoryId = result.data;
        return newCategoryId;
    }

    public async updateCategory(categoryUpdate: ICategoryUpdate): Promise<void> {
        const options = {
            body: categoryUpdate
        };

        await this.backendCoreService.put('/api/accounting/categories', options);
    }

    public async deleteCategory(categoryId: string): Promise<void> {
        await this.backendCoreService.delete('/api/accounting/categories/' + categoryId);
    }

}
