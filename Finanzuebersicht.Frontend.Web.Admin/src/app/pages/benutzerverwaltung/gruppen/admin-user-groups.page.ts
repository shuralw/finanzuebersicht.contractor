import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { validateEmail } from 'src/app/helpers/validation.helper';
import { IAdminUserGroup } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group';
import { AdminUserGroupsCrudService } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups-crud.service';
import { PaginationDataSource } from '@krz/material';
import { toRGB } from '../../../helpers/color.helper';
import { AdminUserGroupCreateAndUpdateComponent } from './dialogs/admin-user-group-create-and-update/admin-user-group-create-and-update.component';

@Component({
  selector: 'app-admin-user-groups',
  templateUrl: './admin-user-groups.page.html',
  styleUrls: ['./admin-user-groups.page.scss']
})
export class AdminUserGroupsPage implements AfterViewInit {

  public toRGB = toRGB;
  public validateEmail = validateEmail;

  // FilterBar
  filterTerm = '';

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public adminUserGroupsDataSource: PaginationDataSource<IAdminUserGroup>;
  public adminUserGroupsGridColumns: string[] = [
    'name',
    'detail',
  ];

  constructor(
    private adminUserGroupsCrudService: AdminUserGroupsCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog) {

    this.adminUserGroupsDataSource = new PaginationDataSource<IAdminUserGroup>(
      (options) => this.adminUserGroupsCrudService.getPagedAdminUserGroups(options),
      () => [
        {
          filterField: 'name',
          containsFilters: [this.filterTerm]
        },
      ]);
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.adminUserGroupsDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  stopPropagation(event: any): void {
    event.stopPropagation();
  }

  // --------------------- Actions ---------------------

  public async createAdminUserGroup(): Promise<void> {
    const dialogRef = this.dialog.open(AdminUserGroupCreateAndUpdateComponent);
    const adminUserGroupName = await dialogRef.afterClosed().toPromise();
    if (adminUserGroupName && adminUserGroupName.length > 2 && adminUserGroupName.length <= 256) {
      await this.adminUserGroupsCrudService.createAdminUserGroup({
        name: adminUserGroupName
      });
      await this.adminUserGroupsDataSource.triggerUpdate();
    }
  }

  public async updateAdminUserGroup(adminUserGroup: IAdminUserGroup): Promise<void> {
    const dialogRef = this.dialog.open(AdminUserGroupCreateAndUpdateComponent, { data: { name: adminUserGroup.name } });
    const adminUserGroupName = await dialogRef.afterClosed().toPromise();
    if (adminUserGroupName && adminUserGroupName.length <= 256 && adminUserGroupName !== adminUserGroup.name) {
      await this.adminUserGroupsCrudService.updateAdminUserGroup({
        id: adminUserGroup.id,
        name: adminUserGroupName
      });
      await this.adminUserGroupsDataSource.triggerUpdate();
    }
  }

  public async deleteAdminUserGroup(adminUserGroupId: string): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminUserGroupsCrudService.deleteAdminUserGroup(adminUserGroupId);
      await this.adminUserGroupsDataSource.triggerUpdate();
    }
  }

}
