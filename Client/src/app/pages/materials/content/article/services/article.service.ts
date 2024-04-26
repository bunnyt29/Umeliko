import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Article } from '../models/Article';

@Injectable({
  providedIn: 'root'
})

export class ArticleService {
  private articlePath: string = environment.apiUrl + 'articles';

  constructor(private http: HttpClient) { }

  create(data:any): Observable<any> {
    return this.http.post<any>(this.articlePath, data);
  }

  get(materialId: string): Observable<Article> {
    return this.http.get<Article>(this.articlePath + '/' + materialId);
  }

  edit(data: any): Observable<any> {
    return this.http.put(this.articlePath, data);
  }
}
