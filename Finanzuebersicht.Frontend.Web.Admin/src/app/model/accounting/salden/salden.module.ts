import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SaldenCrudService } from './salden-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    SaldenCrudService
  ]
})
export class SaldenModule { }
