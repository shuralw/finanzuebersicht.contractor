import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPagedResult } from '@krz/material';
import { IPaginationOptions, toPaginationParams } from '@krz/material';
import { ApiAdminEmailUser } from './dtos/api/api-admin-email-user';
import { ApiAdminEmailUserDetail } from './dtos/api/api-admin-email-user-detail';
import { fromApiAdminEmailUser, IAdminEmailUser } from './dtos/i-admin-email-user';
import { IAdminEmailUserCreate, toApiAdminEmailUserCreate } from './dtos/i-admin-email-user-create';
import { fromApiAdminEmailUserDetail, IAdminEmailUserDetail } from './dtos/i-admin-email-user-detail';
import { IAdminEmailUserUpdate, toApiAdminEmailUserUpdate } from './dtos/i-admin-email-user-update';

@Injectable()
export class AdminEmailUsersCrudService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async getPagedAdminEmailUsers(paginationOptions: IPaginationOptions): Promise<IPagedResult<IAdminEmailUser>> {
        const url = '/api/admin-user-management/admin-email-users?' + toPaginationParams(paginationOptions);
        const adminEmailUsersResult = await this.backendCoreService.get<IPagedResult<ApiAdminEmailUser>>(url);

        adminEmailUsersResult.data = adminEmailUsersResult.data.map(adminEmailUser => fromApiAdminEmailUser(adminEmailUser));
        return adminEmailUsersResult;
    }

    public async getAdminEmailUser(id: string): Promise<IAdminEmailUserDetail> {
        const apiAdminEmailUserDetail = await this.backendCoreService
            .get<ApiAdminEmailUserDetail>('/api/admin-user-management/admin-email-users/' + id);

        const adminEmailUserDetail = fromApiAdminEmailUserDetail(apiAdminEmailUserDetail);
        return adminEmailUserDetail;
    }

    public async createAdminEmailUser(adminEmailUserCreate: IAdminEmailUserCreate): Promise<string> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminEmailUserCreate(adminEmailUserCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/admin-user-management/admin-email-users', options);

        const newAdminEmailUserId = result.data;
        return newAdminEmailUserId;
    }

    public async updateAdminEmailUser(adminEmailUserUpdate: IAdminEmailUserUpdate): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminEmailUserUpdate(adminEmailUserUpdate)
        };

        await this.backendCoreService.put('/api/admin-user-management/admin-email-users', options);
    }

    public async deleteAdminEmailUser(adminEmailUserId: string): Promise<void> {
        await this.backendCoreService.delete('/api/admin-user-management/admin-email-users/' + adminEmailUserId);
    }

}
