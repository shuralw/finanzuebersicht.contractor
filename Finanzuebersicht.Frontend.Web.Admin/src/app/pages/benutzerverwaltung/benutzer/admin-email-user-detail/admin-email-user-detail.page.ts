import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { validateEmail } from 'src/app/helpers/validation.helper';
import { IAdminEmailUserDetail } from 'src/app/model/admin-user-management/admin-email-users/dtos/i-admin-email-user-detail';
import { AdminEmailUsersCrudService } from 'src/app/model/admin-user-management/admin-email-users/admin-email-users-crud.service';
import { UserType } from 'src/app/model/admin-user-management/user-type';
import { AdminEmailUserCreateAndUpdateComponent } from '../dialogs/admin-email-user-create-and-update/admin-email-user-create-and-update.component';

@Component({
  selector: 'app-admin-email-user-detail',
  templateUrl: './admin-email-user-detail.page.html',
  styleUrls: ['./admin-email-user-detail.page.scss']
})
export class AdminEmailUserDetailPage implements OnInit {

  userType = UserType.AdminEmailUser;

  adminEmailUserId: string;
  adminEmailUser: IAdminEmailUserDetail;

  constructor(
    private adminEmailUsersCrudService: AdminEmailUsersCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
  }

  public async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe(async params => {
      this.adminEmailUserId = params.id;
      await this.loadAdminEmailUser();
    });
  }

  async onBackClicked(): Promise<void> {
    await this.router.navigate(['/benutzerverwaltung/benutzer']);
  }

  async onUpdateClicked(): Promise<void> {
    const dialogRef = this.dialog.open(AdminEmailUserCreateAndUpdateComponent, { data: { email: this.adminEmailUser.email } });
    const adminEmailUserEmail = await dialogRef.afterClosed().toPromise();
    if (adminEmailUserEmail && validateEmail(adminEmailUserEmail) && adminEmailUserEmail.length <= 256) {
      await this.adminEmailUsersCrudService.updateAdminEmailUser({
        id: this.adminEmailUser.id,
        email: adminEmailUserEmail
      });
      await this.loadAdminEmailUser();
    }
  }

  public async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminEmailUsersCrudService.deleteAdminEmailUser(this.adminEmailUserId);
      await this.router.navigate(['/benutzerverwaltung/benutzer']);
    }
  }

  async loadAdminEmailUser(): Promise<void> {
    this.adminEmailUser = await this.adminEmailUsersCrudService.getAdminEmailUser(this.adminEmailUserId);
  }

}
