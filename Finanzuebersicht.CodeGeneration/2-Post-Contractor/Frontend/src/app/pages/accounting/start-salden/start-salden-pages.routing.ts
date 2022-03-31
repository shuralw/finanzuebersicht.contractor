import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StartSaldenPage } from './start-salden.page';
import { StartSaldoDetailPage } from './sub-pages/detail/start-saldo-detail.page';

const routes: Routes = [
  { path: '', component: StartSaldenPage },
  { path: 'detail/:id', component: StartSaldoDetailPage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StartSaldenPagesRouting { }
