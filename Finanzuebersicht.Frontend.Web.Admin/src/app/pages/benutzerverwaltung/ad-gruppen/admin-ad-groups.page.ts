import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { validateDn } from 'src/app/helpers/validation.helper';
import { AdminAdGroupsCrudService } from 'src/app/model/admin-user-management/admin-ad-groups/admin-ad-groups-crud.service';
import { IAdminAdGroup } from 'src/app/model/admin-user-management/admin-ad-groups/dtos/i-admin-ad-group';
import { PaginationDataSource } from '@krz/material';
import { toRGB } from '../../../helpers/color.helper';
import {
  AdminAdGroupCreateAndUpdateComponent
} from './dialogs/admin-ad-group-create-and-update/admin-ad-group-create-and-update.component';

@Component({
  selector: 'app-admin-ad-groups',
  templateUrl: './admin-ad-groups.page.html',
  styleUrls: ['./admin-ad-groups.page.scss']
})
export class AdminAdGroupsPage implements AfterViewInit {

  public toRGB = toRGB;
  public validateDn = validateDn;

  // FilterBar
  filterTerm = '';

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public adminAdGroupsDataSource: PaginationDataSource<IAdminAdGroup>;
  public adminAdGroupsGridColumns: string[] = [
    'dn',
    'detail',
  ];


  constructor(
    private adminAdGroupsCrudService: AdminAdGroupsCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog) {

    this.adminAdGroupsDataSource = new PaginationDataSource<IAdminAdGroup>(
      (options) => this.adminAdGroupsCrudService.getPagedAdminAdGroups(options),
      () => [
        {
          filterField: 'dn',
          containsFilters: [this.filterTerm]
        },
      ]);
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.adminAdGroupsDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  stopPropagation(event: any): void {
    event.stopPropagation();
  }

  // --------------------- Actions ---------------------

  public async createAdminAdGroup(): Promise<void> {
    const dialogRef = this.dialog.open(AdminAdGroupCreateAndUpdateComponent);
    const adminAdGroupDn = await dialogRef.afterClosed().toPromise();
    if (adminAdGroupDn && adminAdGroupDn.length > 2 && adminAdGroupDn.length <= 256) {
      await this.adminAdGroupsCrudService.createAdminAdGroup({
        dn: adminAdGroupDn
      });
      await this.adminAdGroupsDataSource.triggerUpdate();
    }
  }

  public async updateAdminAdGroup(adminAdGroup: IAdminAdGroup): Promise<void> {
    const dialogRef = this.dialog.open(AdminAdGroupCreateAndUpdateComponent, { data: { dn: adminAdGroup.dn } });
    const adminAdGroupDn = await dialogRef.afterClosed().toPromise();
    if (adminAdGroupDn && validateDn(adminAdGroupDn) && adminAdGroupDn.length <= 256 && adminAdGroupDn !== adminAdGroup.dn) {
      await this.adminAdGroupsCrudService.updateAdminAdGroup({
        id: adminAdGroup.id,
        dn: adminAdGroupDn
      });
      await this.adminAdGroupsDataSource.triggerUpdate();
    }
  }

  public async deleteAdminAdGroup(adminAdGroupId: string): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminAdGroupsCrudService.deleteAdminAdGroup(adminAdGroupId);
      await this.adminAdGroupsDataSource.triggerUpdate();
    }
  }

}
