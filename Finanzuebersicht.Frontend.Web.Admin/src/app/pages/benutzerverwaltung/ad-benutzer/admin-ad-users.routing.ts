import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAdUsersPage } from './admin-ad-users.page';
import { AdminAdUserDetailPage } from './admin-ad-user-detail/admin-ad-user-detail.page';

const routes: Routes = [
  { path: '', component: AdminAdUsersPage },
  { path: 'detail/:id', component: AdminAdUserDetailPage },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminAdUsersPagesRouting { }
