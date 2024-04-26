import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CookieService } from "ngx-cookie-service";

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { AuthLayoutComponent } from "./components/auth-layout/auth-layout.component";
import { AuthService } from "./services/auth.service";
import { AuthGuardService } from "../../core/services/auth-guard.service";
import { TokenInterceptorService } from "../../core/services/token-interceptor.service";
import { ErrorInterceptorService } from "../../core/services/error-interceptor.service";
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { ConfirmEmailComponent } from './components/confirm-email/confirm-email.component';
import { ChangeEmailComponent } from './components/change-email/change-email.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import {JWT_OPTIONS, JwtHelperService} from "@auth0/angular-jwt";

@NgModule({
  declarations: [
    AuthLayoutComponent,
    LoginComponent,
    RegisterComponent,
    ChangePasswordComponent,
    ConfirmEmailComponent,
    ChangeEmailComponent,
    ForgotPasswordComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    },
    CookieService
  ],
  exports: [
    AuthLayoutComponent
  ]
})
export class AuthModule { }
