import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

import { environment } from "../../../../environments/environment";
import {Router} from "@angular/router";
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
   providedIn: 'root'
})
export class AuthService {
  private authPath: string = environment.apiUrl + 'identity/';

  constructor(
    private router: Router,
    private jwtHelper: JwtHelperService,
    private http: HttpClient,
    private cookieService: CookieService
  ) { }

  register(data: any): Observable<any> {
    return this.http.post(this.authPath + 'register', data);
  }

  login(data: any): Observable<any> {
    return this.http.post(this.authPath + 'login', data);
  }

  logout(): void {
    this.cookieService.delete('auth');
  }

  confirmEmail(userId: string, token: string): Observable<any>  {
    return this.http.post<any>(this.authPath + 'confirmEmail', { "userId": userId, "token": token });
  }

  changeEmail(email: any): Observable<any> {
    return this.http.put(this.authPath + 'changeEmail', email);
  }
  changePassword(data: any): Observable<any> {
      return this.http.put(this.authPath + 'changePassword', data);
  }

  saveToken(token: string): void {
    this.cookieService.set('auth', token);
  }

  getToken(): string {
    return this.cookieService.get('auth');
  }

  getRoles(): string[] {
    const token = this.getToken();
    const decodedToken = this.jwtHelper.decodeToken(token);
    return decodedToken ? [decodedToken.role] : [];
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  isAdmin(): boolean {
    const roles = this.getRoles();
    return roles.includes('Administrator');
  }
}
