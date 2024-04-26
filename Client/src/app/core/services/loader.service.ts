import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  private loadingRequestCount = 0;
  public isLoading = new BehaviorSubject<boolean>(false);

  show() {
    this.loadingRequestCount++;
    this.isLoading.next(true);
  }

  hide() {
    this.loadingRequestCount--;
    if (this.loadingRequestCount <= 0) {
      this.loadingRequestCount = 0; // Prevent negative count
      this.isLoading.next(false);
    }
  }
}
