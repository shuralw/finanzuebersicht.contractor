import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';
@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})

export class UploadComponent implements OnInit {
  progress: number;
  message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(
    private accountingEntriesCrudService: AccountingEntriesCrudService) { }
  ngOnInit() {
  }
  
  uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.accountingEntriesCrudService.createAccountingEntries(formData);
    // this.http.post('http://localhost:5010/api/accounting/accounting-entries/multiple',
    //   formData, { reportProgress: true, observe: 'events' })
    //   .subscribe({
    //     next: (event) => {
    //       if (event.type === HttpEventType.UploadProgress)
    //         this.progress = Math.round(100 * event.loaded / event.total);
    //       else if (event.type === HttpEventType.Response) {
    //         this.message = 'Upload success.';
    //         this.onUploadFinished.emit(event.body);
    //       }
    //     },
    //     error: (err: HttpErrorResponse) => console.log(err)
    //   });
  }
}