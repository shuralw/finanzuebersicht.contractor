import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'accounting-entries',
    loadChildren: () => import('./accounting-entries/accounting-entries-pages.module')
      .then(m => m.AccountingEntriesPagesModule)
  },
  {
    path: 'categories',
    loadChildren: () => import('./categories/categories-pages.module')
      .then(m => m.CategoriesPagesModule)
  },
  {
    path: 'start-salden',
    loadChildren: () => import('./start-salden/start-salden-pages.module')
      .then(m => m.StartSaldenPagesModule)
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
