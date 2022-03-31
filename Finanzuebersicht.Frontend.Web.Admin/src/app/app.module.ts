import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { KrzLayoutModule, KrzRestService } from '@krz/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiComponentsModule } from './components/ui/ui-components.module';
import { AdminAdLoginModule } from './model/admin-login-system/admin-ad-login/admin-ad-login.module';
import { SessionsServicesModule } from './model/admin-session-management/sessions/sessions-services.module';
import { BackendCoreAuthService } from './services/backend/authentication/backend-core-auth.service';
import { BackendCoreService } from './services/backend/backend-core.service';
import { BackendSsoService } from './services/backend/backend-sso.service';
import { AppEventModule } from './services/event/app-event.module';
import { PendingChangesGuard } from './tools/guards/pending-changes-guard';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppEventModule,
    KrzLayoutModule,
    UiComponentsModule,
    SessionsServicesModule,
    AdminAdLoginModule,
    AppRoutingModule,
  ],
  providers: [
    KrzRestService,
    BackendCoreService,
    BackendCoreAuthService,
    BackendSsoService,
    PendingChangesGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
