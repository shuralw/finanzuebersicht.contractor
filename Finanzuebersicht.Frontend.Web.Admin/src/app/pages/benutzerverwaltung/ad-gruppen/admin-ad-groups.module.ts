import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { UiComponentsModule } from 'src/app/components/ui/ui-components.module';
import { TableFilterBarModule, SearchDropdownModule } from '@krz/material';
import { AdminUserManagementComponentsModule } from 'src/app/components/admin-user-management/admin-user-management-components.module';
import { AdminAdGroupsModule } from 'src/app/model/admin-user-management/admin-ad-groups/admin-ad-groups.module';
import { AdminUserGroupsModule } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups.module';
import { AdminUserManagementPipesModule } from 'src/app/pipes/admin-user-management/admin-user-management-pipes.module';
import { AdminAdGroupsPage } from './admin-ad-groups.page';
import { AdminAdGroupsPagesRouting } from './admin-ad-groups.routing';
import {
  AdminAdGroupCreateAndUpdateComponent
} from './dialogs/admin-ad-group-create-and-update/admin-ad-group-create-and-update.component';
import { AdminAdGroupDetailPage } from './admin-ad-group-detail/admin-ad-group-detail.page';

@NgModule({
  declarations: [
    AdminAdGroupCreateAndUpdateComponent,
    AdminAdGroupDetailPage,
    AdminAdGroupsPage,
  ],
  imports: [
    // Routing Modules
    AdminAdGroupsPagesRouting,

    // Component Modules
    UiComponentsModule,
    AdminUserManagementComponentsModule,
    TableFilterBarModule,
    SearchDropdownModule,

    // Model Modules
    AdminUserGroupsModule,
    AdminAdGroupsModule,

    // Angular Material Modules
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,

    // Pipe Module
    AdminUserManagementPipesModule,

    // Misc Modules
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
  ]
})
export class AdminAdGroupsPagesModule { }
