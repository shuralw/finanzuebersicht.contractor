import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HomePagesRouting } from './home-pages.routing';
import { HomePage } from './home.page';

@NgModule({
  declarations: [
    HomePage
  ],
  imports: [
    // Routing Modules
    HomePagesRouting,

    // Misc Modules
    CommonModule,
  ]
})
export class HomePagesModule { }
