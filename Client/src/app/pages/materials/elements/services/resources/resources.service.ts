import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { environment } from "../../../../../../environments/environment";
import { Resource } from "../../../../../shared/models/Resource";

@Injectable({
  providedIn: 'root'
})

export class ResourcesService {
  private resourcesPath = environment.apiUrl + 'resources';
  constructor(private http: HttpClient) { }

  create(data: any): Observable<Resource> {
    return this.http.post<Resource>(this.resourcesPath, data);
  }

  deleteToArticle(articleId: string, resourceId: number): Observable<any> {
    return this.http.delete(this.resourcesPath + '/' + 'ToArticle' + '/' + articleId + '/' + resourceId);
  }

  deleteToLesson(lessonId: string, resourceId: number): Observable<any> {
    return this.http.delete(this.resourcesPath + '/' + 'ToLesson' + '/' + lessonId + '/' + resourceId);
  }
}
