import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminAdUsersCrudService } from './admin-ad-users-crud.service';
import { AdminAdUsersMembershipService } from './services/admin-ad-users-membership.service';
import { AdminAdUsersPermissionService } from './services/admin-ad-users-permission.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AdminAdUsersCrudService,
    AdminAdUsersMembershipService,
    AdminAdUsersPermissionService,
  ]
})
export class AdminAdUsersModule { }
