import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { validateDn } from 'src/app/helpers/validation.helper';
import { AdminAdUsersCrudService } from 'src/app/model/admin-user-management/admin-ad-users/admin-ad-users-crud.service';
import { IAdminAdUser } from 'src/app/model/admin-user-management/admin-ad-users/dtos/i-admin-ad-user';
import { PaginationDataSource } from '@krz/material';
import { toRGB } from '../../../helpers/color.helper';
import { AdminAdUserCreateAndUpdateComponent } from './dialogs/admin-ad-user-create-and-update/admin-ad-user-create-and-update.component';

@Component({
  selector: 'app-admin-ad-users',
  templateUrl: './admin-ad-users.page.html',
  styleUrls: ['./admin-ad-users.page.scss']
})
export class AdminAdUsersPage implements AfterViewInit {

  public toRGB = toRGB;
  public validateDn = validateDn;

  // FilterBar
  filterTerm = '';

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public adminAdUsersDataSource: PaginationDataSource<IAdminAdUser>;
  public adminAdUsersGridColumns: string[] = [
    'dn',
    'detail',
  ];

  constructor(
    private adminAdUsersCrudService: AdminAdUsersCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog) {

    this.adminAdUsersDataSource = new PaginationDataSource<IAdminAdUser>(
      (options) => this.adminAdUsersCrudService.getPagedAdminAdUsers(options),
      () => [
        {
          filterField: 'dn',
          containsFilters: [this.filterTerm]
        },
      ]);
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.adminAdUsersDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  stopPropagation(event: any): void {
    event.stopPropagation();
  }

  // --------------------- Actions ---------------------

  public async createAdminAdUser(): Promise<void> {
    const dialogRef = this.dialog.open(AdminAdUserCreateAndUpdateComponent);
    const adminAdUserDn = await dialogRef.afterClosed().toPromise();
    if (adminAdUserDn && adminAdUserDn.length > 2 && adminAdUserDn.length <= 256) {
      await this.adminAdUsersCrudService.createAdminAdUser({
        dn: adminAdUserDn
      });
      await this.adminAdUsersDataSource.triggerUpdate();
    }
  }

  public async updateAdminAdUser(adminAdUser: IAdminAdUser): Promise<void> {
    const dialogRef = this.dialog.open(AdminAdUserCreateAndUpdateComponent, { data: { dn: adminAdUser.dn } });
    const adminAdUserDn = await dialogRef.afterClosed().toPromise();
    if (adminAdUserDn && validateDn(adminAdUserDn) && adminAdUserDn.length <= 256 && adminAdUserDn !== adminAdUser.dn) {
      await this.adminAdUsersCrudService.updateAdminAdUser({
        id: adminAdUser.id,
        dn: adminAdUserDn
      });
      await this.adminAdUsersDataSource.triggerUpdate();
    }
  }

  public async deleteAdminAdUser(adminAdUserId: string): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminAdUsersCrudService.deleteAdminAdUser(adminAdUserId);
      await this.adminAdUsersDataSource.triggerUpdate();
    }
  }

}
