import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminAdGroupsCrudService } from './admin-ad-groups-crud.service';
import { AdminAdGroupsMembershipService } from './services/admin-ad-groups-membership.service';
import { AdminAdGroupsPermissionService } from './services/admin-ad-groups-permission.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AdminAdGroupsCrudService,
    AdminAdGroupsMembershipService,
    AdminAdGroupsPermissionService,
  ]
})
export class AdminAdGroupsModule { }
