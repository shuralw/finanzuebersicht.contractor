import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DropdownPaginationDataSource, PaginationDataSource } from '@krz/material';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { CategorySearchTermsCrudService } from 'src/app/model/accounting/category-search-terms/category-search-terms-crud.service';
import { ICategorySearchTermListItem } from 'src/app/model/accounting/category-search-terms/dtos/i-category-search-term-list-item';
import { CategorySearchTermCreateDialog } from './dialogs/create/category-search-term-create.dialog';

@Component({
  selector: 'app-category-search-terms',
  templateUrl: './category-search-terms.page.html',
  styleUrls: ['./category-search-terms.page.scss']
})
export class CategorySearchTermsPage implements AfterViewInit {

  // FilterBar
  filterTerm = '';

  categorySelectedValues = [];
  categoryDataSource = new DropdownPaginationDataSource(
    (options) => this.categoriesCrudService.getPagedCategories(options),
    'bezeichnung');

  // Table
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public categorySearchTermsDataSource: PaginationDataSource<ICategorySearchTermListItem>;
  public categorySearchTermsGridColumns: string[] = [
    'category',
    'term',
    'detail',
  ];

  constructor(
    private categoriesCrudService: CategoriesCrudService,
    private categorySearchTermsCrudService: CategorySearchTermsCrudService,
    private matDialog: MatDialog) {

    this.categorySearchTermsDataSource = new PaginationDataSource<ICategorySearchTermListItem>(
      (options) => this.categorySearchTermsCrudService.getPagedCategorySearchTerms(options),
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
      this.categorySearchTermsDataSource.initialize(this.paginator, this.sort);
    }, 0);
  }

  openCreateDialog(): void {
    this.matDialog.open(CategorySearchTermCreateDialog, {
      maxHeight: '90vh'
    });
  }

}
