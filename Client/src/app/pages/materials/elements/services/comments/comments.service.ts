import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Resource } from 'src/app/shared/models/Resource';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  private commentsPath = environment.apiUrl + 'comments';
  constructor(private http: HttpClient) { }

  create(data: any): Observable<any> {
    return this.http.post<any>(this.commentsPath, data);
  }

  delete(materialId: string, commentId: string): Observable<any> {
    return this.http.delete(this.commentsPath + '/' + materialId + '/' + commentId);
  }
}
