import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'file-picker',
  templateUrl: './file-picker.component.html',
  styleUrls: ['./file-picker.component.scss']
})
export class FilePickerComponent {

  @Input() label: string;
  @Input() required = false;
  @Input() accept: string;

  file: File;
  fileName: string;
  @Output() fileChange = new EventEmitter<File>();

  fileSelected(event: any): void {
    if (event?.target?.files && event.target.files.length === 1) {
      this.file = event.target.files[0];
      this.fileName = this.file.name + ' (' + this.formatBytes(this.file.size, 1) + ')';
      this.fileChange.emit(this.file);
    }
  }

  getAriaLabel(): string {
    let ariaLabel = 'Dateiauswahlfeld ' + this.label;

    if (this.required) {
      ariaLabel += ' Pflichtfeld';
    }

    if (this.fileName != null) {
      ariaLabel += ' Ausgewählte Datei ' + this.fileName;
    }

    ariaLabel += ' Zum Auswählen einer Datei klicken.';

    return ariaLabel;
  }

  private formatBytes(bytes: number, decimals: number): string {
    if (bytes === 0) {
      return '0 Bytes';
    }

    const k = 1024;
    const dm = decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];

    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }

}
