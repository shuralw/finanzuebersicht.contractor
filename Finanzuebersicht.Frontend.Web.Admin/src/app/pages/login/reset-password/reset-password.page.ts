import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { passwordRegex } from 'src/app/helpers/regex.helper';
import { validatePassword } from 'src/app/helpers/validation.helper';
import { AdminEmailUserPasswordResetService } from 'src/app/model/admin-user-management/admin-email-user-password-reset/admin-email-user-password-reset.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.page.html',
  styleUrls: ['./reset-password.page.scss']
})
export class ResetPasswordPage implements OnInit {

  public formGroup: FormGroup;

  private token: string;

  public validatePassword = validatePassword;

  public submitted = false;

  public errorMessage = '';

  constructor(
    private activatedRoute: ActivatedRoute,
    private adminEmailUserPasswordResetService: AdminEmailUserPasswordResetService,
    formBuilder: FormBuilder,
    private router: Router) {
    this.formGroup = formBuilder.group({
      password: new FormControl('', [Validators.required, Validators.pattern(passwordRegex)]),
      password2: new FormControl('', [Validators.required, this.getPasswordValidator()]),
    });
  }

  public ngOnInit(): void {
    this.activatedRoute.params.subscribe(async params => {
      this.token = params.token;
    });
  }

  public async onSubmitButtonClicked(): Promise<void> {
    if (this.formGroup.valid) {
      try {
        await this.adminEmailUserPasswordResetService.resetPassword(this.token, this.formGroup.controls.password.value);
        await this.router.navigate(['/login']);
      } catch (e) {
        this.errorMessage = 'Das Passwort konnte nicht zurückgesetzt werden, da der Link abgelaufen ist.';
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
