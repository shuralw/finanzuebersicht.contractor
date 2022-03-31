import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { UserTypePipe } from './benutzer-type.pipe';
import { PermissionNamePipe } from './permission-name.pipe';

@NgModule({
  declarations: [
    PermissionNamePipe,
    UserTypePipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    PermissionNamePipe,
    UserTypePipe
  ]
})
export class AdminUserManagementPipesModule { }
