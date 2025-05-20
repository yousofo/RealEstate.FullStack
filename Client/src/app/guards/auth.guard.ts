import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  let authService = inject(AuthService);
  let router = inject(Router);

  if (authService.isAuthenticated()) {
    switch (route.routeConfig?.path) {
      case 'sign-up':
        router.navigate(['/']);
        return false;
      default:
        return true;
    }
  } else {
    switch (route.routeConfig?.path) {
      case 'add-property':
        router.navigate(['/']);
        return false;
      default:
        return true;
    }
  }
};
