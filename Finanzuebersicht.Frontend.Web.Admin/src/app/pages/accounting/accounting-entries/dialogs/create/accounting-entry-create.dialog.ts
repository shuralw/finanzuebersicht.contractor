import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DropdownPaginationDataSource } from '@krz/material';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';

@Component({
  selector: 'app-accounting-entry-create',
  templateUrl: './accounting-entry-create.dialog.html',
  styleUrls: ['./accounting-entry-create.dialog.scss']
})
export class AccountingEntryCreateDialog implements OnInit {

  accountingEntryCreateForm: FormGroup;

  categoryDataSource: DropdownPaginationDataSource<ICategoryListItem>;

  constructor(
    private accountingEntriesCrudService: AccountingEntriesCrudService,
    private categoriesCrudService: CategoriesCrudService,
    private formBuilder: FormBuilder,
    private router: Router,
    private dialogRef: MatDialogRef<AccountingEntryCreateDialog>) {
  }

  async ngOnInit(): Promise<void> {
    this.accountingEntryCreateForm = this.formBuilder.group({
      categoryId: new FormControl(null),
      auftragskonto: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
      buchungsdatum: new FormControl(null),
      valutaDatum: new FormControl(null),
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

    this.categoryDataSource = new DropdownPaginationDataSource(
      (options) => this.categoriesCrudService.getPagedCategories(options),
      'title');
  }

  async onCreateClicked(): Promise<void> {
    this.accountingEntryCreateForm.markAllAsTouched();
    if (!this.accountingEntryCreateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const accountingEntryId = await this.accountingEntriesCrudService.createAccountingEntry(this.accountingEntryCreateForm.getRawValue());
    this.dialogRef.close();
    await this.router.navigate(['/accounting/accounting-entries/detail', accountingEntryId]);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
