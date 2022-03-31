import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';

@Injectable()
export class AdminAdGroupsMembershipService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async addAdminAdGroupToAdminUserGroup(adminAdGroupId: string, adminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminAdGroupId,
                adminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-ad-groups/add', options);
    }

    public async removeAdminAdGroupFromAdminUserGroup(adminAdGroupId: string, adminUserGroupId: string): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: {
                adminAdGroupId,
                adminUserGroupId
            }
        };

        await this.backendCoreService.post('/api/admin-user-management/admin-user-groups/membership/admin-ad-groups/remove', options);
    }

}
