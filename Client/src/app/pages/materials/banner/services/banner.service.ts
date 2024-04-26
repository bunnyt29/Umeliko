import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Banner } from '../models/Banner';

@Injectable({
  providedIn: 'root'
})

export class BannerService {
  private bannerPath: string = environment.apiUrl + 'banners';
  constructor(private http: HttpClient) { }

    create(data:any): Observable<any> {
      return this.http.post<any>(this.bannerPath, data);
    }

    get(materialId: string): Observable<Banner> {
      return this.http.get<Banner>(this.bannerPath + '/' + materialId);
    }

    edit(data: any): Observable<any> {
      return this.http.put(this.bannerPath, data);
    }
}
