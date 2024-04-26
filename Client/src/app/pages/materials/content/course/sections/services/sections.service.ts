import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SectionsService {
  private coursePath: string = environment.apiUrl + 'sections';

  constructor(private http: HttpClient) { }

  create(data:any): Observable<any> {
    return this.http.post<any>(this.coursePath, data);
  }
}
