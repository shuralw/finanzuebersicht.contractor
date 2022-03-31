import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CategoriesCrudService } from './categories-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    CategoriesCrudService
  ]
})
export class CategoriesModule { }
