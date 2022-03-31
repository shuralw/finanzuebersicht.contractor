import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KrzRestBodyOptions, KrzRestOptions, KrzRestService } from '@krz/common';
import { environment } from 'src/environments/environment';
import { BackendCoreAuthService } from './authentication/backend-core-auth.service';

@Injectable()
export class BackendCoreService {

    private BASEPATH: string;

    constructor(
        private restService: KrzRestService,
        private backendCoreAuthService: BackendCoreAuthService) {
        this.BASEPATH = environment.backendCoreBaseUrl;
    }

    public async get<T>(urlPath: string, options?: KrzRestOptions): Promise<T> {
        try {
            return await this.performGetRequest(urlPath, options);
        } catch (e) {
            const httpErrorResponse = e as HttpErrorResponse;
            if (httpErrorResponse.status === 401 && this.backendCoreAuthService.hasAdminAccessToken()) {
                await this.backendCoreAuthService.refreshAdminAccessToken();
                if (this.backendCoreAuthService.hasAdminAccessToken()) {
                    return await this.performGetRequest<T>(urlPath, options);
                }
            }

            throw e;
        }
    }

    public async post<T>(urlPath: string, options?: KrzRestBodyOptions): Promise<T> {
        try {
            return await this.performPostRequest(urlPath, options);
        } catch (e) {
            const httpErrorResponse = e as HttpErrorResponse;
            if (httpErrorResponse.status === 401 && this.backendCoreAuthService.hasAdminAccessToken()) {
                await this.backendCoreAuthService.refreshAdminAccessToken();
                if (this.backendCoreAuthService.hasAdminAccessToken()) {
                    return await this.performPostRequest(urlPath, options);
                }
            }

            throw e;
        }
    }

    public async put<T>(urlPath: string, options?: KrzRestBodyOptions): Promise<T> {
        try {
            return await this.performPutRequest(urlPath, options);
        } catch (e) {
            const httpErrorResponse = e as HttpErrorResponse;
            if (httpErrorResponse.status === 401 && this.backendCoreAuthService.hasAdminAccessToken()) {
                await this.backendCoreAuthService.refreshAdminAccessToken();
                if (this.backendCoreAuthService.hasAdminAccessToken()) {
                    return await this.performPutRequest(urlPath, options);
                }
            }

            throw e;
        }
    }

    public async delete<T>(urlPath: string, options?: KrzRestOptions): Promise<T> {
        try {
            return await this.performDeleteRequest(urlPath, options);
        } catch (e) {
            const httpErrorResponse = e as HttpErrorResponse;
            if (httpErrorResponse.status === 401 && this.backendCoreAuthService.hasAdminAccessToken()) {
                await this.backendCoreAuthService.refreshAdminAccessToken();
                if (this.backendCoreAuthService.hasAdminAccessToken()) {
                    return await this.performDeleteRequest<T>(urlPath, options);
                }
            }

            throw e;
        }
    }

    // ----------------- Privates -----------------

    private async performGetRequest<T>(urlPath: string, options?: KrzRestOptions): Promise<T> {
        options = await this.adjustOptions(options);
        return await this.restService.get<T>(this.BASEPATH + urlPath, options);
    }

    private async performPostRequest<T>(urlPath: string, options?: KrzRestBodyOptions): Promise<T> {
        options = await this.adjustOptions(options);
        return await this.restService.post<T>(this.BASEPATH + urlPath, options);
    }

    private async performPutRequest<T>(urlPath: string, options?: KrzRestBodyOptions): Promise<T> {
        options = await this.adjustOptions(options);
        return await this.restService.put<T>(this.BASEPATH + urlPath, options);
    }

    private async performDeleteRequest<T>(urlPath: string, options?: KrzRestOptions): Promise<T> {
        options = await this.adjustOptions(options);
        return await this.restService.delete<T>(this.BASEPATH + urlPath, options);
    }

    async adjustOptions(options?: KrzRestOptions): Promise<KrzRestOptions> {
        if (!this.backendCoreAuthService.hasAdminAccessToken()) {
            return { ...options };
        }

        return {
            header: {
                Authorization: 'Bearer ' + this.backendCoreAuthService.getAdminAccessToken()
            },
            ...options
        };
    }
}
