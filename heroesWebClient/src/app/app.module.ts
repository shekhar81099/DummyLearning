import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { heroesComponent } from './heroes/heroes.component';
import { MatListModule } from '@angular/material/list';
import { VillainsComponent } from './villains/villains.component';
import { HeroesDetailComponent } from './heroes-detail/heroes-detail.component';
import { VillainsDetailComponent } from './villains-detail/villains-detail.component';
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
  provideHttpClient,
} from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { GlobalErrorHandlerService } from './services/global-error-handler.service';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from './interceptors/auth.service';
import { MatchesComponent } from './matches/matches.component';
import { XssComponent } from './xss/xss.component';
import { HighliterDirective } from './directive/highliter.directive';
import { customComp } from './customComp/heroescopy/heroescopy.component';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    heroesComponent,
    VillainsComponent,
    HeroesDetailComponent,
    VillainsDetailComponent,
    LoginComponent,
    RegisterComponent,
    MatchesComponent,
    XssComponent,
    customComp,
    HighliterDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule,
    MatListModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
  ],
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(),
    { provide: ErrorHandler, useClass: GlobalErrorHandlerService },
    { provide: HTTP_INTERCEPTORS, useClass: AuthService, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
