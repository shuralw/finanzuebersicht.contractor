import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { validateDn } from 'src/app/helpers/validation.helper';
import { AdminAdUsersCrudService } from 'src/app/model/admin-user-management/admin-ad-users/admin-ad-users-crud.service';
import { IAdminAdUserDetail } from 'src/app/model/admin-user-management/admin-ad-users/dtos/i-admin-ad-user-detail';
import { IAdminUserGroup } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group';
import { UserType } from 'src/app/model/admin-user-management/user-type';
import { AdminAdUserCreateAndUpdateComponent } from '../dialogs/admin-ad-user-create-and-update/admin-ad-user-create-and-update.component';

@Component({
  selector: 'app-admin-ad-user-detail',
  templateUrl: './admin-ad-user-detail.page.html',
  styleUrls: ['./admin-ad-user-detail.page.scss']
})
export class AdminAdUserDetailPage implements OnInit {

  userType = UserType.AdminAdUser;

  adminAdUserId: string;
  adminAdUser: IAdminAdUserDetail;

  adminUserGroups: IAdminUserGroup[];

  constructor(
    private adminAdUsersCrudService: AdminAdUsersCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
  }

  public async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe(async params => {
      this.adminAdUserId = params.id;
      await this.loadAdminAdUser();
    });
  }

  async onBackClicked(): Promise<void> {
    await this.router.navigate(['/benutzerverwaltung/ad-benutzer']);
  }

  async onUpdateClicked(): Promise<void> {
    const dialogRef = this.dialog.open(AdminAdUserCreateAndUpdateComponent, { data: { dn: this.adminAdUser.dn } });
    const adminAdUserDn = await dialogRef.afterClosed().toPromise();
    if (adminAdUserDn && validateDn(adminAdUserDn) && adminAdUserDn.length <= 256) {
      await this.adminAdUsersCrudService.updateAdminAdUser({
        id: this.adminAdUser.id,
        dn: adminAdUserDn
      });
      await this.loadAdminAdUser();
    }
  }

  public async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminAdUsersCrudService.deleteAdminAdUser(this.adminAdUserId);
      await this.router.navigate(['/benutzerverwaltung/ad-benutzer']);
    }
  }

  async loadAdminAdUser(): Promise<void> {
    this.adminAdUser = await this.adminAdUsersCrudService.getAdminAdUser(this.adminAdUserId);
  }

}
