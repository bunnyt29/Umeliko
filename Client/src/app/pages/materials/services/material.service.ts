import {HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Material } from '../models/Material';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {
  private materialPath = environment.apiUrl + 'materials';
  constructor(private http: HttpClient) { }

  create(contentType: any): Observable<Material>{
    return this.http.post<Material>(this.materialPath, contentType);
  }

  getMaterial(materialId: any) : Observable<any>{
    return this.http.get<any>(this.materialPath + '/' + materialId);
  }

  getMineMaterials(): Observable<any> {
    let params = new HttpParams()
      .set('sortBy', 'createdOn')
      .set('order', 'desc');

    return this.http.get<any>(this.materialPath + '/' + 'mine', { params });
  }

  getMinePublicMaterials(): Observable<any> {
    return this.http.get<any>(this.materialPath + '/' + 'mine' + '?stateType=4');
  }

  getMaterials(params?: string): Observable<any> {
    return this.http.get<any>(this.materialPath + '/' + 'all' + params);
  }

  getMaterialsByCreator(id: string): Observable<any> {
    return this.http.get<any>(this.materialPath + '/' + 'byCreator/' + id);
  }

  getPendingMaterials(): Observable<any> {
    let params = new HttpParams()
      .set('stateType', '2')
      .set('sortBy', 'createdOn')
      .set('order', 'desc');

    return this.http.get<any>(this.materialPath + '/' + 'pending', { params });
  }

  preview(materialId: any) : Observable<any>{
    return this.http.get<any>(this.materialPath + '/' + materialId + '/preview');
  }

  changeVisibility(id: string): Observable<any> {
    return this.http.put(this.materialPath + '/' + id + '/changeVisibility', null);
  }

  approve(id: string): Observable<any> {
    return this.http.put(this.materialPath + '/' + id + '/approve', null);
  }

  disapprove(data: any): Observable<any> {
    return this.http.put(this.materialPath + '/disapprove', data);
  }

  search(queryParams: string): Observable<any> {
    return this.http.get<any>(this.materialPath + '/' + 'search' + '?' + queryParams);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(this.materialPath + '/' + id);
  }
}
