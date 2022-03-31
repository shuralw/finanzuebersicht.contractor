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
import { AccountingEntriesModule } from 'src/app/model/accounting/accounting-entries/accounting-entries.module';
import { CategoriesModule } from 'src/app/model/accounting/categories/categories.module';
import { AccountingEntriesPage } from './accounting-entries.page';
import { AccountingEntriesPagesRouting } from './accounting-entries-pages.routing';
import { AccountingEntryCreateDialog } from './dialogs/create/accounting-entry-create.dialog';
import { AccountingEntryUpdateDialog } from './dialogs/update/accounting-entry-update.dialog';
import { AccountingEntryDetailPage } from './sub-pages/detail/accounting-entry-detail.page';

@NgModule({
  declarations: [
    AccountingEntriesPage,
    AccountingEntryCreateDialog,
    AccountingEntryDetailPage,
    AccountingEntryUpdateDialog,
  ],
  imports: [
    // Routing Modules
    AccountingEntriesPagesRouting,

    // Model Modules
    AccountingEntriesModule,
    CategoriesModule,

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
export class AccountingEntriesPagesModule { }
