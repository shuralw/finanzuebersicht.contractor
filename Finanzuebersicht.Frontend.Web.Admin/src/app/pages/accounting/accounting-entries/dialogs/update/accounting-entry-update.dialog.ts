import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DropdownPaginationDataSource } from '@krz/material';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { AccountingEntryUpdate } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry-update';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';

@Component({
  selector: 'app-accounting-entry-update',
  templateUrl: './accounting-entry-update.dialog.html',
  styleUrls: ['./accounting-entry-update.dialog.scss']
})
export class AccountingEntryUpdateDialog implements OnInit {

  accountingEntryUpdateForm: FormGroup;

  categoryDataSource: DropdownPaginationDataSource<ICategoryListItem>;
  selectedCategory: ICategory;

  constructor(
    private accountingEntriesCrudService: AccountingEntriesCrudService,
    private categoriesCrudService: CategoriesCrudService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<AccountingEntryUpdateDialog>,
    @Inject(MAT_DIALOG_DATA) public accountingEntryId: string) {
  }

  async ngOnInit(): Promise<void> {
    const accountingEntryDetail = await this.accountingEntriesCrudService.getAccountingEntryDetail(this.accountingEntryId);

    this.accountingEntryUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      categoryId: new FormControl(null),
      auftragskonto: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
      buchungsdatum: new FormControl(null, [Validators.required]),
      valutaDatum: new FormControl(null, [Validators.required]),
      buchungstext: new FormControl('', [Validators.maxLength(300)]),
      verwendungszweck: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(300)]),
      glaeubigerId: new FormControl('', [Validators.maxLength(100)]),
      mandatsreferenz: new FormControl('', [Validators.maxLength(100)]),
      sammlerreferenz: new FormControl('', [Validators.maxLength(100)]),
      lastschriftUrsprungsbetrag: new FormControl(null),
      auslagenersatzRuecklastschrift: new FormControl('', [Validators.maxLength(100)]),
      beguenstigter: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(200)]),
      iban: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(40)]),
      bic: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(20)]),
      betrag: new FormControl(null, [Validators.required]),
      waehrung: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(10)]),
      info: new FormControl('', [Validators.maxLength(100)]),
    });

    this.accountingEntryUpdateForm.patchValue(AccountingEntryUpdate.fromAccountingEntryDetail(accountingEntryDetail));

    this.selectedCategory = accountingEntryDetail.category;
    this.categoryDataSource = new DropdownPaginationDataSource(
      (options) => this.categoriesCrudService.getPagedCategories(options),
      'title');
  }

  async onUpdateClicked(): Promise<void> {
    this.accountingEntryUpdateForm.markAllAsTouched();
    if (!this.accountingEntryUpdateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const accountingEntryUpdate = this.accountingEntryUpdateForm.getRawValue();
    await this.accountingEntriesCrudService.updateAccountingEntry(accountingEntryUpdate);
    this.dialogRef.close(true);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
