import { AfterViewInit, Component } from '@angular/core';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
import { ICategoryChartItem } from 'src/app/model/accounting/categories/dtos/i-category-chart-item';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.page.html',
  styleUrls: ['./pie-chart.page.scss']
})

export class PieChartPage implements AfterViewInit {

  availableShownValues: string[] = ['Einnahmen', 'Ausgaben'];
  valuesShown = 'Einnahmen';

  private initialCategoriesDataSource: ICategoryChartItem[];
  public categoriesDataSource: ICategoryChartItem[];

  constructor(
    private categoriesCrudService: CategoriesCrudService) {
  }

  async ngAfterViewInit(): Promise<void> {
    this.initialCategoriesDataSource = await this.categoriesCrudService.getSummedCategories();
    this.filterCategories();
  }

  filterCategories(): void {
    setTimeout(() => {
      if (this.valuesShown === 'Einnahmen') {
        this.categoriesDataSource = this.initialCategoriesDataSource.filter((elem) => elem.summe > 0);
      }
      else {
        this.categoriesDataSource = this.initialCategoriesDataSource.filter((elem) => elem.summe < 0);
      }
    }, 0);
  }

  pointClickHandler(e): void {
    this.toggleVisibility(e.target);
    console.log(e.target);
    console.log(e.target.data);
    console.log(e);
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

  customizeColor(point): { color: string } {
    return { color: point.data.color };
  }
}
