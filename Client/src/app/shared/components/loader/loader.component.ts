import { Component, ViewEncapsulation } from '@angular/core';
import { LoaderService } from 'src/app/core/services/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss'],
  encapsulation: ViewEncapsulation.ShadowDom
})
export class LoaderComponent {
  isLoading: boolean = false;

  constructor(
    private loaderService: LoaderService
  ) 
  {
    this.loaderService.isLoading.subscribe((v) => {
      this.isLoading = v;
    });
  }
}
