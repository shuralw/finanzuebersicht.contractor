import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { StartSaldenCrudService } from 'src/app/model/accounting/start-salden/start-salden-crud.service';

@Component({
  selector: 'app-start-saldo-create',
  templateUrl: './start-saldo-create.dialog.html',
  styleUrls: ['./start-saldo-create.dialog.scss']
})
export class StartSaldoCreateDialog implements OnInit {

  startSaldoCreateForm: FormGroup;

  constructor(
    private startSaldenCrudService: StartSaldenCrudService,
    private formBuilder: FormBuilder,
    private router: Router,
    private dialogRef: MatDialogRef<StartSaldoCreateDialog>) {
  }

  async ngOnInit(): Promise<void> {
    this.startSaldoCreateForm = this.formBuilder.group({
      betrag: new FormControl(null, [Validators.required]),
      datumAm: new FormControl(null, [Validators.required]),
    });
  }

  async onCreateClicked(): Promise<void> {
    this.startSaldoCreateForm.markAllAsTouched();
    if (!this.startSaldoCreateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const startSaldoId = await this.startSaldenCrudService.createStartSaldo(this.startSaldoCreateForm.getRawValue());
    this.dialogRef.close();
    await this.router.navigate(['/accounting/start-salden/detail', startSaldoId]);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
