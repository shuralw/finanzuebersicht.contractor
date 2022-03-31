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
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { UiComponentsModule } from 'src/app/components/ui/ui-components.module';
import { TableFilterBarModule, SearchDropdownModule } from '@krz/material';
import { AdminUserManagementComponentsModule } from 'src/app/components/admin-user-management/admin-user-management-components.module';
import { AdminEmailUsersModule } from 'src/app/model/admin-user-management/admin-email-users/admin-email-users.module';
import { AdminUserGroupsModule } from 'src/app/model/admin-user-management/admin-user-groups/admin-user-groups.module';
import { AdminUserManagementPipesModule } from 'src/app/pipes/admin-user-management/admin-user-management-pipes.module';
import { AdminEmailUsersPage } from './admin-email-users.page';
import { AdminEmailUsersPagesRouting } from './admin-email-users.routing';
import { AdminEmailUserCreateAndUpdateComponent } from './dialogs/admin-email-user-create-and-update/admin-email-user-create-and-update.component';
import { AdminEmailUserDetailPage } from './admin-email-user-detail/admin-email-user-detail.page';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    AdminEmailUserCreateAndUpdateComponent,
    AdminEmailUserDetailPage,
    AdminEmailUsersPage,
  ],
  imports: [
    // Routing Modules
    AdminEmailUsersPagesRouting,

    // Component Modules
    UiComponentsModule,
    AdminUserManagementComponentsModule,

    // Model Modules
    AdminUserGroupsModule,
    AdminEmailUsersModule,
    TableFilterBarModule,
    SearchDropdownModule,

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
export class AdminEmailUsersPagesModule { }
