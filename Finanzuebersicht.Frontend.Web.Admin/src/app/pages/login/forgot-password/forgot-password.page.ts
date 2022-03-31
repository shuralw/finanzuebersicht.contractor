import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminEmailUserPasswordResetService } from 'src/app/model/admin-user-management/admin-email-user-password-reset/admin-email-user-password-reset.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.page.html',
  styleUrls: ['./forgot-password.page.scss']
})
export class ForgotPasswordPage {

  public formGroup: FormGroup;

  public submitted = false;

  constructor(
    private adminEmailUserPasswordResetService: AdminEmailUserPasswordResetService,
    formBuilder: FormBuilder) {
    this.formGroup = formBuilder.group({
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }

  public async onSubmitButtonClicked(): Promise<void> {
    if (this.formGroup.valid) {
      await this.adminEmailUserPasswordResetService.forgotPassword(this.formGroup.controls.email.value);
      this.submitted = true;
    }
  }

}
