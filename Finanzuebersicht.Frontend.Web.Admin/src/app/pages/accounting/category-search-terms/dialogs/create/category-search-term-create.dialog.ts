import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DropdownPaginationDataSource } from '@krz/material';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';
import { CategorySearchTermsCrudService } from 'src/app/model/accounting/category-search-terms/category-search-terms-crud.service';

@Component({
  selector: 'app-category-search-term-create',
  templateUrl: './category-search-term-create.dialog.html',
  styleUrls: ['./category-search-term-create.dialog.scss']
})
export class CategorySearchTermCreateDialog implements OnInit {

  categorySearchTermCreateForm: FormGroup;

  categoryDataSource: DropdownPaginationDataSource<ICategoryListItem>;

  constructor(
    private categorySearchTermsCrudService: CategorySearchTermsCrudService,
    private categoriesCrudService: CategoriesCrudService,
    private formBuilder: FormBuilder,
    private router: Router,
    private dialogRef: MatDialogRef<CategorySearchTermCreateDialog>) {
  }

  async ngOnInit(): Promise<void> {
    this.categorySearchTermCreateForm = this.formBuilder.group({
      categoryId: new FormControl(null, [Validators.required]),
      term: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(100)]),
    });

    this.categoryDataSource = new DropdownPaginationDataSource(
      (options) => this.categoriesCrudService.getPagedCategories(options),
      'title');
  }

  async onCreateClicked(): Promise<void> {
    this.categorySearchTermCreateForm.markAllAsTouched();
    if (!this.categorySearchTermCreateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const categorySearchTermId = await this.categorySearchTermsCrudService.createCategorySearchTerm(this.categorySearchTermCreateForm.getRawValue());
    this.dialogRef.close();
    await this.router.navigate(['/accounting/category-search-terms/detail', categorySearchTermId]);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
