import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LineChartPage } from './line-chart/line-chart.page';
import { PieChartPage } from './pie-chart/pie-chart.page';

const routes: Routes = [
  { path: '', component: PieChartPage },
  { path: 'kuchendiagramm', component: PieChartPage },
  { path: 'liniendiagramm', component: LineChartPage },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuswertungenPagesRouting { }
