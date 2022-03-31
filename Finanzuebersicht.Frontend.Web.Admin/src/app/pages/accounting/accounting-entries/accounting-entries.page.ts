import { DatePipe } from '@angular/common';
import { Binary } from '@angular/compiler';
import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DropdownPaginationDataSource, PaginationDataSource } from '@krz/material';
import { CsvDictionary, CsvParser, CsvParserConfig, parseCsv } from 'src/app/helpers/csv-helper';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { IAccountingEntryCreate } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry-create';
import { IAccountingEntryListItem } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry-list-item';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ISaldoListItem } from 'src/app/model/accounting/salden/dtos/i-saldo-list-item';
import { SaldenCrudService } from 'src/app/model/accounting/salden/salden-crud.service';
import { AccountingEntryCreateDialog } from './dialogs/create/accounting-entry-create.dialog';
import { CsvUploadDialog } from './dialogs/csv-upload/csv-upload.dialog';
import { registerLocaleData } from '@angular/common';
import localeDe from '@angular/common/locales/de';
import * as moment from 'moment';
import { Subscriber } from 'rxjs';
import { AppEvent } from 'src/app/services/event/dtos/app-event';
import { AppEventService } from 'src/app/services/event/app-event.service';
registerLocaleData(localeDe);

@Component({
  selector: 'app-accounting-entries',
  templateUrl: './accounting-entries.page.html',
  styleUrls: ['./accounting-entries.page.scss']
})

export class AccountingEntriesPage implements AfterViewInit, OnInit {


  // Column Visibility
  panelOpenState = false;
  categoryVisible = true;
  auftragskontoVisible = false;
  buchungsdatumVisible = true;
  valutaDatumVisible = false;
  verwendungszweckVisible = true;
  glaeubigerIdVisible = false;
  mandatsreferenzVisible = false;
  sammlerreferenzVisible = false;
  lastschriftUrsprungsbetragVisible = false;
  auslagenersatzRuecklastschriftVisible = false;
  beguenstigterVisible = true;
  ibanVisible = false;
  bicVisible = false;
  betragVisible = true;
  buchungstextVisible = true;
  infoVisible = false;

  // FilterBar
  filterTerm = '';
  value: any[] = [];
  categorySelectedValues = [];
  categoryDataSource = new DropdownPaginationDataSource(
    (options) => this.categoriesCrudService.getPagedCategories(options),
    'title');

  public saldenDataSource: PaginationDataSource<ISaldoListItem>;
  // Table
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public accountingEntriesDataSource: PaginationDataSource<IAccountingEntryListItem>;
  public accountingEntriesGridColumns: string[] = [];

  constructor(
    private categoriesCrudService: CategoriesCrudService,
    private accountingEntriesCrudService: AccountingEntriesCrudService,
    private saldenCrudService: SaldenCrudService,
    private matDialog: MatDialog) {

    this.accountingEntriesDataSource = new PaginationDataSource<IAccountingEntryListItem>(
      (options) => this.accountingEntriesCrudService.getPagedAccountingEntries(options),
      () => [
        {
          filterField: 'verwendungszweck',
          containsFilters: [this.filterTerm]
        },
        {
          filterField: 'categoryId',
          equalsFilters: this.categorySelectedValues
        },
      ]);
  }

  async ngOnInit(): Promise<void> {
    this.accountingEntriesGridColumns = [];

    if (this.categoryVisible) this.accountingEntriesGridColumns.push('category');
    if (this.auftragskontoVisible) this.accountingEntriesGridColumns.push('auftragskonto');
    if (this.buchungsdatumVisible) this.accountingEntriesGridColumns.push('buchungsdatum');
    if (this.valutaDatumVisible) this.accountingEntriesGridColumns.push('valutaDatum');
    if (this.verwendungszweckVisible) this.accountingEntriesGridColumns.push('verwendungszweck');
    if (this.glaeubigerIdVisible) this.accountingEntriesGridColumns.push('glaeubigerId');
    if (this.mandatsreferenzVisible) this.accountingEntriesGridColumns.push('mandatsreferenz');
    if (this.sammlerreferenzVisible) this.accountingEntriesGridColumns.push('sammlerreferenz');
    if (this.lastschriftUrsprungsbetragVisible) this.accountingEntriesGridColumns.push('lastschriftUrsprungsbetrag');
    if (this.auslagenersatzRuecklastschriftVisible) this.accountingEntriesGridColumns.push('auslagenersatzRuecklastschrift');
    if (this.beguenstigterVisible) this.accountingEntriesGridColumns.push('beguenstigter');
    if (this.ibanVisible) this.accountingEntriesGridColumns.push('iban');
    if (this.bicVisible) this.accountingEntriesGridColumns.push('bic');
    if (this.betragVisible) this.accountingEntriesGridColumns.push('betrag');
    if (this.buchungstextVisible) this.accountingEntriesGridColumns.push('buchungstext');
    if (this.infoVisible) this.accountingEntriesGridColumns.push('info');
    this.accountingEntriesGridColumns.push('detail');
  }

  reloadVisibleColumns(): void {
    this.accountingEntriesGridColumns = [];
    setTimeout(() => {

      if (this.categoryVisible) this.accountingEntriesGridColumns.push('category');
      if (this.auftragskontoVisible) this.accountingEntriesGridColumns.push('auftragskonto');
      if (this.buchungsdatumVisible) this.accountingEntriesGridColumns.push('buchungsdatum');
      if (this.valutaDatumVisible) this.accountingEntriesGridColumns.push('valutaDatum');
      if (this.verwendungszweckVisible) this.accountingEntriesGridColumns.push('verwendungszweck');
      if (this.glaeubigerIdVisible) this.accountingEntriesGridColumns.push('glaeubigerId');
      if (this.mandatsreferenzVisible) this.accountingEntriesGridColumns.push('mandatsreferenz');
      if (this.sammlerreferenzVisible) this.accountingEntriesGridColumns.push('sammlerreferenz');
      if (this.lastschriftUrsprungsbetragVisible) this.accountingEntriesGridColumns.push('lastschriftUrsprungsbetrag');
      if (this.auslagenersatzRuecklastschriftVisible) this.accountingEntriesGridColumns.push('auslagenersatzRuecklastschrift');
      if (this.beguenstigterVisible) this.accountingEntriesGridColumns.push('beguenstigter');
      if (this.ibanVisible) this.accountingEntriesGridColumns.push('iban');
      if (this.bicVisible) this.accountingEntriesGridColumns.push('bic');
      if (this.betragVisible) this.accountingEntriesGridColumns.push('betrag');
      if (this.buchungstextVisible) this.accountingEntriesGridColumns.push('buchungstext');
      if (this.infoVisible) this.accountingEntriesGridColumns.push('info');
      this.accountingEntriesGridColumns.push('detail');
    }, 10);
  }

  async ngAfterViewInit(): Promise<void> {
    setTimeout(() => {
      this.accountingEntriesDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  openCreateDialog(): void {
    this.matDialog.open(AccountingEntryCreateDialog, {
      maxHeight: '90vh'
    });
  }

  openCsvImportDialog(): void {
    this.matDialog.open(CsvUploadDialog, {
      maxHeight: '90vh'
    });

    this.matDialog.afterAllClosed.subscribe(result => {
      this.accountingEntriesDataSource.triggerUpdate();
    });
  }

  toWaehrungsZeichen(waehrung: string): string {
    if (waehrung === "EUR") return "€";
    if (waehrung === "USD") return "$";
  }
  cutToStringLength(input: string, length: number): string {
    return input.substring(0, length);
  }

  onPointClick(event: any): void {
    // if (this.isSplit) {
    //   this.split(event.target.data);
    // } else {
    //   this.showSubCategory(event.target.data);
    // }
  }

  customizeColor(point): { color: string } {
    return { color: point.data.color };
  }
}
