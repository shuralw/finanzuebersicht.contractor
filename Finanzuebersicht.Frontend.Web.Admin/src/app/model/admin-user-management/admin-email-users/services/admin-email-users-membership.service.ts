import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';

@Injectable()
export class AdminEmailUsersMembershipService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async addAdminEmailUserToAdminUserGroup(adminEmailUserId: string, adminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminEmailUserId,
                adminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-email-users/add', options);
    }

    public async removeAdminEmailUserFromAdminUserGroup(adminEmailUserId: string, adminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminEmailUserId,
                adminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-email-users/remove', options);
    }

}
