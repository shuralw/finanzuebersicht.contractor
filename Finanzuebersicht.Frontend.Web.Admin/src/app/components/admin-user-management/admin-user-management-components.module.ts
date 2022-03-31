import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { TableFilterBarModule, SearchDropdownModule } from '@krz/material';
import { AdminAdGroupsModule } from 'src/app/model/admin-user-management/admin-ad-groups/admin-ad-groups.module';
import { AdminAdUsersModule } from 'src/app/model/admin-user-management/admin-ad-users/admin-ad-users.module';
import { AdminEmailUsersModule } from 'src/app/model/admin-user-management/admin-email-users/admin-email-users.module';
import { AdminUserGroupsModule } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups.module';
import { UiComponentsModule } from '../ui/ui-components.module';
import { MemberOfDialogComponent } from './member-of/dialogs/member-of-dialog/member-of-dialog.component';
import { MemberOfComponent } from './member-of/member-of.component';
import { MembersDialogComponent } from './members/dialogs/members-dialog/members-dialog.component';
import { MembersComponent } from './members/members.component';
import { PermissionsDisplayComponent } from './permissions-display/permissions-display.component';
import { PermissionsComponent } from './permissions/permissions.component';

@NgModule({
  declarations: [
    PermissionsComponent,
    PermissionsDisplayComponent,
    MembersComponent,
    MembersDialogComponent,
    MemberOfComponent,
    MemberOfDialogComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    UiComponentsModule,
    TableFilterBarModule,
    SearchDropdownModule,
    AdminAdGroupsModule,
    AdminAdUsersModule,
    AdminEmailUsersModule,
    AdminUserGroupsModule,
    MatButtonModule,
    MatDialogModule,
    MatIconModule,
    MatInputModule,
    MatMenuModule,
    MatSelectModule,
    MatSnackBarModule,
    MatTableModule,
  ],
  exports: [
    PermissionsComponent,
    PermissionsDisplayComponent,
    MembersComponent,
    MemberOfComponent
  ]
})
export class AdminUserManagementComponentsModule { }
