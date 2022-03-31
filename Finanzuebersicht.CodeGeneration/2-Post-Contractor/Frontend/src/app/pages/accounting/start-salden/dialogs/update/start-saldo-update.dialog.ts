import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { StartSaldoUpdate } from 'src/app/model/accounting/start-salden/dtos/i-start-saldo-update';
import { StartSaldenCrudService } from 'src/app/model/accounting/start-salden/start-salden-crud.service';

@Component({
  selector: 'app-start-saldo-update',
  templateUrl: './start-saldo-update.dialog.html',
  styleUrls: ['./start-saldo-update.dialog.scss']
})
export class StartSaldoUpdateDialog implements OnInit {

  startSaldoUpdateForm: FormGroup;

  constructor(
    private startSaldenCrudService: StartSaldenCrudService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<StartSaldoUpdateDialog>,
    @Inject(MAT_DIALOG_DATA) public startSaldoId: string) {
  }

  async ngOnInit(): Promise<void> {
    const startSaldoDetail = await this.startSaldenCrudService.getStartSaldoDetail(this.startSaldoId);

    this.startSaldoUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      betrag: new FormControl(null, [Validators.required]),
      datumAm: new FormControl(null, [Validators.required]),
    });

    this.startSaldoUpdateForm.patchValue(StartSaldoUpdate.fromStartSaldoDetail(startSaldoDetail));
  }

  async onUpdateClicked(): Promise<void> {
    this.startSaldoUpdateForm.markAllAsTouched();
    if (!this.startSaldoUpdateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const startSaldoUpdate = this.startSaldoUpdateForm.getRawValue();
    await this.startSaldenCrudService.updateStartSaldo(startSaldoUpdate);
    this.dialogRef.close(true);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
