import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'options',
  templateUrl: './options.component.html',
  styleUrls: ['./options.component.scss']
})
export class OptionsComponent {

  constructor( private router: Router){}

  routeToBanner(type: string){
    this.router.navigate(["materials/banner/create"], {queryParams: {contentType: type}})
  }

}
