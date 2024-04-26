import { Injectable } from '@angular/core';
import {AuthService} from "../../pages/auth/services/auth.service";

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  constructor(private authService: AuthService) {}

  getCurrentUser() {
    return this.authService.getToken();
  }
}
