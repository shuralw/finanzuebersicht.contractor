import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AdminAdGroupsPermissionService } from 'src/app/model/admin-user-management/admin-ad-groups/services/admin-ad-groups-permission.service';
import { AdminAdUsersPermissionService } from 'src/app/model/admin-user-management/admin-ad-users/services/admin-ad-users-permission.service';
import { AdminEmailUsersPermissionService } from 'src/app/model/admin-user-management/admin-email-users/services/admin-email-users-permission.service';
import { AdminUserGroupsPermissionService } from 'src/app/model/admin-user-management/admin-user-groups/services/admin-user-groups-permission.service';
import { emptyPermissionsCategories } from 'src/app/model/admin-user-management/permissions/constants/permissions-category.constants';
import { IPermissions } from 'src/app/model/admin-user-management/permissions/dtos/i-permissions';
import {
  fromPermissionsCategories, IPermissionsCategory, updatePermissionsCategories
} from 'src/app/model/admin-user-management/permissions/dtos/i-permissions-category';
import { UserType } from 'src/app/model/admin-user-management/user-type';

@Component({
  selector: 'app-permissions',
  templateUrl: './permissions.component.html',
  styleUrls: ['./permissions.component.scss']
})
export class PermissionsComponent implements OnInit {

  @Input() userType: UserType;
  @Input() id: string;
  @Input('permissions') set _permissions(value: IPermissions) {
    this.valueBackup = value;
    if (this.permissions) {
      updatePermissionsCategories(this.permissions, value);
    }
  }
  valueBackup: IPermissions;

  @Output() permissionsUpdated = new EventEmitter<void>();

  public isUpdating = false;

  public permissions: IPermissionsCategory[];

  public permissionStates = [
    {
      id: 0,
      name: 'Not set'
    },
    {
      id: 1,
      name: 'Allow'
    },
    {
      id: 2,
      name: 'Deny'
    }
  ];

  constructor(
    private adminEmailUsersPermissionService: AdminEmailUsersPermissionService,
    private adminUserGroupsPermissionService: AdminUserGroupsPermissionService,
    private adminAdUsersPermissionService: AdminAdUsersPermissionService,
    private adminAdGroupsPermissionService: AdminAdGroupsPermissionService) { }

  async ngOnInit(): Promise<void> {
    this.permissions = emptyPermissionsCategories();
    if (this.valueBackup) {
      updatePermissionsCategories(this.permissions, this.valueBackup);
    }
  }

  // ---------------------- Update ----------------------

  public async onPermissionsDropdownValueChanged(): Promise<void> {
    this.isUpdating = true;
    try {
      if (this.userType === UserType.AdminEmailUser) {
        await this.adminEmailUsersPermissionService.updateAdminEmailUserPermissions(this.id, fromPermissionsCategories(this.permissions));
      } else if (this.userType === UserType.AdminUserGroup) {
        await this.adminUserGroupsPermissionService.updateAdminUserGroupPermissions(this.id, fromPermissionsCategories(this.permissions));
      } else if (this.userType === UserType.AdminAdUser) {
        await this.adminAdUsersPermissionService.updateAdminAdUserPermissions(this.id, fromPermissionsCategories(this.permissions));
      } else if (this.userType === UserType.AdminAdGroup) {
        await this.adminAdGroupsPermissionService.updateAdminAdGroupPermissions(this.id, fromPermissionsCategories(this.permissions));
      }
    } finally {
      this.permissionsUpdated.emit();
      this.isUpdating = false;
    }
  }

}
