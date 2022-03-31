import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAdGroupsPage } from './admin-ad-groups.page';
import { AdminAdGroupDetailPage } from './admin-ad-group-detail/admin-ad-group-detail.page';

const routes: Routes = [
  { path: '', component: AdminAdGroupsPage },
  { path: 'detail/:id', component: AdminAdGroupDetailPage },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminAdGroupsPagesRouting { }
