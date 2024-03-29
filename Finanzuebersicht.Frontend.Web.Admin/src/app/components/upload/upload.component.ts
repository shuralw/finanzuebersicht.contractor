import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { CategoriesCrudService } from 'src/app/model/accounting/categories/categories-crud.service';

import { AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DropdownPaginationDataSource, PaginationDataSource } from '@krz/material';
import { ICategoryListItem } from 'src/app/model/accounting/categories/dtos/i-category-list-item';


@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})

export class UploadComponent implements OnInit {
  inProgress = false;

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

    this.startUpload(formData)
      .then(value => {
        this.inProgress = false;
        this.onUploadFinished.emit();
      });
  }

  startUpload(formData: FormData): Promise<string> {
    const result = this.accountingEntriesCrudService.createAccountingEntries(formData);
    this.inProgress = true;
    return result;
  }
}
