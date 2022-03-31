import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppEvent, AppEventType } from './dtos/app-event';

@Injectable()
export class AppEventService {

  eventEmitter = new EventEmitter<AppEvent>();

  constructor() { }

  public newSuccess(message: string, uniqueEventCode?: string): void {
    this.eventEmitter.emit({
      eventType: AppEventType.Success,
      message,
      uniqueEventCode
    });
  }

  public newWarning(message: string, uniqueEventCode?: string): void {
    this.eventEmitter.emit({
      eventType: AppEventType.Warning,
      message,
      uniqueEventCode
    });
  }

  public newError(message: string, uniqueEventCode?: string): void {
    this.eventEmitter.emit({
      eventType: AppEventType.Error,
      message,
      uniqueEventCode
    });
  }

  public newDefaultBackendError(message?: string): void {
    const errorMessage = (message) ? message : 'Es ist ein Fehler bei der Kommunikation mit dem Server aufgetreten.';

    this.eventEmitter.emit({
      eventType: AppEventType.Error,
      message: errorMessage
    });
  }

  public onEventOccurred(): Observable<AppEvent> {
    return this.eventEmitter.pipe();
  }

}
