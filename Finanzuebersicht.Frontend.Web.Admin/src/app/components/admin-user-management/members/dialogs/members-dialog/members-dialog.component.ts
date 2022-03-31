import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConfirmationDialog } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.component';
import { DropdownPaginationDataSource } from '@krz/material';
import { AdminAdGroupsCrudService } from 'src/app/model/admin-user-management/admin-ad-groups/admin-ad-groups-crud.service';
import { IAdminAdGroup } from 'src/app/model/admin-user-management/admin-ad-groups/dtos/i-admin-ad-group';
import { AdminAdUsersCrudService } from 'src/app/model/admin-user-management/admin-ad-users/admin-ad-users-crud.service';
import { IAdminAdUser } from 'src/app/model/admin-user-management/admin-ad-users/dtos/i-admin-ad-user';
import { IAdminEmailUser } from 'src/app/model/admin-user-management/admin-email-users/dtos/i-admin-email-user';
import { AdminEmailUsersCrudService } from 'src/app/model/admin-user-management/admin-email-users/admin-email-users-crud.service';
import { IMember } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-member';
import { IAdminUserGroup } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group';
import { AdminUserGroupsCrudService } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups-crud.service';
import { UserType } from 'src/app/model/admin-user-management/user-type';

@Component({
  selector: 'app-members-dialog',
  templateUrl: './members-dialog.component.html',
  styleUrls: ['./members-dialog.component.scss']
})
export class MembersDialogComponent {

  adminEmailUsersToExclude: IAdminEmailUser[];
  adminUserGroupsToExclude: IAdminUserGroup[];
  adminAdUsersToExclude: IAdminAdUser[];
  adminAdGroupsToExclude: IAdminAdGroup[];

  adminEmailUsersDataSource: DropdownPaginationDataSource<IAdminEmailUser>;
  adminUserGroupsDataSource: DropdownPaginationDataSource<IAdminUserGroup>;
  adminAdUsersDataSource: DropdownPaginationDataSource<IAdminAdUser>;
  adminAdGroupsDataSource: DropdownPaginationDataSource<IAdminAdGroup>;

  formGroup: FormGroup;

  public elementTypes = ['E-Mail Benutzer', 'Gruppe', 'AD-Benutzer', 'AD-Gruppe'];

  constructor(
    private adminEmailUsersCrudService: AdminEmailUsersCrudService,
    private adminUserGroupsCrudService: AdminUserGroupsCrudService,
    private adminAdUsersCrudService: AdminAdUsersCrudService,
    private adminAdGroupsCrudService: AdminAdGroupsCrudService,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) data: any,
    private dialogRef: MatDialogRef<ConfirmationDialog>) {

    this.adminEmailUsersToExclude = data.adminEmailUsersToExclude;
    this.adminUserGroupsToExclude = data.adminUserGroupsToExclude;
    this.adminAdUsersToExclude = data.adminAdUsersToExclude;
    this.adminAdGroupsToExclude = data.adminAdGroupsToExclude;

    this.adminEmailUsersDataSource = new DropdownPaginationDataSource(
      (options) => this.adminEmailUsersCrudService.getPagedAdminEmailUsers(options),
      'email');
    this.adminUserGroupsDataSource = new DropdownPaginationDataSource(
      (options) => this.adminUserGroupsCrudService.getPagedAdminUserGroups(options),
      'name');
    this.adminAdUsersDataSource = new DropdownPaginationDataSource(
      (options) => this.adminAdUsersCrudService.getPagedAdminAdUsers(options),
      'dn');
    this.adminAdGroupsDataSource = new DropdownPaginationDataSource(
      (options) => this.adminAdGroupsCrudService.getPagedAdminAdGroups(options),
      'dn');

    this.formGroup = this.formBuilder.group({
      userType: new FormControl(0, [Validators.required]),
      memberId: new FormControl(null, [
        Validators.required,
        Validators.compose([() => {
          if (!this.isValid()) {
            return { alreadyExists: true };
          } else {
            return {};
          }
        }])
      ]),
    });
  }

  onConfirmClick(): void {
    this.formGroup.markAllAsTouched();
    if (this.formGroup.valid) {
      const member: IMember = {
        id: this.formGroup.controls.memberId.value,
        userType: this.formGroup.controls.userType.value
      };
      this.dialogRef.close(member);
    }
  }

  isValid(): boolean {
    if (this.formGroup && this.formGroup.controls) {
      const userType = this.formGroup.controls.userType.value;
      const memberId = this.formGroup.controls.memberId.value;
      return (
        (userType === UserType.AdminEmailUser && !this.adminEmailUsersToExclude
          .map(adminEmailUser => adminEmailUser.id).includes(memberId)) ||
        (userType === UserType.AdminUserGroup && !this.adminUserGroupsToExclude
          .map(adminUserGroup => adminUserGroup.id).includes(memberId)) ||
        (userType === UserType.AdminAdUser && !this.adminAdUsersToExclude
          .map(adminAdUser => adminAdUser.id).includes(memberId)) ||
        (userType === UserType.AdminAdGroup && !this.adminAdGroupsToExclude
          .map(adminAdGroup => adminAdGroup.id).includes(memberId)));
    }
  }

}
