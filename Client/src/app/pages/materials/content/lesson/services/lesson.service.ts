import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lesson } from '../models/lesson';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  private lessonPath = environment.apiUrl + 'lessons';
  constructor(private http: HttpClient) { }

  create(data:any): Observable<any>{
    return this.http.post(this.lessonPath, data);
  }

  getLesson(id:string) : Observable<Lesson>{
    return this.http.get<Lesson>(this.lessonPath + '/' + id);
  }

  edit(data: any){
    return this.http.put(this.lessonPath, data);
  }
}
