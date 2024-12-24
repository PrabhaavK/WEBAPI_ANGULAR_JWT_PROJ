import { CanDeactivateFn } from '@angular/router';

export const unsavedataGuard: CanDeactivateFn<unknown> = (component, currentRoute, currentState, nextState) => {
  return true;
};
