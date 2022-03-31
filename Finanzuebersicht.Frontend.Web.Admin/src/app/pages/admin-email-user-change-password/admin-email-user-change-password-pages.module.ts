import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { AdminEmailUsersModule } from 'src/app/model/admin-user-management/admin-email-users/admin-email-users.module';
import { AdminEmailUsersChangePasswordPagesRouting } from './admin-email-user-change-password-pages.routing';
import { AdminEmailUsersChangePasswordPage } from './admin-email-user-change-password.page';

@NgModule({
  declarations: [
    AdminEmailUsersChangePasswordPage
  ],
  imports: [
    // Routing Modules
    AdminEmailUsersChangePasswordPagesRouting,

    // Model Modules
    AdminEmailUsersModule,

    // Angular Material Modules
    MatInputModule,
    MatButtonModule,

    // Misc Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class AdminEmailUsersChangePasswordPagesModule { }
