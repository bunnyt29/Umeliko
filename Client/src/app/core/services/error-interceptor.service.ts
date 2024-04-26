import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, retry, throwError, shareReplay } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor{

  constructor(
    private toastrService : ToastrService,
    private router: Router
  ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      retry(1),
      catchError((err: any) => {
        let message = "";
        if (err.status === 401) {
          message = "Неуспешен опит за вход!";
          this.router.navigate(['/auth/login']);
        }
        else if (err.status === 404) {
          message = "Търсеният от вас резултат не е намерен.";
        }
        else if (err.status === 400) {
          message = "Заявката, която искате да извършите е невалидна.";
        }
        else {
          message = "Възникна проблем! Моля, опитайте отново по-късно.";
        }

        this.toastrService.error(message)

        return throwError(() => err);
      }),
      shareReplay(1)
    )
  }

}
