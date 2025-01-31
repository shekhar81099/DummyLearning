import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { heroesComponent } from './heroes/heroes.component';
import { HeroesDetailComponent } from './heroes-detail/heroes-detail.component';
import { VillainsComponent } from './villains/villains.component';
import { VillainsDetailComponent } from './villains-detail/villains-detail.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent   },
  { path: 'login', component: LoginComponent    },
  { path: 'heroes', component: heroesComponent , canActivate: [authGuard]  },
  { path: 'heroesDetails', component: HeroesDetailComponent  , canActivate: [authGuard] },
  { path: 'villains', component: VillainsComponent, canActivate: [authGuard] },
  { path: 'villainsDetails', component: VillainsDetailComponent , canActivate: [authGuard]  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
