import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConfirmationDialog } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.component';
import { dnRegex } from 'src/app/helpers/regex.helper';

@Component({
  selector: 'app-admin-ad-group-create-and-update',
  templateUrl: './admin-ad-group-create-and-update.component.html',
  styleUrls: ['./admin-ad-group-create-and-update.component.scss']
})
export class AdminAdGroupCreateAndUpdateComponent {

  isUpdating: boolean;

  formGroup: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) data: any,
    private dialogRef: MatDialogRef<ConfirmationDialog>) {

    this.isUpdating = data?.dn != null;

    this.formGroup = this.formBuilder.group({
      dn: new FormControl(data?.dn || '', [Validators.required, Validators.pattern(dnRegex), Validators.maxLength(256)]),
    });
  }

  onConfirmClick(): void {
    this.formGroup.markAllAsTouched();
    if (this.formGroup.valid) {
      this.dialogRef.close(this.formGroup.controls.dn.value);
    }
  }

}
