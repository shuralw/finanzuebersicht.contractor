import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { StartSaldenCrudService } from './start-salden-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    StartSaldenCrudService
  ]
})
export class StartSaldenModule { }
