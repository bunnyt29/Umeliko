import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from "@angular/common/http";

import { ErrorInterceptorService } from "./services/error-interceptor.service";
import { TokenInterceptorService } from "./services/token-interceptor.service";
import { AuthGuardService } from "./services/auth-guard.service";
import { LoaderService } from './services/loader.service';
import { LoaderInterceptor } from './services/loader.interceptor';

@NgModule({
  imports: [
    CommonModule,
  ],
  providers: [
    ErrorInterceptorService,
    TokenInterceptorService,
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
    LoaderService,
    { 
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    }
  ]
})
export class CoreModule { }
