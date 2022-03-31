import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPagedResult } from '@krz/material';
import { IPaginationOptions, toPaginationParams } from '@krz/material';
import { ApiAdminAdUser } from './dtos/api/api-admin-ad-user';
import { ApiAdminAdUserDetail } from './dtos/api/api-admin-ad-user-detail';
import { fromApiAdminAdUser, IAdminAdUser } from './dtos/i-admin-ad-user';
import { IAdminAdUserCreate, toApiAdminAdUserCreate } from './dtos/i-admin-ad-user-create';
import { fromApiAdminAdUserDetail, IAdminAdUserDetail } from './dtos/i-admin-ad-user-detail';
import { IAdminAdUserUpdate, toApiAdminAdUserUpdate } from './dtos/i-admin-ad-user-update';

@Injectable()
export class AdminAdUsersCrudService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async getPagedAdminAdUsers(paginationOptions: IPaginationOptions): Promise<IPagedResult<IAdminAdUser>> {
        const url = '/api/admin-user-management/admin-ad-users?' + toPaginationParams(paginationOptions);
        const adminAdUsersResult = await this.backendCoreService.get<IPagedResult<ApiAdminAdUser>>(url);

        adminAdUsersResult.data = adminAdUsersResult.data.map(adminAdUser => fromApiAdminAdUser(adminAdUser));
        return adminAdUsersResult;
    }

    public async getAdminAdUser(id: string): Promise<IAdminAdUserDetail> {
        const apiAdminAdUserDetail = await this.backendCoreService
            .get<ApiAdminAdUserDetail>('/api/admin-user-management/admin-ad-users/' + id);

        const adminAdUserDetail = fromApiAdminAdUserDetail(apiAdminAdUserDetail);
        return adminAdUserDetail;
    }

    public async createAdminAdUser(adminAdUserCreate: IAdminAdUserCreate): Promise<string> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminAdUserCreate(adminAdUserCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/admin-user-management/admin-ad-users', options);

        const newAdminAdUserId = result.data;
        return newAdminAdUserId;
    }

    public async updateAdminAdUser(adminAdUserUpdate: IAdminAdUserUpdate): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminAdUserUpdate(adminAdUserUpdate)
        };

        await this.backendCoreService.put('/api/admin-user-management/admin-ad-users', options);
    }

    public async deleteAdminAdUser(adminAdUserId: string): Promise<void> {
        await this.backendCoreService.delete('/api/admin-user-management/admin-ad-users/' + adminAdUserId);
    }

}
