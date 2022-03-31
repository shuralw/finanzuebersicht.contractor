import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';

@Injectable()
export class AdminUserGroupsMembershipService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async addAdminUserGroupToAdminUserGroup(adminUserGroupId: string, parentAdminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminUserGroupId,
                parentAdminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-user-groups/add', options);
    }

    public async removeAdminUserGroupFromAdminUserGroup(adminUserGroupId: string, parentAdminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminUserGroupId,
                parentAdminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-user-groups/remove', options);
    }

}
