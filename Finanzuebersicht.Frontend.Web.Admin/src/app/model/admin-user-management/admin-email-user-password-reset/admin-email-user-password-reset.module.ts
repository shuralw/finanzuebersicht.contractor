import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminEmailUserPasswordResetService } from './admin-email-user-password-reset.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AdminEmailUserPasswordResetService
  ]
})
export class AdminEmailUserPasswordResetModule { }
