import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { IAdminUserGroupDetail } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group-detail';
import { AdminUserGroupsCrudService } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups-crud.service';
import { UserType } from 'src/app/model/admin-user-management/user-type';
import { AdminUserGroupCreateAndUpdateComponent } from '../dialogs/admin-user-group-create-and-update/admin-user-group-create-and-update.component';

@Component({
  selector: 'app-admin-user-group-detail',
  templateUrl: './admin-user-group-detail.page.html',
  styleUrls: ['./admin-user-group-detail.page.scss']
})
export class AdminUserGroupDetailPage implements OnInit {

  userType = UserType.AdminUserGroup;

  adminUserGroupId: string;
  adminUserGroup: IAdminUserGroupDetail;

  constructor(
    private adminUserGroupsCrudService: AdminUserGroupsCrudService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
  }

  public async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe(async params => {
      this.adminUserGroupId = params.id;
      await this.loadAdminUserGroup();
    });
  }

  async onBackClicked(): Promise<void> {
    await this.router.navigate(['/benutzerverwaltung/gruppen']);
  }

  async onUpdateClicked(): Promise<void> {
    const dialogRef = this.dialog.open(AdminUserGroupCreateAndUpdateComponent, { data: { name: this.adminUserGroup.name } });
    const adminUserGroupName = await dialogRef.afterClosed().toPromise();
    if (adminUserGroupName && adminUserGroupName.length <= 256) {
      await this.adminUserGroupsCrudService.updateAdminUserGroup({
        id: this.adminUserGroup.id,
        name: adminUserGroupName
      });
      await this.loadAdminUserGroup();
    }
  }

  public async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation()) {
      await this.adminUserGroupsCrudService.deleteAdminUserGroup(this.adminUserGroupId);
      await this.router.navigate(['/benutzerverwaltung/gruppen']);
    }
  }

  async loadAdminUserGroup(): Promise<void> {
    this.adminUserGroup = await this.adminUserGroupsCrudService.getAdminUserGroup(this.adminUserGroupId);
  }

}
