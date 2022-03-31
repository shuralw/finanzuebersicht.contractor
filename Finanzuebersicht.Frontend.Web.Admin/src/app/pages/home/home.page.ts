import { Component, OnInit } from '@angular/core';
import { SessionInformationService } from 'src/app/model/admin-session-management/sessions/services/session-information.service';
import { emptyPermissionsCategories } from 'src/app/model/admin-user-management/permissions/constants/permissions-category.constants';
import { IPermissionsCategory, updatePermissionsCategories } from 'src/app/model/admin-user-management/permissions/dtos/i-permissions-category';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss']
})
export class HomePage implements OnInit {

  public permissionsCategories: IPermissionsCategory[];

  constructor(private sessionInformationService: SessionInformationService) { }

  public async ngOnInit(): Promise<void> {
    const sessionPermissions = await this.sessionInformationService.getPermissions();
    this.permissionsCategories = emptyPermissionsCategories();
    updatePermissionsCategories(this.permissionsCategories, sessionPermissions);
  }
}
