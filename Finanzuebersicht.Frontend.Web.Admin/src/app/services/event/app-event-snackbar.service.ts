import { EventEmitter, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AppEventService } from './app-event.service';
import { AppEvent, AppEventType } from './dtos/app-event';

@Injectable()
export class AppEventSnackbarService {

    eventEmitter = new EventEmitter<AppEvent>();

    constructor(
        private appEventService: AppEventService,
        private matSnackBar: MatSnackBar) {
    }

    public initialize(): void {
        this.appEventService.onEventOccurred().subscribe((appEvent: AppEvent) => {
            switch (appEvent.eventType) {
                case AppEventType.Success:
                    this.matSnackBar.open(appEvent.message, null, {
                        duration: 5000,
                        panelClass: 'green-snackbar'
                    });
                    break;
                case AppEventType.Warning:
                    this.matSnackBar.open(appEvent.message, null, {
                        duration: 5000,
                        panelClass: 'orange-snackbar'
                    });
                    break;
                case AppEventType.Error:
                    this.matSnackBar.open(appEvent.message, null, {
                        duration: 5000,
                        panelClass: 'red-snackbar'
                    });
                    break;
            }
        });
    }


}
