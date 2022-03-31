import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminEmailUsersPage } from './admin-email-users.page';
import { AdminEmailUserDetailPage } from './admin-email-user-detail/admin-email-user-detail.page';

const routes: Routes = [
  { path: '', component: AdminEmailUsersPage },
  { path: 'detail/:id', component: AdminEmailUserDetailPage },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminEmailUsersPagesRouting { }
