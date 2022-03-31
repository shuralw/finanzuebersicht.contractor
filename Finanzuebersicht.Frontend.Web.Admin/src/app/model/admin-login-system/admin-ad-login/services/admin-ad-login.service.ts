import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { SessionService } from 'src/app/model/admin-session-management/sessions/session.service';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { BackendSsoService } from 'src/app/services/backend/backend-sso.service';
import { SessionKeyResponse } from '../dtos/sessionkey-response';

@Injectable()
export class AdminAdLoginService {

    constructor(
        private backendCoreService: BackendCoreService,
        private backendSsoService: BackendSsoService,
        private sessionService: SessionService) {
    }

    public async login(): Promise<void> {
        const body: KrzRestBodyOptions = {
            body: {
                ssoToken: await this.getSsoToken(),
            },
            withCredentials: true,
            errorInterceptor: { intercept: async () => { } },
        };

        await this.backendCoreService.post('/api/session/login/ad', body);

        await this.sessionService.onLogin();
    }

    private async getSsoToken(): Promise<string> {
        const body: KrzRestBodyOptions = {
            withCredentials: true,
            errorInterceptor: {
                intercept: async () => { }
            },
        };

        const sessionKeyResponse = await this.backendSsoService.get<SessionKeyResponse>('/sso', body);

        return sessionKeyResponse.sessionkey;
    }

}
