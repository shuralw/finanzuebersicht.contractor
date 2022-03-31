import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SessionInformationService } from './services/session-information.service';
import { SessionService } from './session.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    SessionInformationService,
    SessionService,
  ]
})
export class SessionsServicesModule { }
