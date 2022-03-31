import { Component, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-file-browser',
  templateUrl: './file-browser.component.html',
  styleUrls: ['./file-browser.component.css']
})
export class FileBrowserComponent  {

  @Input() title = 'Wählen sie eine Datei aus:';
  @Input() desc = 'Datei hochladen';
  @Input() encoding = 'UTF-8';
  @Output() done = new EventEmitter<string>();

  // Popup visibility
  popupVisible = false;
  isUploading = false;

  file: any;
  fileInput: HTMLInputElement;

  show(): void {
    this.popupVisible = true;
    this.file = null;
  }

  close(): void {
    this.popupVisible = false;
    this.isUploading = false;
    if (this.fileInput) {
      this.fileInput.value = null;
      this.fileInput = null;
    }
    this.file = null;
  }

  // Event, that triggers when a file got changed in file picker
  fileChanged(e: Event): void {
    // Grab file
    this.fileInput = (e.target as HTMLInputElement);
    this.file = this.fileInput.files[0];

    // If there is no file -> abort
    if (!this.file) {
      return;
    }
  }

  upload(): void {
    if (this.file) {
      this.isUploading = true;
      const reader = new FileReader();
      reader.readAsText(this.file, this.encoding);
      reader.onload = ((event) => {
        const text = ((event.target as any).result as string);
        this.done.emit(text);
        this.close();
      });
    }
  }

}
