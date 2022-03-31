import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminEmailUsersCrudService } from './admin-email-users-crud.service';
import { AdminEmailUsersChangePasswordService } from './services/admin-email-users-change-password.service';
import { AdminEmailUsersMembershipService } from './services/admin-email-users-membership.service';
import { AdminEmailUsersPermissionService } from './services/admin-email-users-permission.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AdminEmailUsersCrudService,
    AdminEmailUsersChangePasswordService,
    AdminEmailUsersMembershipService,
    AdminEmailUsersPermissionService,
  ]
})
export class AdminEmailUsersModule { }
