import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountingEntriesPage } from './accounting-entries.page';
import { AccountingEntryDetailPage } from './sub-pages/detail/accounting-entry-detail.page';

const routes: Routes = [
  { path: '', component: AccountingEntriesPage },
  { path: 'detail/:id', component: AccountingEntryDetailPage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountingEntriesPagesRouting { }
