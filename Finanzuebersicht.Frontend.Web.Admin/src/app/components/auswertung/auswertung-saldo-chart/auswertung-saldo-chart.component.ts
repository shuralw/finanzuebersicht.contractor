import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { IMinMaxDate, ISaldo, IResponse, ISettings } from '../../../interfaces/dto.interface';

@Component({
  selector: 'app-auswertung-saldo-chart',
  templateUrl: './auswertung-saldo-chart.component.html',
  styleUrls: ['./auswertung-saldo-chart.component.css']
})
export class AuswertungSaldoChartComponent implements OnInit {

  collapsed = false;

  options: IMinMaxDate = {
    MinDate: new Date(new Date().getFullYear(), new Date().getMonth() - 1, 1),
    MaxDate: new Date(),
  };

  chartData: ISaldo[] = [];

  buffer: number = undefined;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.reload();
  }

  reload(): void {
    this.apiService.GetSaldos(this.options).subscribe(res => {
      this.chartData = res.data;
    });

    this.apiService.GetSettings().subscribe((res: IResponse<ISettings>) => {
      const settings = res.data as ISettings;
      if (settings.frontendSettings) {
        this.buffer = JSON.parse(settings.frontendSettings).buffer;
      }
    });
  }

}
