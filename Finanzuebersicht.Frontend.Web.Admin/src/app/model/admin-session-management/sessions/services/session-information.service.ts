import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPermissions } from '../../../admin-user-management/permissions/dtos/i-permissions';
import { ApiSessionInformation } from '../dtos/api/api-session-information';
import { fromApiSessionInformation, ISessionInformation } from '../dtos/i-session-information';

@Injectable()
export class SessionInformationService {

    private sessionInformationCache: ISessionInformation;

    constructor(private backendCoreService: BackendCoreService) {
    }

    public async getPermissions(): Promise<IPermissions> {
        const sessionInformation = await this.getCachedSessionInfo();
        return sessionInformation.permissions;
    }

    public async getAdminEmailUserId(): Promise<string> {
        const sessionInformation = await this.getCachedSessionInfo();
        return sessionInformation.adminEmailUserId;
    }

    public async getName(): Promise<string> {
        const sessionInformation = await this.getCachedSessionInfo();
        return sessionInformation.username;
    }

    public async isAdSession(): Promise<boolean> {
        const sessionInformation = await this.getCachedSessionInfo();
        return sessionInformation.adminAdUserId !== null || sessionInformation.adminAdGroupIds.length > 0;
    }

    public wasAdSession(): boolean {
        return this.sessionInformationCache != null &&
            (this.sessionInformationCache.adminAdUserId !== null || this.sessionInformationCache.adminAdGroupIds.length > 0);
    }

    public clearCache(): void {
        this.sessionInformationCache = null;
    }

    public async retrieveSessionInformation(): Promise<void> {
        const options: KrzRestBodyOptions = {
            errorInterceptor: {
                intercept: async () => { }
            }
        };

        const apiSessionInformation = await this.backendCoreService.get<ApiSessionInformation>('/api/session', options);

        this.sessionInformationCache = fromApiSessionInformation(apiSessionInformation);
    }

    private async getCachedSessionInfo(): Promise<ISessionInformation> {
        if (!this.sessionInformationCache) {
            await this.retrieveSessionInformation();
        }

        return { ...this.sessionInformationCache };
    }

}
