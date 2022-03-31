import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DropdownPaginationDataSource, PaginationDataSource } from '@krz/material';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';
import { CategoryCreateDialog } from './dialogs/create/category-create.dialog';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.page.html',
  styleUrls: ['./categories.page.scss']
})
export class CategoriesPage implements AfterViewInit {

  // FilterBar
  filterTerm = '';

  superCategorySelectedValues = [];
  superCategoryDataSource = new DropdownPaginationDataSource(
    (options) => this.categoriesCrudService.getPagedCategories(options),
    'title');

  // Table
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public categoriesDataSource: PaginationDataSource<ICategoryListItem>;
  public categoriesGridColumns: string[] = [
    'superCategory',
    'title',
    'color',
    'detail',
  ];

  constructor(
    private categoriesCrudService: CategoriesCrudService,
    private matDialog: MatDialog) {

    this.categoriesDataSource = new PaginationDataSource<ICategoryListItem>(
      (options) => this.categoriesCrudService.getPagedCategories(options),
      () => [
        {
          filterField: 'title',
          containsFilters: [this.filterTerm]
        },
        {
          filterField: 'superCategoryId',
          equalsFilters: this.superCategorySelectedValues
        },
      ]);
  }

  async ngAfterViewInit(): Promise<void> {
    setTimeout(() => {
      this.categoriesDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  openCreateDialog(): void {
    this.matDialog.open(CategoryCreateDialog, {
      maxHeight: '90vh'
    });
  }
}
