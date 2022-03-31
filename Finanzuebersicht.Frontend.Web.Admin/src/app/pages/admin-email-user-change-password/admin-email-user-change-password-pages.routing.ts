import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminEmailUsersChangePasswordPage } from './admin-email-user-change-password.page';

const routes: Routes = [{ path: '', component: AdminEmailUsersChangePasswordPage }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminEmailUsersChangePasswordPagesRouting { }
