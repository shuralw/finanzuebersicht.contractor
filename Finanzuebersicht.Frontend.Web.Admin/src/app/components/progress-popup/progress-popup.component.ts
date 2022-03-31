import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-progress-popup',
  templateUrl: './progress-popup.component.html',
  styleUrls: ['./progress-popup.component.css']
})
export class ProgressPopupComponent  {

  @Input() title = '';
  @Input() progressMax = 1;
  progress = 0;

  // Popup visibility
  popupVisible = false;

  format(value): string {
    return (value * 100).toFixed() + '%';
  }

  show(): void {
    this.popupVisible = true;
    this.progress = 0;
  }

  close(): void {
    this.popupVisible = false;
  }

  setProgress(progress: number): void {
    this.progress = progress;
    if (this.progress === this.progressMax) {
      this.close();
    }
  }

}
