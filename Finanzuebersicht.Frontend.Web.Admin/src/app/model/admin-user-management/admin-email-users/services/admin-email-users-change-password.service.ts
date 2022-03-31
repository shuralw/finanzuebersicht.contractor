import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IAdminEmailUserChangePassword, toApiAdminEmailUserChangePassword } from '../dtos/i-admin-email-user-change-password';

@Injectable()
export class AdminEmailUsersChangePasswordService {

    constructor(
        private backendCoreService: BackendCoreService) {
    }

    public async changePassword(adminEmailUserChangePassword: IAdminEmailUserChangePassword): Promise<void> {
        const options: KrzRestBodyOptions = {
            body: toApiAdminEmailUserChangePassword(adminEmailUserChangePassword),
            errorInterceptor: { intercept: async () => { } }
        };

        await this.backendCoreService.put('/api/admin-user-management/admin-email-users/change-password', options);
    }

}
