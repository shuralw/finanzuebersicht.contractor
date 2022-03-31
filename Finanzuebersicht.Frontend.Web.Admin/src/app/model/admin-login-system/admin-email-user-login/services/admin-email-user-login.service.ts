import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { SessionService } from 'src/app/model/admin-session-management/sessions/session.service';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IAdminEmailUserLogin, toApiAdminEmailUserLogin } from '../dtos/i-admin-email-user-login';

@Injectable()
export class AdminEmailUserLoginService {

    constructor(
        private backendCoreService: BackendCoreService,
        private sessionService: SessionService) {
    }

    public async login(adminEmailUserLogin: IAdminEmailUserLogin): Promise<void> {
        const body: KrzRestBodyOptions = {
            body: toApiAdminEmailUserLogin(adminEmailUserLogin),
            withCredentials: true,
            errorInterceptor: { intercept: async () => { } }
        };

        await this.backendCoreService.post('/api/session/login', body);
        await this.sessionService.onLogin();
    }

}
