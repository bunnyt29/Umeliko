import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Creator } from '../../../shared/models/Creator';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private userPath = environment.apiUrl + 'creators';
  constructor(private http: HttpClient) { }

  getProfile(creatorId: string):Observable<any>{
    return this.http.get<any>(this.userPath + '/' + creatorId);
  }
  getMineProfile():Observable<any>{
    return this.http.get<any>(this.userPath);
  }
  getProfiles():Observable<any>{
    return this.http.get<any>(this.userPath + '/popular');
  }
  editProfile(id:string, data:any){
    return this.http.put(this.userPath + '/' + id, data);
  }

}
