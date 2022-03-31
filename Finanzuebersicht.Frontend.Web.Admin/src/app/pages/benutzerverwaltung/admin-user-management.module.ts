import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminUserManagementPagesRouting } from './admin-user-management.routing';

@NgModule({
  imports: [
    // Routing Modules
    AdminUserManagementPagesRouting,

    // Misc Modules
    CommonModule,
  ]
})
export class AdminUserManagementPagesModule { }
