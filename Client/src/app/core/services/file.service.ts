import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpEventType, HttpHeaders, HttpRequest } from "@angular/common/http";
import { map, Observable } from "rxjs";

import { environment } from "../../../environments/environment";
import {ToastrService} from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class FileService {
  private filePath = environment.apiUrl + 'files';

  constructor(
    private http: HttpClient,
    private toastrService: ToastrService) {}

  uploadImage(image: FormData): Observable<any> {
    return this.http.post<any>(this.filePath + '/' + 'uploadImage', image, { headers: {"Upload": " "} });
  }

  readURL(event: any, file: File): any {
    let reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);

    const sanitizedFileName = file.name.replace(/\s+/g, '');
    const blob = file.slice(0, file.size, file.type);
    const newFile = new File([blob], sanitizedFileName, { type: file.type });

    this.toastrService.info('Файлът се качва...');

    const formData = new FormData();
    formData.append('image', newFile);

    return formData;
  }

  uploadVideo(video: FormData): Observable<any> {
    const req = new HttpRequest('POST', `${this.filePath}/uploadVideo`, video, {
      reportProgress: true,
      responseType: 'json',
      headers: new HttpHeaders({ "Upload": " " })
    });

    return this.http.request(req).pipe(
      map(event => this.getEventMessage(event))
    );
  }

  private getEventMessage(event: HttpEvent<any>): any {
    switch (event.type) {
      case HttpEventType.UploadProgress:
        const percentDone = event.total ? Math.round(100 * event.loaded / event.total) : 0;
        return { status: 'progress', message: percentDone };
      case HttpEventType.Response:
        return { status: 'completed', responseBody: event.body };
      default:
        return { status: 'unknown', message: `Unhandled event: ${event.type}` };
    }
  }

  uploadRaw(raw: FormData): Observable<any> {
    return this.http.post<any>(this.filePath + '/' + 'uploadRaw', raw, { headers: {"Upload": " "} })
  }

}
