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
import { AdminAdUsersModule } from 'src/app/model/admin-user-management/admin-ad-users/admin-ad-users.module';
import { AdminUserGroupsModule } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups.module';
import { AdminUserManagementPipesModule } from 'src/app/pipes/admin-user-management/admin-user-management-pipes.module';
import { AdminAdUsersPage } from './admin-ad-users.page';
import { AdminAdUsersPagesRouting } from './admin-ad-users.routing';
import { AdminAdUserCreateAndUpdateComponent } from './dialogs/admin-ad-user-create-and-update/admin-ad-user-create-and-update.component';
import { AdminAdUserDetailPage } from './admin-ad-user-detail/admin-ad-user-detail.page';

@NgModule({
  declarations: [
    AdminAdUserCreateAndUpdateComponent,
    AdminAdUserDetailPage,
    AdminAdUsersPage,
  ],
  imports: [
    // Routing Modules
    AdminAdUsersPagesRouting,

    // Component Modules
    UiComponentsModule,
    AdminUserManagementComponentsModule,
    TableFilterBarModule,
    SearchDropdownModule,

    // Model Modules
    AdminUserGroupsModule,
    AdminAdUsersModule,

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
export class AdminAdUsersPagesModule { }
