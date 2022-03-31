import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';

@Injectable()
export class AdminAdUsersMembershipService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async addAdminAdUserToAdminUserGroup(adminAdUserId: string, adminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminAdUserId,
                adminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-ad-users/add', options);
    }

    public async removeAdminAdUserFromAdminUserGroup(adminAdUserId: string, adminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminAdUserId,
                adminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-ad-users/remove', options);
    }

}
