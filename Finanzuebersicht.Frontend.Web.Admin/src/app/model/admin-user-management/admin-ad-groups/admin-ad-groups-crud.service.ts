import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPagedResult } from '@krz/material';
import { IPaginationOptions, toPaginationParams } from '@krz/material';
import { ApiAdminAdGroup } from './dtos/api/api-admin-ad-group';
import { ApiAdminAdGroupDetail } from './dtos/api/api-admin-ad-group-detail';
import { fromApiAdminAdGroup, IAdminAdGroup } from './dtos/i-admin-ad-group';
import { IAdminAdGroupCreate, toApiAdminAdGroupCreate } from './dtos/i-admin-ad-group-create';
import { fromApiAdminAdGroupDetail, IAdminAdGroupDetail } from './dtos/i-admin-ad-group-detail';
import { IAdminAdGroupUpdate, toApiAdminAdGroupUpdate } from './dtos/i-admin-ad-group-update';

@Injectable()
export class AdminAdGroupsCrudService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async getPagedAdminAdGroups(paginationOptions: IPaginationOptions): Promise<IPagedResult<IAdminAdGroup>> {
        const url = '/api/admin-user-management/admin-ad-groups?' + toPaginationParams(paginationOptions);
        const adminAdGroupsResult = await this.backendCoreService.get<IPagedResult<ApiAdminAdGroup>>(url);

        adminAdGroupsResult.data = adminAdGroupsResult.data.map(adminAdGroup => fromApiAdminAdGroup(adminAdGroup));
        return adminAdGroupsResult;
    }

    public async getAdminAdGroup(id: string): Promise<IAdminAdGroupDetail> {
        const apiAdminAdGroupDetail = await this.backendCoreService
            .get<ApiAdminAdGroupDetail>('/api/admin-user-management/admin-ad-groups/' + id);

        const adminAdGroupDetail = fromApiAdminAdGroupDetail(apiAdminAdGroupDetail);
        return adminAdGroupDetail;
    }

    public async createAdminAdGroup(adminAdGroupCreate: IAdminAdGroupCreate): Promise<string> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminAdGroupCreate(adminAdGroupCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/admin-user-management/admin-ad-groups', options);

        const newAdminAdGroupId = result.data;
        return newAdminAdGroupId;
    }

    public async updateAdminAdGroup(adminAdGroupUpdate: IAdminAdGroupUpdate): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminAdGroupUpdate(adminAdGroupUpdate)
        };

        await this.backendCoreService.put('/api/admin-user-management/admin-ad-groups', options);
    }

    public async deleteAdminAdGroup(adminAdGroupId: string): Promise<void> {
        await this.backendCoreService.delete('/api/admin-user-management/admin-ad-groups/' + adminAdGroupId);
    }

}
