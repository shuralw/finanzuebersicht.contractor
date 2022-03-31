import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendCoreAuthService } from 'src/app/services/backend/authentication/backend-core-auth.service';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { SessionInformationService } from './services/session-information.service';

export enum SessionState {
  ManuallyLoggedIn,
  ManuallyLoggedOut,
  AdminAccessTokenRefreshed,
  AdminRefreshTokenExpired,
}

@Injectable()
export class SessionService {

  private sessionState: SessionState;
  private onSessionStateChangeEvent = new EventEmitter<SessionState>();

  constructor(
    private sessionInformationService: SessionInformationService,
    private backendCoreService: BackendCoreService,
    private backendCoreAuthService: BackendCoreAuthService) {
  }

  public async initialize(): Promise<void> {
    await this.backendCoreAuthService.refreshAdminAccessToken();
    if (this.backendCoreAuthService.hasAdminAccessToken()) {
      this.setSessionState(SessionState.ManuallyLoggedIn);
    } else {
      this.setSessionState(SessionState.ManuallyLoggedOut);
    }

    this.backendCoreAuthService.onRefreshSuccessful().subscribe(() => {
      this.sessionInformationService.clearCache();
      this.setSessionState(SessionState.AdminAccessTokenRefreshed);
    });

    this.backendCoreAuthService.onRefreshFailed().subscribe(() => {
      if (this.isLoggedIn()) {
        this.performPostLogoutActions();
        this.setSessionState(SessionState.AdminRefreshTokenExpired);
      }
    });
  }

  // -------------- Session State --------------

  public async onLogin(): Promise<void> {
    await this.backendCoreAuthService.refreshAdminAccessToken();
    await this.sessionInformationService.retrieveSessionInformation();
    this.setSessionState(SessionState.ManuallyLoggedIn);
  }

  public setSessionState(sessionState: SessionState): void {
    this.sessionState = sessionState;
    this.onSessionStateChangeEvent.emit(sessionState);
  }

  public onSessionStateChange(): Observable<SessionState> {
    return this.onSessionStateChangeEvent.pipe();
  }

  // -------------- Session  --------------

  public isLoggedIn(): boolean {
    return this.sessionState === SessionState.ManuallyLoggedIn ||
      this.sessionState === SessionState.AdminAccessTokenRefreshed;
  }

  public async logout(): Promise<any> {
    await this.performBackendLogout();

    this.performPostLogoutActions();
    this.setSessionState(SessionState.ManuallyLoggedOut);
  }

  private async performBackendLogout(): Promise<void> {
    try {
      await this.backendCoreService.delete('/api/session/logout', {
        withCredentials: true
      });
    } catch (e) {
      // The Logout Operation should be considered as successful, if the session is not valid anymore.
      // An invalid session results in an 401-Error
      if (e.status !== 401) {
        throw e;
      }
    }
  }

  private performPostLogoutActions(): void {
    this.backendCoreAuthService.dropAdminAccessToken();
    this.sessionInformationService.clearCache();
  }
}
