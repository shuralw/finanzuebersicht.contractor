import { Injectable } from '@angular/core';
import { IPagedResult, IPaginationOptions, toPaginationParams } from '@krz/material';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { ICategory } from './dtos/i-category';
import { ICategoryChartItem } from './dtos/i-category-chart-item';
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

    public async getSummedCategories(): Promise<ICategoryChartItem[]> {
        const url = '/api/accounting/categories/all-summed';
        return await this.backendCoreService.get<ICategoryChartItem[]>(url);
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

    public async createCategories(formData: FormData): Promise<string> {
        const options = {
            body: formData
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/accounting/categories/multiple', options);

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
