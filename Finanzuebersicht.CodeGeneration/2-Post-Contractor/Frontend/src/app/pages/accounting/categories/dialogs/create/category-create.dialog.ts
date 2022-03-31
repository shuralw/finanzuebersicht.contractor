import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DropdownPaginationDataSource } from '@krz/material';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.dialog.html',
  styleUrls: ['./category-create.dialog.scss']
})
export class CategoryCreateDialog implements OnInit {

  categoryCreateForm: FormGroup;

  superCategoryDataSource: DropdownPaginationDataSource<ICategoryListItem>;

  constructor(
    private categoriesCrudService: CategoriesCrudService,
    private formBuilder: FormBuilder,
    private router: Router,
    private dialogRef: MatDialogRef<CategoryCreateDialog>) {
  }

  async ngOnInit(): Promise<void> {
    this.categoryCreateForm = this.formBuilder.group({
      superCategoryId: new FormControl(null, [Validators.required]),
      title: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(200)]),
      color: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
    });

    this.superCategoryDataSource = new DropdownPaginationDataSource(
      (options) => this.categoriesCrudService.getPagedCategories(options),
      'bezeichnung');
  }

  async onCreateClicked(): Promise<void> {
    this.categoryCreateForm.markAllAsTouched();
    if (!this.categoryCreateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const categoryId = await this.categoriesCrudService.createCategory(this.categoryCreateForm.getRawValue());
    this.dialogRef.close();
    await this.router.navigate(['/accounting/categories/detail', categoryId]);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
