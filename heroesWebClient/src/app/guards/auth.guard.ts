import { inject, Inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { SharedDataService } from '../services/shared-data.service';

export const authGuard: CanActivateFn = (route, state) => {

  const _route = inject(Router);
  var data = inject(SharedDataService);
  if (data.getData('isLoginFlag')) {
    return true;
  } else {
    localStorage.setItem('redirectUrl', state.url);
    _route.navigate(['/login']);
    return false;
  }
};
