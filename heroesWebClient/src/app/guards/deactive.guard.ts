import { CanDeactivateFn } from '@angular/router';
import { Observable } from 'rxjs';

export interface CanComponentDeactivate {
  canDeactivate: () => boolean | Observable<boolean> | Promise<boolean>;
}

export const deactiveGuard: CanDeactivateFn<unknown> = (component, currentRoute, currentState, nextState) => {
  const canDeactivateComponent = component as CanComponentDeactivate;
  return canDeactivateComponent.canDeactivate ? canDeactivateComponent.canDeactivate() : true;
};
