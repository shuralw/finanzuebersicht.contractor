import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConfirmationDialog } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.component';
import { DropdownPaginationDataSource } from '@krz/material';
import { IAdminUserGroup } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group';
import { AdminUserGroupsCrudService } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups-crud.service';

@Component({
  selector: 'app-member-of-dialog',
  templateUrl: './member-of-dialog.component.html',
  styleUrls: ['./member-of-dialog.component.scss']
})
export class MemberOfDialogComponent {

  adminUserGroupsDataSource: DropdownPaginationDataSource<IAdminUserGroup>;
  adminUserGroupsToExclude: IAdminUserGroup[];

  formGroup: FormGroup;

  constructor(
    private adminUserGroupsCrudService: AdminUserGroupsCrudService,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) data: any,
    private dialogRef: MatDialogRef<ConfirmationDialog>) {

    this.adminUserGroupsToExclude = data.adminUserGroupsToExclude;

    this.adminUserGroupsDataSource = new DropdownPaginationDataSource(
      (options) => this.adminUserGroupsCrudService.getPagedAdminUserGroups(options),
      'name');

    this.formGroup = this.formBuilder.group({
      adminUserGroupId: new FormControl(null, [
        Validators.required,
        Validators.compose([() => {
          if (!this.isValid()) {
            return { alreadyExists: true };
          } else {
            return {};
          }
        }])
      ])
    });
  }

  onConfirmClick(): void {
    this.formGroup.markAllAsTouched();
    if (this.formGroup.valid) {
      this.dialogRef.close(this.formGroup.controls.adminUserGroupId.value);
    }
  }

  isValid(): boolean {
    if (this.formGroup && this.formGroup.controls) {
      const adminUserGroupId = this.formGroup.controls.adminUserGroupId.value;
      return !this.adminUserGroupsToExclude.map(adminUserGroup => adminUserGroup.id).includes(adminUserGroupId);
    }
  }

}
