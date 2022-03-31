import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { UiComponentsModule } from 'src/app/components/ui/ui-components.module';
import { TableFilterBarModule, SearchDropdownModule } from '@krz/material';
import { AdminEmailUserLoginModule } from 'src/app/model/admin-login-system/admin-email-user-login/admin-email-user-login.module';
import { AdminEmailUserPasswordResetModule } from 'src/app/model/admin-user-management/admin-email-user-password-reset/admin-email-user-password-reset.module';
import { LoginPagesRouting } from './login-pages.routing';
import { LoginPage } from './login.page';
import { ForgotPasswordPage } from './forgot-password/forgot-password.page';
import { ResetPasswordPage } from './reset-password/reset-password.page';

@NgModule({
  declarations: [
    LoginPage,
    ForgotPasswordPage,
    ResetPasswordPage,
  ],
  imports: [
    // Routing Modules
    LoginPagesRouting,

    // Component Modules
    UiComponentsModule,

    // Angular Material Modules
    MatCardModule,
    MatButtonModule,
    MatInputModule,

    // Model Modules
    AdminEmailUserLoginModule,
    AdminEmailUserPasswordResetModule,

    // Misc Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class LoginPagesModule { }
