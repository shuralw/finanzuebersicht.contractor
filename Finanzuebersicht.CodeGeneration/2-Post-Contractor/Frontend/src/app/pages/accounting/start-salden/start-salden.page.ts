import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { PaginationDataSource } from '@krz/material';
import { IStartSaldoListItem } from 'src/app/model/accounting/start-salden/dtos/i-start-saldo-list-item';
import { StartSaldenCrudService } from 'src/app/model/accounting/start-salden/start-salden-crud.service';
import { StartSaldoCreateDialog } from './dialogs/create/start-saldo-create.dialog';

@Component({
  selector: 'app-start-salden',
  templateUrl: './start-salden.page.html',
  styleUrls: ['./start-salden.page.scss']
})
export class StartSaldenPage implements AfterViewInit {

  // FilterBar
  filterTerm = '';

  // Table
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public startSaldenDataSource: PaginationDataSource<IStartSaldoListItem>;
  public startSaldenGridColumns: string[] = [
    'betrag',
    'datumAm',
    'detail',
  ];

  constructor(
    private startSaldenCrudService: StartSaldenCrudService,
    private matDialog: MatDialog) {

    this.startSaldenDataSource = new PaginationDataSource<IStartSaldoListItem>(
      (options) => this.startSaldenCrudService.getPagedStartSalden(options),
      () => [
        {
          filterField: 'bezeichnung',
          containsFilters: [this.filterTerm]
        },
      ]);
  }

  async ngAfterViewInit(): Promise<void> {
    setTimeout(() => {
      this.startSaldenDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  openCreateDialog(): void {
    this.matDialog.open(StartSaldoCreateDialog, {
      maxHeight: '90vh'
    });
  }

}
