import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { validateEmail } from 'src/app/helpers/validation.helper';
import { IAdminEmailUser } from 'src/app/model/admin-user-management/admin-email-users/dtos/i-admin-email-user';
import { AdminEmailUsersCrudService } from 'src/app/model/admin-user-management/admin-email-users/admin-email-users-crud.service';
import { PaginationDataSource } from '@krz/material';
import { toRGB } from '../../../helpers/color.helper';
import { AdminEmailUserCreateAndUpdateComponent } from './dialogs/admin-email-user-create-and-update/admin-email-user-create-and-update.component';

@Component({
  selector: 'app-admin-email-users',
  templateUrl: './admin-email-users.page.html',
  styleUrls: ['./admin-email-users.page.scss']
})
export class AdminEmailUsersPage implements AfterViewInit {

  public toRGB = toRGB;
  public validateEmail = validateEmail;

  // FilterBar
  filterTerm = '';

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public adminEmailUsersDataSource: PaginationDataSource<IAdminEmailUser>;
  public adminEmailUsersGridColumns: string[] = [
    'email',
    'detail',
  ];

  constructor(
    private adminEmailUsersCrudService: AdminEmailUsersCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog) {

    this.adminEmailUsersDataSource = new PaginationDataSource<IAdminEmailUser>(
      (options) => this.adminEmailUsersCrudService.getPagedAdminEmailUsers(options),
      () => [
        {
          filterField: 'email',
          containsFilters: [this.filterTerm]
        },
      ]);
  }

  async ngAfterViewInit(): Promise<void> {
    setTimeout(() => {
      this.adminEmailUsersDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  stopPropagation(event: any): void {
    event.stopPropagation();
  }

  // --------------------- Actions ---------------------

  public async createAdminEmailUser(): Promise<void> {
    const dialogRef = this.dialog.open(AdminEmailUserCreateAndUpdateComponent);
    const adminEmailUserEmail = await dialogRef.afterClosed().toPromise();
    if (adminEmailUserEmail && adminEmailUserEmail.length > 2 && adminEmailUserEmail.length <= 256) {
      await this.adminEmailUsersCrudService.createAdminEmailUser({
        email: adminEmailUserEmail
      });
      await this.adminEmailUsersDataSource.triggerUpdate();
    }
  }

  public async updateAdminEmailUser(adminEmailUser: IAdminEmailUser): Promise<void> {
    const dialogRef = this.dialog.open(AdminEmailUserCreateAndUpdateComponent, { data: { email: adminEmailUser.email } });
    const adminEmailUserEmail = await dialogRef.afterClosed().toPromise();
    if (adminEmailUserEmail && validateEmail(adminEmailUserEmail) &&
      adminEmailUserEmail.length <= 256 &&
      adminEmailUserEmail !== adminEmailUser.email) {

      await this.adminEmailUsersCrudService.updateAdminEmailUser({
        id: adminEmailUser.id,
        email: adminEmailUserEmail
      });
      await this.adminEmailUsersDataSource.triggerUpdate();
    }
  }

  public async deleteAdminEmailUser(adminEmailUserId: string): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminEmailUsersCrudService.deleteAdminEmailUser(adminEmailUserId);
      await this.adminEmailUsersDataSource.triggerUpdate();
    }
  }

}
