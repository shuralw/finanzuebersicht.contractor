import { AfterViewInit, Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { AdminAdGroupsMembershipService } from 'src/app/model/admin-user-management/admin-ad-groups/services/admin-ad-groups-membership.service';
import { AdminAdUsersMembershipService } from 'src/app/model/admin-user-management/admin-ad-users/services/admin-ad-users-membership.service';
import { AdminEmailUsersMembershipService } from 'src/app/model/admin-user-management/admin-email-users/services/admin-email-users-membership.service';
import { IAdminUserGroup } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group';
import { AdminUserGroupsMembershipService } from 'src/app/model/admin-user-management/admin-user-groups/services/admin-user-groups-membership.service';
import { UserType } from 'src/app/model/admin-user-management/user-type';
import { toRGB } from '../../../helpers/color.helper';
import { ConfirmationDialogService } from '../../ui/confirmation-dialog/confirmation-dialog.service';
import { MemberOfDialogComponent } from './dialogs/member-of-dialog/member-of-dialog.component';

@Component({
  selector: 'app-member-of',
  templateUrl: './member-of.component.html',
  styleUrls: ['./member-of.component.scss']
})
export class MemberOfComponent implements AfterViewInit {

  // Filter Bar
  filterTerm = '';

  public adminUserGroupsTableDataSource = new MatTableDataSource<IAdminUserGroup>([]);
  public adminUserGroupsGridColumns: string[] = [
    'name',
    'detail',
  ];

  @ViewChild(MatSort) sort: MatSort;

  public myAdminUserGroups: IAdminUserGroup[];
  @Input('myAdminUserGroups') set _myAdminUserGroups(myAdminUserGroups: IAdminUserGroup[]) {
    this.myAdminUserGroups = myAdminUserGroups;
    this.updateDataSource();
  }

  @Input() myId: string;
  @Input() userType: UserType;

  public toRGB = toRGB;
  @Output() memberUpdate = new EventEmitter<void>();

  constructor(
    private adminEmailUsersMembershipService: AdminEmailUsersMembershipService,
    private adminUserGroupsMembershipService: AdminUserGroupsMembershipService,
    private adminAdUsersMembershipService: AdminAdUsersMembershipService,
    private adminAdGroupsMembershipService: AdminAdGroupsMembershipService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private router: Router) { }

  ngAfterViewInit(): void {
    if (this.sort) {
      this.adminUserGroupsTableDataSource.sort = this.sort;
    }
  }

  onFilterTermChange(filterTerm: string): void {
    this.filterTerm = filterTerm;
    this.updateDataSource();
  }

  updateDataSource(): void {
    this.adminUserGroupsTableDataSource.data = this.myAdminUserGroups.slice()
      .filter(member => member.name.toString().toLowerCase().includes(this.filterTerm.trim().toLowerCase()));
  }

  // ---------------------- Add ----------------------

  public async addMemberOf(): Promise<void> {
    const dialog = this.dialog.open(MemberOfDialogComponent, {
      data: {
        adminUserGroupsToExclude: this.myAdminUserGroups
      }
    });
    const adminUserGroupToAdd = await dialog.afterClosed().toPromise();

    if (adminUserGroupToAdd) {
      if (this.userType === UserType.AdminEmailUser) {
        await this.adminEmailUsersMembershipService.addAdminEmailUserToAdminUserGroup(this.myId, adminUserGroupToAdd);
      } else if (this.userType === UserType.AdminUserGroup) {
        try {
          await this.adminUserGroupsMembershipService.addAdminUserGroupToAdminUserGroup(this.myId, adminUserGroupToAdd);
        } catch (e) {
          this.snackBar.open('Zirkuläre Gruppenmitgliedschaften sind nicht möglich.', null, { duration: 4000, panelClass: 'red-snackbar' });
          return;
        }
      } else if (this.userType === UserType.AdminAdUser) {
        await this.adminAdUsersMembershipService.addAdminAdUserToAdminUserGroup(this.myId, adminUserGroupToAdd);
      } else if (this.userType === UserType.AdminAdGroup) {
        await this.adminAdGroupsMembershipService.addAdminAdGroupToAdminUserGroup(this.myId, adminUserGroupToAdd);
      }

      this.memberUpdate.emit();
    }
  }

  // ---------------------- Remove ----------------------

  public async removeFromAdminUserGroup(event: Event, adminUserGroup: IAdminUserGroup): Promise<void> {
    event.stopPropagation();
    if (await this.confirmationDialogService.askForConfirmation()) {
      if (this.userType === UserType.AdminEmailUser) {
        await this.adminEmailUsersMembershipService.removeAdminEmailUserFromAdminUserGroup(this.myId, adminUserGroup.id);
      } else if (this.userType === UserType.AdminUserGroup) {
        await this.adminUserGroupsMembershipService.removeAdminUserGroupFromAdminUserGroup(this.myId, adminUserGroup.id);
      } else if (this.userType === UserType.AdminAdUser) {
        await this.adminAdUsersMembershipService.removeAdminAdUserFromAdminUserGroup(this.myId, adminUserGroup.id);
      } else if (this.userType === UserType.AdminAdGroup) {
        await this.adminAdGroupsMembershipService.removeAdminAdGroupFromAdminUserGroup(this.myId, adminUserGroup.id);
      }
      this.memberUpdate.emit();
    }
  }

  // ---------------------- Navigation ----------------------

  public async openAdminUserGroup(id: string): Promise<void> {
    await this.router.navigate(['/benutzerverwaltung/gruppen/detail/' + id]);
  }


}
