import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesPage } from './categories.page';
import { CategoryDetailPage } from './sub-pages/detail/category-detail.page';

const routes: Routes = [
  { path: '', component: CategoriesPage },
  { path: 'detail/:id', component: CategoryDetailPage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesPagesRouting { }
