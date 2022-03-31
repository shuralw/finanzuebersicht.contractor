import { Injectable } from '@angular/core';
import { KrzRestBodyOptions } from '@krz/common';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';

@Injectable()
export class AdminEmailUserPasswordResetService {

  constructor(private backendCoreService: BackendCoreService) {

  }

  public async forgotPassword(email: string): Promise<void> {
    const body: KrzRestBodyOptions = {
      body: {
        email,
      },
      errorInterceptor: { intercept: async () => { } }
    };

    await this.backendCoreService.post('/api/admin-user-management/admin-email-users/forgotpassword', body);
  }

  public async resetPassword(token: string, newPassword: string): Promise<void> {
    const body: KrzRestBodyOptions = {
      body: {
        token,
        newPassword
      },
      errorInterceptor: { intercept: async () => { } }
    };

    await this.backendCoreService.put('/api/admin-user-management/admin-email-users/resetpassword', body);
  }

}
