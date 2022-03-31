import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AccountingEntriesCrudService } from './accounting-entries-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AccountingEntriesCrudService
  ]
})
export class AccountingEntriesModule { }
