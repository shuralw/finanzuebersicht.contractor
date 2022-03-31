import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('./pages/login/login-pages.module')
      .then(m => m.LoginPagesModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./pages/home/home-pages.module')
      .then(m => m.HomePagesModule)
  },
  {
    path: 'kategorien',
    loadChildren: () => import('./pages/accounting/categories/categories-pages.module')
      .then(m => m.CategoriesPagesModule)
  },
  {
    path: 'umsaetze',
    loadChildren: () => import('./pages/accounting/accounting-entries/accounting-entries-pages.module')
      .then(m => m.AccountingEntriesPagesModule)
  },
  {
    path: 'suchbegriffe',
    loadChildren: () => import('./pages/accounting/category-search-terms/category-search-terms-pages.module')
      .then(m => m.CategorySearchTermsPagesModule)
  },
  {
    path: 'auswertungen',
    loadChildren: () => import('./pages/accounting/auswertungen/auswertungen-pages.module')
      .then(m => m.AuswertungenPagesModule)
  },
  {
    path: 'change-password',
    loadChildren: () => import('./pages/admin-email-user-change-password/admin-email-user-change-password-pages.module')
      .then(m => m.AdminEmailUsersChangePasswordPagesModule)
  },
  {
    path: 'accounting',
    loadChildren: () => import('./pages/accounting/accounting-pages.module')
      .then(m => m.AccountingPagesModule)
  },
  {
    path: '**',
    redirectTo: '/home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
