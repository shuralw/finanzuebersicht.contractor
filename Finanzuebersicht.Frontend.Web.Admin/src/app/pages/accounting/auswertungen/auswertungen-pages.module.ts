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
import { MatRadioModule } from '@angular/material/radio';
import { SearchDropdownModule, TableFilterBarModule } from '@krz/material';
import { UiComponentsModule } from 'src/app/components/ui/ui-components.module';
import { AccountingEntriesModule } from 'src/app/model/accounting/accounting-entries/accounting-entries.module';
import { CategoriesModule } from 'src/app/model/accounting/categories/categories.module';
import { AuswertungComponentsModule } from 'src/app/components/auswertung/auswertung-components.module';
import { DxButtonModule, DxTextBoxModule, DxFormModule, DxLoadPanelModule, DxTabPanelModule, DxDataGridModule } from 'devextreme-angular';
import { DxSwitchModule, DxPopupModule, DxLoadIndicatorModule, DxDropDownBoxModule, DxColorBoxModule } from 'devextreme-angular';
import { DxChartModule, DxTreeViewModule, DxContextMenuModule, DxProgressBarModule, DxPieChartModule } from 'devextreme-angular';
import { DxListModule } from 'devextreme-angular';
import { AuswertungenPagesRouting } from './auswertungen-pages.routing';
import { SaldenModule } from 'src/app/model/accounting/salden/salden.module';
import { PieChartPage } from './pie-chart/pie-chart.page';
import { LineChartPage } from './line-chart/line-chart.page';


@NgModule({
  declarations: [
    PieChartPage,
    LineChartPage,
  ],
  imports: [
    // Routing Modules
    AuswertungenPagesRouting,

    // Model Modules
    AccountingEntriesModule,
    SaldenModule,
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
    MatRadioModule,

    // Misc Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    // Devextreme Modules
    AuswertungComponentsModule,
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
    PieChartPage,
    LineChartPage,
  ]
})
export class AuswertungenPagesModule { }
