import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { CategorySearchTermsCrudService } from 'src/app/model/accounting/category-search-terms/category-search-terms-crud.service';
import { ICategorySearchTermDetail } from 'src/app/model/accounting/category-search-terms/dtos/i-category-search-term-detail';
import { CategorySearchTermUpdateDialog } from '../../dialogs/update/category-search-term-update.dialog';

@Component({
  selector: 'app-category-search-term-detail',
  templateUrl: './category-search-term-detail.page.html',
  styleUrls: ['./category-search-term-detail.page.scss']
})
export class CategorySearchTermDetailPage implements OnInit {

  categorySearchTermId: string;
  categorySearchTerm: ICategorySearchTermDetail;

  constructor(
    private categorySearchTermsCrudService: CategorySearchTermsCrudService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private matDialog: MatDialog,
    private confirmationDialogService: ConfirmationDialogService) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.categorySearchTermId = params.id;
        this.loadCategorySearchTerm().then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onUpdateClicked(): Promise<void> {
    const dialog = this.matDialog.open(CategorySearchTermUpdateDialog, {
      data: this.categorySearchTermId,
      minWidth: '320px',
    });

    if (await dialog.afterClosed().toPromise()) {
      await this.loadCategorySearchTerm();
    }
  }

  async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation('Wollen Sie diesen Suchbegriff wirklich löschen?')) {
      await this.categorySearchTermsCrudService.deleteCategorySearchTerm(this.categorySearchTerm.id);
      await this.router.navigate(['/accounting/category-search-terms']);
    }
  }

  private async loadCategorySearchTerm(): Promise<void> {
    this.categorySearchTerm = null;
    this.categorySearchTerm = await this.categorySearchTermsCrudService.getCategorySearchTermDetail(this.categorySearchTermId);
  }

}
