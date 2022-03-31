import { NgModule } from '@angular/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AppEventService } from 'src/app/services/event/app-event.service';
import { AppEventSnackbarService } from './app-event-snackbar.service';

@NgModule({
  imports: [
    MatSnackBarModule,
  ],
  providers: [
    AppEventService,
    AppEventSnackbarService,
  ]
})
export class AppEventModule { }
