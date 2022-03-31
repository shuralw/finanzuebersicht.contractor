import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IChartOptions } from '../../../interfaces/dto.interface';
import { faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-auswertung-settings',
  templateUrl: './auswertung-settings.component.html',
  styleUrls: ['./auswertung-settings.component.css']
})
export class AuswertungSettingsComponent {

  faChevronDown = faChevronDown;
  faChevronUp = faChevronUp;

  @Input() settings: IChartOptions;
  @Output() update = new EventEmitter();

  collapsed = true;

  constructor() { }

  triggerUpdate(): void {
    this.update.emit(null);
  }

  lastWeek(): void {
    this.settings.MaxDate = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() - 1);
    this.settings.MinDate = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() - 8);
    this.triggerUpdate();
  }

  lastMonth(): void {
    this.settings.MaxDate = new Date(new Date().getFullYear(), new Date().getMonth(), 1);
    this.settings.MinDate = new Date(new Date().getFullYear(), new Date().getMonth() - 1, 1);
    this.triggerUpdate();
  }

  lastYear(): void {
    this.settings.MaxDate = new Date(new Date().getFullYear(), 0, 1);
    this.settings.MinDate = new Date(new Date().getFullYear() - 1, 0, 1);
    this.triggerUpdate();
  }

  thisMonth(): void {
    this.settings.MaxDate = new Date();
    this.settings.MinDate = new Date(new Date().getFullYear(), new Date().getMonth(), 1);
    this.triggerUpdate();
  }

  thisYear(): void {
    this.settings.MaxDate = new Date();
    this.settings.MinDate = new Date(new Date().getFullYear(), 0, 1);
    this.triggerUpdate();
  }
}
