import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';

@Component({
  selector: 'app-auswertung-bar-chart',
  templateUrl: './auswertung-bar-chart.component.html',
  styleUrls: ['./auswertung-bar-chart.component.css']
})
export class AuswertungBarChartComponent implements OnInit {

  collapsed = false;

  dataAll: ICategory[];
  dataNegative: ICategory[];
  showPositive = true;

  initialOptions: IChartOptions = {
    TeilbaumID: 0,
    Level: 0,
    MinDate: new Date(new Date().getFullYear(), new Date().getMonth() - 1, 1),
    MaxDate: new Date(new Date().getFullYear(), new Date().getMonth(), 1)
  };

  isSplit = false;

  chartData: ICategory[];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.reload();
  }

  reload(): void {
    this.apiService.GetCharts(this.initialOptions).subscribe((res: IResponse<ICategory[]>) => {
      const dataPositive = res.data.filter(r => r.summe > 0).sort((r1, r2) => r1.summe - r2.summe);
      this.dataNegative = res.data.filter(r => r.summe < 0).sort((r1, r2) => r2.summe - r1.summe);
      this.dataAll = this.dataNegative.concat(dataPositive);

      this.updateChartData();
    });
  }

  updateChartData(): void {
    let data: ICategory[] = ((this.showPositive) ? this.dataAll : this.dataNegative);

    if (!data.find(d => d.summe > 0)) {
      data = data.map(d => {
        return {
          ...d, summe: -d.summe
        };
      });
    }

    this.chartData = data;
  }

  customizeColor(point): { color: string } {
    return { color: point.data.color };
  }

}
