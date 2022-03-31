import { EventEmitter, Injectable } from '@angular/core';
import { KrzRestService } from '@krz/common';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class BackendCoreAuthService {

    // Environment Variables
    private readonly BASEPATH: string;

    // Events
    private onRefreshSuccessfulEventEmitter = new EventEmitter<void>();
    private onRefreshFailedEventEmitter = new EventEmitter<void>();

    // Access Token
    private adminAccessToken: string;

    constructor(private krzRestService: KrzRestService) {
        this.BASEPATH = environment.backendCoreBaseUrl;
    }

    public hasAdminAccessToken(): boolean {
        return this.adminAccessToken != null;
    }

    public getAdminAccessToken(): string {
        return this.adminAccessToken;
    }

    public dropAdminAccessToken(): void {
        this.adminAccessToken = null;
    }

    public async refreshAdminAccessToken(): Promise<void> {
        try {
            const response = await this.krzRestService.post<{ data: string }>(this.BASEPATH + '/api/session/access', {
                withCredentials: true,
            });
            this.adminAccessToken = response.data;
            this.onRefreshSuccessfulEventEmitter.emit();
        } catch {
            this.adminAccessToken = null;
            this.onRefreshFailedEventEmitter.emit();
        }
    }

    public onRefreshSuccessful(): Observable<void> {
        return this.onRefreshSuccessfulEventEmitter.pipe();
    }

    public onRefreshFailed(): Observable<void> {
        return this.onRefreshFailedEventEmitter.pipe();
    }
}
