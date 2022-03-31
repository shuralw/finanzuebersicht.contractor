import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'umsaetze',
    loadChildren: () => import('./accounting-entries/accounting-entries-pages.module')
      .then(m => m.AccountingEntriesPagesModule)
  },
  {
    path: 'categories',
    loadChildren: () => import('./categories/categories-pages.module')
      .then(m => m.CategoriesPagesModule)
  },
  {
    path: 'auswertungen',
    loadChildren: () => import('./auswertungen/auswertungen-pages.module')
      .then(m => m.AuswertungenPagesModule)
  },
  {
    path: 'category-search-terms',
    loadChildren: () => import('./category-search-terms/category-search-terms-pages.module')
      .then(m => m.CategorySearchTermsPagesModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountingPagesRouting { }
