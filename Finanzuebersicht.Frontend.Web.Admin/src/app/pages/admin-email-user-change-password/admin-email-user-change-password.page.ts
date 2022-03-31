import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { passwordRegex } from 'src/app/helpers/regex.helper';
import { AdminEmailUsersChangePasswordService } from 'src/app/model/admin-user-management/admin-email-users/services/admin-email-users-change-password.service';

@Component({
  selector: 'app-admin-email-user-change-password',
  templateUrl: './admin-email-user-change-password.page.html',
  styleUrls: ['./admin-email-user-change-password.page.scss']
})
export class AdminEmailUsersChangePasswordPage {

  public formGroup: FormGroup;

  public submitted = false;

  public errorMessage = '';

  constructor(
    private adminEmailUsersChangePasswordService: AdminEmailUsersChangePasswordService,
    formBuilder: FormBuilder,
    private router: Router) {
    this.formGroup = formBuilder.group({
      oldPassword: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required, Validators.pattern(passwordRegex)]),
      password2: new FormControl('', [Validators.required, this.getPasswordValidator()]),
    });
  }

  public async onSubmitButtonClicked(): Promise<void> {
    this.submitted = true;
    if (this.formGroup.valid) {
      try {
        await this.adminEmailUsersChangePasswordService.changePassword({
          oldPassword: this.formGroup.controls.oldPassword.value,
          newPassword: this.formGroup.controls.password.value
        });
        await this.router.navigate(['/home']);
      } catch (e) {
        this.submitted = false;
        this.errorMessage = 'Das Passwort konnte nicht geändert werden.';
      }
    }
  }

  updateValueAndValidityOfPassword2(): void {
    this.formGroup.controls.password2.updateValueAndValidity();
  }

  private getPasswordValidator(): ValidatorFn {
    return Validators.compose([(c) => {
      if (this.formGroup && this.formGroup.controls.password.value !== this.formGroup.controls.password2.value) {
        return { equal: true };
      } else {
        return {};
      }
    }]);
  }
}
