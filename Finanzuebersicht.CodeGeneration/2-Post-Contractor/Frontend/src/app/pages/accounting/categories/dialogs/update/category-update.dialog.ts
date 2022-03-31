import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DropdownPaginationDataSource } from '@krz/material';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';
import { CategoryUpdate } from 'src/app/model/accounting/categories/dtos/i-category-update';

@Component({
  selector: 'app-category-update',
  templateUrl: './category-update.dialog.html',
  styleUrls: ['./category-update.dialog.scss']
})
export class CategoryUpdateDialog implements OnInit {

  categoryUpdateForm: FormGroup;

  superCategoryDataSource: DropdownPaginationDataSource<ICategoryListItem>;
  selectedSuperCategory: ICategory;

  constructor(
    private categoriesCrudService: CategoriesCrudService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<CategoryUpdateDialog>,
    @Inject(MAT_DIALOG_DATA) public categoryId: string) {
  }

  async ngOnInit(): Promise<void> {
    const categoryDetail = await this.categoriesCrudService.getCategoryDetail(this.categoryId);

    this.categoryUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      superCategoryId: new FormControl(null, [Validators.required]),
      title: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(200)]),
      color: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
    });

    this.categoryUpdateForm.patchValue(CategoryUpdate.fromCategoryDetail(categoryDetail));

    this.selectedSuperCategory = categoryDetail.superCategory;
    this.superCategoryDataSource = new DropdownPaginationDataSource(
      (options) => this.categoriesCrudService.getPagedCategories(options),
      'bezeichnung');
  }

  async onUpdateClicked(): Promise<void> {
    this.categoryUpdateForm.markAllAsTouched();
    if (!this.categoryUpdateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const categoryUpdate = this.categoryUpdateForm.getRawValue();
    await this.categoriesCrudService.updateCategory(categoryUpdate);
    this.dialogRef.close(true);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
