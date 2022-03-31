import { AfterViewInit, Component, Input } from '@angular/core';
import { PaginationDataSource } from '@krz/material';

@Component({
  selector: 'app-auswertung-pie-chart',
  templateUrl: './auswertung-pie-chart.component.html',
  styleUrls: ['./auswertung-pie-chart.component.css']
})
export class AuswertungPieChartComponent<T> implements AfterViewInit {

  pieDataSource: T[];

  @Input() dataSource: PaginationDataSource<T>;
  @Input() valueField: string;
  @Input() argumentField: string;

  collapsed = false;

  // initialOptions: IChartOptions = {
  //   TeilbaumID: 0,
  //   Level: 1,
  //   MinDate: new Date(new Date().getFullYear(), new Date().getMonth() - 1, 1),
  //   MaxDate: new Date(new Date().getFullYear(), new Date().getMonth(), 1)
  // };

  isSplit = false;

  // chartData: ICategory[];

  constructor() {

  }

  async ngAfterViewInit(): Promise<void> {
    this.dataSource.connect().subscribe(x => {
      setTimeout(() => {
        this.pieDataSource = x;
      }, 0);
    });
  }

  cutToStringLength(input: string, length: number): string {
    return input.substring(0, length);
  }

  pointClickHandler(e): void {
    this.toggleVisibility(e.target);
  }

  legendClickHandler(e): void {
    const arg = e.target;
    const item = e.component.getAllSeries()[0].getPointsByArg(arg)[0];

    this.toggleVisibility(item);
  }

  toggleVisibility(item): void {
    if (item.isVisible()) {
      item.hide();
    } else {
      item.show();
    }
  }
  
  reload(): void {
    // this.apiService.GetCharts(this.initialOptions).subscribe((res: IResponse<ICategory[]>) => {
    //   console.log(res);
    //   res.data.forEach(d => d.summe = Math.abs(d.summe));
    //   res.data.forEach(d => d.level = this.initialOptions.Level);

    //   this.setChartData(res.data);
    // });
  }

  // onPointClick(event: any): void {
  //   if (this.isSplit) {
  //     this.split(event.target.data);
  //   } else {
  //     this.showSubCategory(event.target.data);
  //   }
  // }

  // showSubCategory(category: ICategory): void {
  //   const options = {
  //     ...this.initialOptions,
  //     TeilbaumID: category.id,
  //     Level: category.level + 1
  //   };
  //   this.apiService.GetCharts(options).subscribe((res: IResponse<ICategory[]>) => {
  //     this.setChartData(res.data);
  //   });
  // }

  // split(category: ICategory): void {
  //   const options = {
  //     ...this.initialOptions,
  //     TeilbaumID: category.id,
  //     Level: category.level + 1
  //   };
  //   this.apiService.GetCharts(options).subscribe((res: IResponse<ICategory[]>) => {
  //     res.data.forEach(d => d.summe = Math.abs(d.summe));
  //     res.data.forEach(d => d.level = this.initialOptions.Level);
  //     this.chartData.filter(c => c.id !== category.id).forEach(d => res.data.push(d));

  //     this.setChartData(res.data);
  //   });
  // }

  // setChartData(data): void {
  //   this.chartData = data;
  // }

  customizeColor(point): { color: string } {
    return { color: point.data.color };
  }

}
