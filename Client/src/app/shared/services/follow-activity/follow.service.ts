import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

import { environment } from "../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})

export class FollowService {
  private followPath = environment.apiUrl + 'follows';
  constructor(private http: HttpClient) { }

  create(data: any): Observable<any>{
    return this.http.post(this.followPath + '/' + data, null);
  }

  delete(data: any): Observable<any>{
    return this.http.delete(this.followPath + '/' + data);
  }
}
