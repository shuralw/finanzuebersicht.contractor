import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CategorySearchTermsCrudService } from './category-search-terms-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    CategorySearchTermsCrudService
  ]
})
export class CategorySearchTermsModule { }
