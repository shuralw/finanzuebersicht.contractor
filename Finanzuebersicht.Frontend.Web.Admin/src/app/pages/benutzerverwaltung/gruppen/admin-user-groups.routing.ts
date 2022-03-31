import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminUserGroupsPage } from './admin-user-groups.page';
import { AdminUserGroupDetailPage } from './admin-user-group-detail/admin-user-group-detail.page';

const routes: Routes = [
  { path: '', component: AdminUserGroupsPage },
  { path: 'detail/:id', component: AdminUserGroupDetailPage },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminUserGroupsPagesRouting { }
