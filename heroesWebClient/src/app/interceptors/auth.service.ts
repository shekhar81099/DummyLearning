import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService implements HttpInterceptor {
  apiUrl = environment.apiUrl;
  constructor() {}
  intercept( req: HttpRequest<any>, next: HttpHandler ): Observable<HttpEvent<any>> {
    const token = sessionStorage.getItem('token');
    console.log(req.method);
    let header: any = {
      'Content-Type': 'application/json',
    };
    if (!req.url.includes('/login')) {
      header = {
        ...header,
        Authorization: token ? `Bearer ${token}` : '',
      };
    }

    const authReq = req.clone({
      url: this.apiUrl + req.url,
      setHeaders: header,
    });

    return next.handle(authReq);
  }
}
