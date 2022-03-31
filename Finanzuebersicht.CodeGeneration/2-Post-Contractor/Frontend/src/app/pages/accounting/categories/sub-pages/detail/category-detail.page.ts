import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { IAccountingEntry } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';
import { ICategoryDetail } from 'src/app/model/accounting/categories/dtos/i-category-detail';
import { ICategorySearchTerm } from 'src/app/model/accounting/category-search-terms/dtos/i-category-search-term';
import { CategoryUpdateDialog } from '../../dialogs/update/category-update.dialog';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.page.html',
  styleUrls: ['./category-detail.page.scss']
})
export class CategoryDetailPage implements OnInit {

  public categorySearchTermsTableDataSource = new MatTableDataSource<ICategorySearchTerm>([]);
  public categorySearchTermsGridColumns: string[] = [
    'bezeichnung',
    'detail',
  ];

  public childCategoriesTableDataSource = new MatTableDataSource<ICategory>([]);
  public childCategoriesGridColumns: string[] = [
    'bezeichnung',
    'detail',
  ];

  public accountingEntriesTableDataSource = new MatTableDataSource<IAccountingEntry>([]);
  public accountingEntriesGridColumns: string[] = [
    'bezeichnung',
    'detail',
  ];

  categoryId: string;
  category: ICategoryDetail;

  constructor(
    private categoriesCrudService: CategoriesCrudService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private matDialog: MatDialog,
    private confirmationDialogService: ConfirmationDialogService) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.categoryId = params.id;
        this.loadCategory().then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onUpdateClicked(): Promise<void> {
    const dialog = this.matDialog.open(CategoryUpdateDialog, {
        data: this.categoryId,
        minWidth: '320px',
    });

    if (await dialog.afterClosed().toPromise()) {
      await this.loadCategory();
    }
  }

  async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation('Wollen Sie wirklich Category \'' + this.category.bezeichnung + '\' löschen?')) {
        await this.categoriesCrudService.deleteCategory(this.category.id);
        await this.router.navigate(['/accounting/categories']);
    }
  }

  private async loadCategory(): Promise<void> {
    this.category = null;
    this.category = await this.categoriesCrudService.getCategoryDetail(this.categoryId);

    this.accountingEntriesTableDataSource.data = this.category.accountingEntries;

    this.childCategoriesTableDataSource.data = this.category.childCategories;

    this.categorySearchTermsTableDataSource.data = this.category.categorySearchTerms;
  }

}
