import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForgotPasswordPage } from './forgot-password/forgot-password.page';
import { LoginPage } from './login.page';
import { ResetPasswordPage } from './reset-password/reset-password.page';

const routes: Routes = [
  { path: '', component: LoginPage },
  { path: 'forgot-password', component: ForgotPasswordPage },
  { path: 'reset-password/:token', component: ResetPasswordPage },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginPagesRouting { }
