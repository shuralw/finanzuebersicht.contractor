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
import { CategoriesModule } from 'src/app/model/accounting/categories/categories.module';
import { CategorySearchTermsModule } from 'src/app/model/accounting/category-search-terms/category-search-terms.module';
import { CategorySearchTermsPage } from './category-search-terms.page';
import { CategorySearchTermsPagesRouting } from './category-search-terms-pages.routing';
import { CategorySearchTermCreateDialog } from './dialogs/create/category-search-term-create.dialog';
import { CategorySearchTermUpdateDialog } from './dialogs/update/category-search-term-update.dialog';
import { CategorySearchTermDetailPage } from './sub-pages/detail/category-search-term-detail.page';

@NgModule({
  declarations: [
    CategorySearchTermsPage,
    CategorySearchTermCreateDialog,
    CategorySearchTermDetailPage,
    CategorySearchTermUpdateDialog,
  ],
  imports: [
    // Routing Modules
    CategorySearchTermsPagesRouting,

    // Model Modules
    CategorySearchTermsModule,
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
export class CategorySearchTermsPagesModule { }
