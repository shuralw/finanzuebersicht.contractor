import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'benutzer',
    loadChildren: () => import('./benutzer/admin-email-users.module').then(m => m.AdminEmailUsersPagesModule)
  },
  {
    path: 'gruppen',
    loadChildren: () => import('./gruppen/admin-user-groups.module').then(m => m.AdminUserGroupsPagesModule)
  },
  {
    path: 'ad-benutzer',
    loadChildren: () => import('./ad-benutzer/admin-ad-users.module').then(m => m.AdminAdUsersPagesModule)
  },
  {
    path: 'ad-gruppen',
    loadChildren: () => import('./ad-gruppen/admin-ad-groups.module').then(m => m.AdminAdGroupsPagesModule)
  },
  { path: '**', redirectTo: 'benutzer' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminUserManagementPagesRouting { }
