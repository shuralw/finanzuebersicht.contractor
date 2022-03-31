import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DropdownPaginationDataSource, PaginationDataSource } from '@krz/material';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { IAccountingEntryListItem } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry-list-item';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { AccountingEntryCreateDialog } from './dialogs/create/accounting-entry-create.dialog';

@Component({
  selector: 'app-accounting-entries',
  templateUrl: './accounting-entries.page.html',
  styleUrls: ['./accounting-entries.page.scss']
})
export class AccountingEntriesPage implements AfterViewInit {

  // FilterBar
  filterTerm = '';

  categorySelectedValues = [];
  categoryDataSource = new DropdownPaginationDataSource(
    (options) => this.categoriesCrudService.getPagedCategories(options),
    'bezeichnung');

  // Table
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public accountingEntriesDataSource: PaginationDataSource<IAccountingEntryListItem>;
  public accountingEntriesGridColumns: string[] = [
    'category',
    'auftragskonto',
    'buchungsdatum',
    'valutaDatum',
    'buchungstext',
    'verwendungszweck',
    'glaeubigerId',
    'mandatsreferenz',
    'sammlerreferenz',
    'lastschriftUrsprungsbetrag',
    'auslagenersatzRuecklastschrift',
    'beguenstigter',
    'iBAN',
    'bIC',
    'betrag',
    'waehrung',
    'info',
    'detail',
  ];

  constructor(
    private categoriesCrudService: CategoriesCrudService,
    private accountingEntriesCrudService: AccountingEntriesCrudService,
    private matDialog: MatDialog) {

    this.accountingEntriesDataSource = new PaginationDataSource<IAccountingEntryListItem>(
      (options) => this.accountingEntriesCrudService.getPagedAccountingEntries(options),
      () => [
        {
          filterField: 'bezeichnung',
          containsFilters: [this.filterTerm]
        },
        {
          filterField: 'categoryId',
          equalsFilters: this.categorySelectedValues
        },
      ]);
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

}
