import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminUserGroupsCrudService } from './admin-user-groups-crud.service';
import { AdminUserGroupsMembershipService } from './services/admin-user-groups-membership.service';
import { AdminUserGroupsPermissionService } from './services/admin-user-groups-permission.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AdminUserGroupsCrudService,
    AdminUserGroupsMembershipService,
    AdminUserGroupsPermissionService,
  ]
})
export class AdminUserGroupsModule { }
