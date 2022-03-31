import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPermissions, toApiPermissions } from '../../permissions/dtos/i-permissions';

@Injectable()
export class AdminEmailUsersPermissionService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async updateAdminEmailUserPermissions(adminEmailUserId: string, permissions: IPermissions): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: { permissions: toApiPermissions(permissions) }
        };

        await this.backendCoreService.put('/api/admin-user-management/admin-email-users/' + adminEmailUserId + '/permissions', options);
    }

}
