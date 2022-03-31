import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminAdLoginService } from 'src/app/model/admin-login-system/admin-ad-login/services/admin-ad-login.service';
import {
  AdminEmailUserLoginService
} from 'src/app/model/admin-login-system/admin-email-user-login/services/admin-email-user-login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss']
})
export class LoginPage {

  public formGroup: FormGroup;

  public errorMessage: string;

  public isLoggingIn = false;

  constructor(
    private adminEmailUserLoginService: AdminEmailUserLoginService,
    private adminAdLoginService: AdminAdLoginService,
    formBuilder: FormBuilder,
    private router: Router) {
    this.formGroup = formBuilder.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      passwort: new FormControl('', [Validators.required]),
    });
  }

  // ---------------------- AdminEmailUser Login ----------------------

  public async onLoginButtonClicked(): Promise<void> {
    this.errorMessage = null;
    this.isLoggingIn = true;
    try {
      await this.adminEmailUserLoginService.login({
        email: this.formGroup.controls.email.value,
        passwort: this.formGroup.controls.passwort.value,
      });
    } catch (e) {
      this.createAdminEmailUserLoginErrorMessage(e);
    }
    this.isLoggingIn = false;
  }

  // ---------------------- AD-AdminEmailUser Login ----------------------

  public async onAdminAdLoginButtonClicked(): Promise<void> {
    this.errorMessage = null;
    this.isLoggingIn = true;
    try {
      await this.adminAdLoginService.login();
    } catch (e) {
      await this.createAdminAdUserLoginErrorMessage(e);
    }
    this.isLoggingIn = false;
  }

  // ---------------------- Error Message ----------------------

  private createAdminEmailUserLoginErrorMessage(e: any): void {
    if (e.status === 0) {
      this.errorMessage = 'Die Verbindung zum Server ist fehlgeschlagen.';
    } else if (e.status === 400 || e.status === 404) {
      this.errorMessage = 'E-Mail Adresse oder Passwort inkorrekt';
    } else {
      this.errorMessage = 'Unbekannter Fehler';
    }
  }

  private async createAdminAdUserLoginErrorMessage(e: any): Promise<void> {
    if (e.status === 0) {
      this.errorMessage = 'Die Verbindung zum Server ist fehlgeschlagen.';
    } else if (e.status === 403) {
      this.errorMessage = 'Ihr Benutzer ist zur Anmeldung nicht berechtigt.';
    } else {
      this.errorMessage = 'Unbekannter Fehler';
    }
  }
}
