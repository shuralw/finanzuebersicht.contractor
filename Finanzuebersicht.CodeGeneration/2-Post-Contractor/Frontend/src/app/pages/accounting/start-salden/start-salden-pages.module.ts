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
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { SearchDropdownModule, TableFilterBarModule } from '@krz/material';
import { UiComponentsModule } from 'src/app/components/ui/ui-components.module';
import { StartSaldenModule } from 'src/app/model/accounting/start-salden/start-salden.module';
import { StartSaldoCreateDialog } from './dialogs/create/start-saldo-create.dialog';
import { StartSaldoUpdateDialog } from './dialogs/update/start-saldo-update.dialog';
import { StartSaldenPage } from './start-salden.page';
import { StartSaldenPagesRouting } from './start-salden-pages.routing';
import { StartSaldoDetailPage } from './sub-pages/detail/start-saldo-detail.page';

@NgModule({
  declarations: [
    StartSaldenPage,
    StartSaldoCreateDialog,
    StartSaldoDetailPage,
    StartSaldoUpdateDialog,
  ],
  imports: [
    // Routing Modules
    StartSaldenPagesRouting,

    // Model Modules
    StartSaldenModule,

    // UI Components
    UiComponentsModule,
    SearchDropdownModule,
    TableFilterBarModule,

    // Angular Material Modules
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatDialogModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,

    // Misc Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class StartSaldenPagesModule { }
