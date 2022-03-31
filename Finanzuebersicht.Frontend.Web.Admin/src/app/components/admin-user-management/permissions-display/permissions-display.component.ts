import { Component, Input } from '@angular/core';
import { SessionInformationService } from 'src/app/model/admin-session-management/sessions/services/session-information.service';
import { emptyPermissionsCategories } from 'src/app/model/admin-user-management/permissions/constants/permissions-category.constants';
import { IPermissions } from 'src/app/model/admin-user-management/permissions/dtos/i-permissions';
import { IPermissionsCategory, updatePermissionsCategories } from 'src/app/model/admin-user-management/permissions/dtos/i-permissions-category';

@Component({
  selector: 'app-permissions-display',
  templateUrl: './permissions-display.component.html',
  styleUrls: ['./permissions-display.component.scss']
})
export class PermissionsDisplayComponent {

  public permissionsCategories: IPermissionsCategory[];
  @Input('permissions') set _permissions(value: IPermissions) {
    this.permissionsCategories = emptyPermissionsCategories();
    updatePermissionsCategories(this.permissionsCategories, value);
  }

  constructor(private sessionInformationService: SessionInformationService) { }

}
