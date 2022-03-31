import { AfterViewInit, Component } from '@angular/core';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ISaldoListItem } from 'src/app/model/accounting/salden/dtos/i-saldo-list-item';
import { SaldenCrudService } from 'src/app/model/accounting/salden/salden-crud.service';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.page.html',
  styleUrls: ['./line-chart.page.scss']
})

export class LineChartPage implements AfterViewInit {

  public saldenDataSource: ISaldoListItem[];

  constructor(
    private saldenCrudService: SaldenCrudService) {
  }

  async ngAfterViewInit(): Promise<void> {
    this.saldenDataSource = await this.saldenCrudService
      .getPagedSalden(new Date(2021, 2, 1), new Date(2022, 2, 30));
  }
}
