import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { IAdminAdGroup } from 'src/app/model/admin-user-management/admin-ad-groups/dtos/i-admin-ad-group';
import { AdminAdGroupsMembershipService } from 'src/app/model/admin-user-management/admin-ad-groups/services/admin-ad-groups-membership.service';
import { IAdminAdUser } from 'src/app/model/admin-user-management/admin-ad-users/dtos/i-admin-ad-user';
import { AdminAdUsersMembershipService } from 'src/app/model/admin-user-management/admin-ad-users/services/admin-ad-users-membership.service';
import { IAdminEmailUser } from 'src/app/model/admin-user-management/admin-email-users/dtos/i-admin-email-user';
import { AdminEmailUsersMembershipService } from 'src/app/model/admin-user-management/admin-email-users/services/admin-email-users-membership.service';
import { IMember } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-member';
import { IAdminUserGroup } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group';
import { IAdminUserGroupDetail } from 'src/app/model/admin-user-management/admin-user-groups/dtos/i-admin-user-group-detail';
import { AdminUserGroupsMembershipService } from 'src/app/model/admin-user-management/admin-user-groups/services/admin-user-groups-membership.service';
import { UserType } from 'src/app/model/admin-user-management/user-type';
import { toRGB } from '../../../helpers/color.helper';
import { ConfirmationDialogService } from '../../ui/confirmation-dialog/confirmation-dialog.service';
import { MembersDialogComponent } from './dialogs/members-dialog/members-dialog.component';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss']
})
export class MembersComponent {

  public membersTableDataSource = new MatTableDataSource<IMember>([]);
  public membersGridColumns: string[] = [
    'name',
    'type',
    'detail',
  ];

  @ViewChild(MatSort) sort: MatSort;

  private contextAdminUserGroup: IAdminUserGroupDetail;
  @Input('contextAdminUserGroup') set _contextAdminUserGroup(contextAdminUserGroup: IAdminUserGroupDetail) {
    this.contextAdminUserGroup = contextAdminUserGroup;
    this.initPossibleMembers();
  }

  adminEmailUserMembers: IAdminEmailUser[];
  adminUserGroupMembers: IAdminUserGroup[];
  adminAdUserMembers: IAdminAdUser[];
  adminAdGroupMembers: IAdminAdGroup[];
  @Input('adminEmailUserMembers') set _adminEmailUserMembers(adminEmailUserMembers: IAdminEmailUser[]) {
    this.adminEmailUserMembers = adminEmailUserMembers;
    this.initPossibleMembers();
  }
  @Input('adminUserGroupMembers') set _adminUserGroupMembers(adminUserGroupMembers: IAdminUserGroup[]) {
    this.adminUserGroupMembers = adminUserGroupMembers;
    this.initPossibleMembers();
  }
  @Input('adminAdUserMembers') set _adminAdUserMembers(adminAdUserMembers: IAdminAdUser[]) {
    this.adminAdUserMembers = adminAdUserMembers;
    this.initPossibleMembers();
  }
  @Input('adminAdGroupMembers') set _adminAdGroupMembers(adminAdGroupMembers: IAdminAdGroup[]) {
    this.adminAdGroupMembers = adminAdGroupMembers;
    this.initPossibleMembers();
  }

  public toRGB = toRGB;

  @Output() update: EventEmitter<any> = new EventEmitter<any>();

  public elementTypes = ['E-Mail Benutzer', 'Gruppe', 'AD-Benutzer', 'AD-Gruppe'];

  constructor(
    private adminEmailUsersMembershipService: AdminEmailUsersMembershipService,
    private adminUserGroupsMembershipService: AdminUserGroupsMembershipService,
    private adminAdUsersMembershipService: AdminAdUsersMembershipService,
    private adminAdGroupsMembershipService: AdminAdGroupsMembershipService,
    private confirmationDialogService: ConfirmationDialogService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private router: Router) { }

  // ------------------------- Init -------------------------

  public initPossibleMembers(): void {
    if (this.adminEmailUserMembers && this.adminUserGroupMembers && this.adminAdUserMembers && this.adminAdGroupMembers) {
      this.membersTableDataSource.data = []
        .concat(this.adminEmailUserMembers.map(adminEmailUser => {
          return { id: adminEmailUser.id, name: adminEmailUser.email, userType: UserType.AdminEmailUser };
        }))
        .concat(this.adminUserGroupMembers.map(adminUserGroup => {
          return { id: adminUserGroup.id, name: adminUserGroup.name, userType: UserType.AdminUserGroup };
        }))
        .concat(this.adminAdUserMembers.map(adminAdUser => {
          return { id: adminAdUser.id, name: adminAdUser.dn, userType: UserType.AdminAdUser };
        }))
        .concat(this.adminAdGroupMembers.map(adminAdGroup => {
          return { id: adminAdGroup.id, name: adminAdGroup.dn, userType: UserType.AdminAdGroup };
        }));
    }
  }

  public async addMember(): Promise<void> {
    const dialog = this.dialog.open(MembersDialogComponent, {
      data: {
        adminEmailUsersToExclude: this.adminEmailUserMembers,
        adminUserGroupsToExclude: this.adminUserGroupMembers,
        adminAdUsersToExclude: this.adminAdUserMembers,
        adminAdGroupsToExclude: this.adminAdGroupMembers,
      }
    });
    const memberToAdd: IMember = await dialog.afterClosed().toPromise();

    try {
      switch (memberToAdd.userType) {
        case UserType.AdminEmailUser:
          await this.adminEmailUsersMembershipService.addAdminEmailUserToAdminUserGroup(memberToAdd.id, this.contextAdminUserGroup.id);
          break;
        case UserType.AdminUserGroup:
          await this.adminUserGroupsMembershipService.addAdminUserGroupToAdminUserGroup(memberToAdd.id, this.contextAdminUserGroup.id);
          break;
        case UserType.AdminAdUser:
          await this.adminAdUsersMembershipService.addAdminAdUserToAdminUserGroup(memberToAdd.id, this.contextAdminUserGroup.id);
          break;
        case UserType.AdminAdGroup:
          await this.adminAdGroupsMembershipService.addAdminAdGroupToAdminUserGroup(memberToAdd.id, this.contextAdminUserGroup.id);
          break;
      }
      this.update.emit();
    } catch (e) {
      if (e.status === 409) {
        this.snackBar.open('Zirkuläre Gruppenmitgliedschaften sind nicht möglich.', null, { duration: 4000, panelClass: 'red-snackbar' });
      }
    }

  }

  public async removeMember(member: IMember, event: InputEvent): Promise<void> {
    event.stopPropagation();
    if (await this.confirmationDialogService.askForConfirmation()) {
      switch (member.userType) {
        case UserType.AdminEmailUser:
          await this.adminEmailUsersMembershipService.removeAdminEmailUserFromAdminUserGroup(member.id, this.contextAdminUserGroup.id);
          break;
        case UserType.AdminUserGroup:
          await this.adminUserGroupsMembershipService.removeAdminUserGroupFromAdminUserGroup(member.id, this.contextAdminUserGroup.id);
          break;
        case UserType.AdminAdUser:
          await this.adminAdUsersMembershipService.removeAdminAdUserFromAdminUserGroup(member.id, this.contextAdminUserGroup.id);
          break;
        case UserType.AdminAdGroup:
          await this.adminAdGroupsMembershipService.removeAdminAdGroupFromAdminUserGroup(member.id, this.contextAdminUserGroup.id);
          break;
      }
    }
    this.update.emit();
  }

  // ---------------------- Navigation ----------------------

  public async openElement(userType: UserType, id: string): Promise<void> {
    switch (userType) {
      case UserType.AdminEmailUser:
        await this.router.navigate(['/benutzerverwaltung/benutzer/detail/' + id]);
        break;
      case UserType.AdminUserGroup:
        await this.router.navigate(['/benutzerverwaltung/gruppen/detail/' + id]);
        break;
      case UserType.AdminAdUser:
        await this.router.navigate(['/benutzerverwaltung/ad-benutzer/detail/' + id]);
        break;
      case UserType.AdminAdGroup:
        await this.router.navigate(['/benutzerverwaltung/ad-gruppen/detail/' + id]);
        break;
    }
  }

  // --------------------- Misc ---------------------
  public areMembersEmpty(): boolean {
    return this.adminEmailUserMembers &&
      this.adminUserGroupMembers &&
      this.adminAdUserMembers &&
      this.adminAdGroupMembers &&
      this.adminEmailUserMembers.length + this.adminUserGroupMembers.length +
      this.adminAdUserMembers.length + this.adminAdGroupMembers.length === 0;
  }

}
