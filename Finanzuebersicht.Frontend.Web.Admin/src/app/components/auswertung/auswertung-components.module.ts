import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { TableFilterBarModule, SearchDropdownModule } from '@krz/material';
import { AdminAdGroupsModule } from 'src/app/model/admin-user-management/admin-ad-groups/admin-ad-groups.module';
import { AdminAdUsersModule } from 'src/app/model/admin-user-management/admin-ad-users/admin-ad-users.module';
import { AdminEmailUsersModule } from 'src/app/model/admin-user-management/admin-email-users/admin-email-users.module';
import { AdminUserGroupsModule } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups.module';
import { UiComponentsModule } from '../ui/ui-components.module';
import { DxButtonModule, DxTextBoxModule, DxFormModule, DxLoadPanelModule, DxTabPanelModule, DxDataGridModule } from 'devextreme-angular';
import { DxSwitchModule, DxPopupModule, DxLoadIndicatorModule, DxDropDownBoxModule, DxColorBoxModule } from 'devextreme-angular';
import { DxChartModule, DxTreeViewModule, DxContextMenuModule, DxProgressBarModule, DxPieChartModule } from 'devextreme-angular';
import { DxListModule } from 'devextreme-angular';
import { AuswertungPieChartComponent } from './auswertung-pie-chart/auswertung-pie-chart.component';
import { FilePickerComponent } from './file-picker/file-picker.component';

@NgModule({
  declarations: [
    AuswertungPieChartComponent,
    FilePickerComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    UiComponentsModule,
    TableFilterBarModule,
    SearchDropdownModule,
    AdminAdGroupsModule,
    AdminAdUsersModule,
    AdminEmailUsersModule,
    AdminUserGroupsModule,
    MatButtonModule,
    MatDialogModule,
    MatIconModule,
    MatInputModule,
    MatMenuModule,
    MatSelectModule,
    MatSnackBarModule,
    MatTableModule,
    DxFormModule,
    DxButtonModule,
    DxTextBoxModule,
    DxTabPanelModule,
    DxLoadPanelModule,
    DxDataGridModule,
    DxPopupModule,
    DxLoadIndicatorModule,
    DxColorBoxModule,
    DxDropDownBoxModule,
    DxListModule,
    DxTreeViewModule,
    DxContextMenuModule,
    DxProgressBarModule,
    DxPieChartModule,
    DxChartModule,
    DxSwitchModule
  ],
  exports: [
    AuswertungPieChartComponent,
    FilePickerComponent,
  ]
})
export class AuswertungComponentsModule { }
