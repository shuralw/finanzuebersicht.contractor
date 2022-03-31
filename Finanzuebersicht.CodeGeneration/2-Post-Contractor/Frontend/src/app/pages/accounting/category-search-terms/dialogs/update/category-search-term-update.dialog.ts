import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DropdownPaginationDataSource } from '@krz/material';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';
import { CategorySearchTermsCrudService } from 'src/app/model/accounting/category-search-terms/category-search-terms-crud.service';
import { CategorySearchTermUpdate } from 'src/app/model/accounting/category-search-terms/dtos/i-category-search-term-update';

@Component({
  selector: 'app-category-search-term-update',
  templateUrl: './category-search-term-update.dialog.html',
  styleUrls: ['./category-search-term-update.dialog.scss']
})
export class CategorySearchTermUpdateDialog implements OnInit {

  categorySearchTermUpdateForm: FormGroup;

  categoryDataSource: DropdownPaginationDataSource<ICategoryListItem>;
  selectedCategory: ICategory;

  constructor(
    private categorySearchTermsCrudService: CategorySearchTermsCrudService,
    private categoriesCrudService: CategoriesCrudService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<CategorySearchTermUpdateDialog>,
    @Inject(MAT_DIALOG_DATA) public categorySearchTermId: string) {
  }

  async ngOnInit(): Promise<void> {
    const categorySearchTermDetail = await this.categorySearchTermsCrudService.getCategorySearchTermDetail(this.categorySearchTermId);

    this.categorySearchTermUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      categoryId: new FormControl(null, [Validators.required]),
      term: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(100)]),
    });

    this.categorySearchTermUpdateForm.patchValue(CategorySearchTermUpdate.fromCategorySearchTermDetail(categorySearchTermDetail));

    this.selectedCategory = categorySearchTermDetail.category;
    this.categoryDataSource = new DropdownPaginationDataSource(
      (options) => this.categoriesCrudService.getPagedCategories(options),
      'bezeichnung');
  }

  async onUpdateClicked(): Promise<void> {
    this.categorySearchTermUpdateForm.markAllAsTouched();
    if (!this.categorySearchTermUpdateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const categorySearchTermUpdate = this.categorySearchTermUpdateForm.getRawValue();
    await this.categorySearchTermsCrudService.updateCategorySearchTerm(categorySearchTermUpdate);
    this.dialogRef.close(true);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
