import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Router, RouterStateSnapshot} from '@angular/router';

import { AuthService } from '../../pages/auth/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService{

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/auth/login']);
      return false;
    }

    const roles = route.data['roles'] as Array<string> || [];
    const userRoles = this.authService.getRoles() || [];
    if (roles.length === 0 || userRoles.some(role => roles.includes(role))) {
      return true;
    } else {
      this.router.navigate(['/access-denied']);
      return false;
    }
  }

}
