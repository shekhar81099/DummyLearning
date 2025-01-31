import { inject, Inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const isAuthenticated = true;
  const _route = inject(Router);
  if (isAuthenticated) {
    return true;
  } else {
    _route.navigate(['/login']);
    return false;
  }
};
