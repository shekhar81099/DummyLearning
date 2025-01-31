import { NgModule } from '@angular/core';
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
import {MatListModule} from '@angular/material/list';
import { VillainsComponent } from './villains/villains.component';
import { HeroesDetailComponent } from './heroes-detail/heroes-detail.component';
import { VillainsDetailComponent } from './villains-detail/villains-detail.component';
import { HttpClient, HttpClientModule, provideHttpClient } from '@angular/common/http';
import { LoginComponent } from './login/login.component';

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule,
    MatListModule

  ],
  providers: [provideAnimationsAsync(), HttpClient, provideHttpClient()],
  bootstrap: [AppComponent],
})
export class AppModule {}
