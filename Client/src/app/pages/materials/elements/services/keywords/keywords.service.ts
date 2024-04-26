import { Injectable } from '@angular/core';
import { forkJoin, Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

import { environment } from "../../../../../../environments/environment";


@Injectable({
  providedIn: 'root'
})

export class KeywordsService {
  private keywordsPath = environment.apiUrl + 'keywords';
  constructor(private http: HttpClient) { }

  create(id: string, keywords: string[]): Observable<any[]> {
    const requests = keywords.map(keyword => {
      const body = {
        id: 0,
        name: keyword,
        bannerId: id
      };
      return this.http.post(this.keywordsPath, body);
    });

    return forkJoin(requests);
  }
}
