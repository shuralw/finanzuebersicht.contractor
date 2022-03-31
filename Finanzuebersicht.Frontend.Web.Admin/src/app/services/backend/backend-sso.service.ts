import { Injectable } from '@angular/core';
import { KrzRestOptions, KrzRestService } from '@krz/common';
import { environment } from 'src/environments/environment';

@Injectable()
export class BackendSsoService {

    private SSO_BASEPATH: string;

    constructor(private restService: KrzRestService) {
        this.SSO_BASEPATH = environment.ssoWebserviceBaseUrl;
    }

    public async get<T>(urlPath: string, options?: KrzRestOptions): Promise<T> {
        return await this.restService.get<T>(this.SSO_BASEPATH + urlPath, options);
    }
}
