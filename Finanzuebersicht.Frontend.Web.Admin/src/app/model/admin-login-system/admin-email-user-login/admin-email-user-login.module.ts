import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminEmailUserLoginService } from './services/admin-email-user-login.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AdminEmailUserLoginService
  ]
})
export class AdminEmailUserLoginModule { }
