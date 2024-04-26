import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

import { environment } from "../../../../../../environments/environment";
import { Vote } from "../../../../../shared/models/Vote";

@Injectable({
  providedIn: 'root'
})

export class VotesService {
  private votesPath: string = environment.apiUrl + 'votes';
  constructor(private http:HttpClient) { }

  create(data: any): Observable<Vote> {
    return this.http.post<Vote>(this.votesPath, data);
  }

  get(materialId: string): Observable<Vote> {
    return this.http.get<Vote>(this.votesPath + '/' + materialId );
  }

  delete(data: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: data
    };
    return this.http.request('delete', this.votesPath, httpOptions);
  }
}
