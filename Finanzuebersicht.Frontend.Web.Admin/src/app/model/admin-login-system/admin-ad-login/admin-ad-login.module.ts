import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminAdLoginService } from './services/admin-ad-login.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AdminAdLoginService
  ]
})
export class AdminAdLoginModule { }
