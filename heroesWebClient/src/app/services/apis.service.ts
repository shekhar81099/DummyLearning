import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ApisService {
  http = inject(HttpClient);
  apiUrl = environment.apiUrl;

  constructor() {}
  async getHeroes() {
    this.http
      .get( this.apiUrl +'/SuperHero/GetSuperHeroes')
      .subscribe(
        (data) => {
          console.log(data);
         return data;
        },
        (error) => {
          console.log(error);
          return null
        }
      );
  }
}
