import {Component, Input, OnInit} from '@angular/core';

import { Material } from "../../../../../models/Material";

@Component({
  selector: 'all-keywords',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.scss']
})

export class AllComponent implements OnInit {
  @Input() material!: Material;

  ngOnInit(): void {
    console.log(this.material)
  }

  convertKeyword(keyword: any): string {
    return keyword.toLowerCase().replace(/\s+/g, '-');
  }
}
