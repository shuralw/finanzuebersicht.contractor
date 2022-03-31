import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPermissions, toApiPermissions } from '../../permissions/dtos/i-permissions';

@Injectable()
export class AdminAdGroupsPermissionService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async updateAdminAdGroupPermissions(adminAdGroupId: string, permissions: IPermissions): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: { permissions: toApiPermissions(permissions) }
        };

        await this.backendCoreService.put('/api/admin-user-management/admin-ad-groups/' + adminAdGroupId + '/permissions', options);
    }

}
