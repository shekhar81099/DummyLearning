import { Options } from './../../../node_modules/ngx-bootstrap/positioning/models/index.d';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApisService {
  http = inject(HttpClient);

  constructor() {}
  getHeroes() {
    return this.http.get('SuperHero/GetSuperHeroes', {
      observe: 'response',
    });
  }
  loginUser(user: any) {
    return this.http.get(
      `Auth/login?user=${user.username}&password=${user.password}`,
      {
        observe: 'response',
      }
    );
  }
}
