import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { validateDn } from 'src/app/helpers/validation.helper';
import { AdminAdGroupsCrudService } from 'src/app/model/admin-user-management/admin-ad-groups/admin-ad-groups-crud.service';
import { IAdminAdGroupDetail } from 'src/app/model/admin-user-management/admin-ad-groups/dtos/i-admin-ad-group-detail';
import { IAdminUserGroup } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group';
import { UserType } from 'src/app/model/admin-user-management/user-type';
import { AdminAdGroupCreateAndUpdateComponent } from '../dialogs/admin-ad-group-create-and-update/admin-ad-group-create-and-update.component';

@Component({
  selector: 'app-admin-ad-group-detail',
  templateUrl: './admin-ad-group-detail.page.html',
  styleUrls: ['./admin-ad-group-detail.page.scss']
})
export class AdminAdGroupDetailPage implements OnInit {

  userType = UserType.AdminAdGroup;

  adminAdGroupId: string;
  adminAdGroup: IAdminAdGroupDetail;

  adminUserGroups: IAdminUserGroup[];

  constructor(
    private adminAdGroupsCrudService: AdminAdGroupsCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
  }

  public async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe(async params => {
      this.adminAdGroupId = params.id;
      await this.loadAdminAdGroup();
    });
  }

  async onBackClicked(): Promise<void> {
    await this.router.navigate(['/benutzerverwaltung/ad-gruppen']);
  }

  async onUpdateClicked(): Promise<void> {
    const dialogRef = this.dialog.open(AdminAdGroupCreateAndUpdateComponent, { data: { dn: this.adminAdGroup.dn } });
    const adminAdGroupDn = await dialogRef.afterClosed().toPromise();
    if (adminAdGroupDn && validateDn(adminAdGroupDn) && adminAdGroupDn.length <= 256) {
      await this.adminAdGroupsCrudService.updateAdminAdGroup({
        id: this.adminAdGroup.id,
        dn: adminAdGroupDn
      });
      await this.loadAdminAdGroup();
    }
  }

  public async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminAdGroupsCrudService.deleteAdminAdGroup(this.adminAdGroupId);
      await this.router.navigate(['/benutzerverwaltung/ad-gruppen']);
    }
  }

  async loadAdminAdGroup(): Promise<void> {
    this.adminAdGroup = await this.adminAdGroupsCrudService.getAdminAdGroup(this.adminAdGroupId);
  }

}
