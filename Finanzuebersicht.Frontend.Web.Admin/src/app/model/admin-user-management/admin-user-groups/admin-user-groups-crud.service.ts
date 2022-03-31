import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPagedResult } from '@krz/material';
import { IPaginationOptions, toPaginationParams } from '@krz/material';
import { ApiAdminUserGroup } from './dtos/api/api-admin-user-group';
import { ApiAdminUserGroupDetail } from './dtos/api/api-admin-user-group-detail';
import { fromApiAdminUserGroup, IAdminUserGroup } from './dtos/i-admin-user-group';
import { IAdminUserGroupCreate, toApiAdminUserGroupCreate } from './dtos/i-admin-user-group-create';
import { fromApiAdminUserGroupDetail, IAdminUserGroupDetail } from './dtos/i-admin-user-group-detail';
import { IAdminUserGroupUpdate, toApiAdminUserGroupUpdate } from './dtos/i-admin-user-group-update';

@Injectable()
export class AdminUserGroupsCrudService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async getPagedAdminUserGroups(paginationOptions: IPaginationOptions): Promise<IPagedResult<IAdminUserGroup>> {
        const url = '/api/admin-user-management/admin-user-groups?' + toPaginationParams(paginationOptions);
        const adminEmailUsersResult = await this.backendCoreService.get<IPagedResult<ApiAdminUserGroup>>(url);

        adminEmailUsersResult.data = adminEmailUsersResult.data.map(adminEmailUser => fromApiAdminUserGroup(adminEmailUser));
        return adminEmailUsersResult;
    }

    public async getAdminUserGroup(id: string): Promise<IAdminUserGroupDetail> {
        const apiAdminUserGroupDetail = await this.backendCoreService
            .get<ApiAdminUserGroupDetail>('/api/admin-user-management/admin-user-groups/' + id);

        const adminUserGroupDetail = fromApiAdminUserGroupDetail(apiAdminUserGroupDetail);
        return adminUserGroupDetail;
    }

    public async createAdminUserGroup(adminUserGroupCreate: IAdminUserGroupCreate): Promise<string> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminUserGroupCreate(adminUserGroupCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/admin-user-management/admin-user-groups', options);

        const newAdminUserGroupId = result.data;
        return newAdminUserGroupId;
    }

    public async updateAdminUserGroup(adminUserGroupUpdate: IAdminUserGroupUpdate): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminUserGroupUpdate(adminUserGroupUpdate)
        };

        await this.backendCoreService.put('/api/admin-user-management/admin-user-groups', options);
    }

    public async deleteAdminUserGroup(adminUserGroupId: string): Promise<void> {
        await this.backendCoreService.delete('/api/admin-user-management/admin-user-groups/' + adminUserGroupId);
    }

}
