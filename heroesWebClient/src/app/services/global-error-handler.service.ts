import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class GlobalErrorHandlerService implements ErrorHandler {
  constructor() {}
  router = inject(Router) ;

  handleError(error: any): void {
    if (error instanceof HttpErrorResponse) {
          console.error('HTTP Error:', error.status, error.message);
      if (error.status === 401) {
          this.router.navigate(['/login']); // Redirect to login on unauthorized error
      }
    } else {
      console.error('An unexpected error occurred:', error);
    }
  }
}
