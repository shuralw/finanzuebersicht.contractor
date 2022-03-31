import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategorySearchTermsPage } from './category-search-terms.page';
import { CategorySearchTermDetailPage } from './sub-pages/detail/category-search-term-detail.page';

const routes: Routes = [
  { path: '', component: CategorySearchTermsPage },
  { path: 'detail/:id', component: CategorySearchTermDetailPage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategorySearchTermsPagesRouting { }
