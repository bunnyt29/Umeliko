import { Component, Input, OnInit } from '@angular/core';

import { Material } from "../../../../../models/Material";
import {Resource} from "../../../../../../../shared/models/Resource";

@Component({
  selector: 'all-resources',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.scss']
})

export class AllComponent implements OnInit{
  @Input() resources!: Array<Resource>;

  ngOnInit(): void {

  }

  extractFileName(url: string): string {
    const segments = url.split('/');
    let fileName = segments.pop() || ``;

    const dotIndex = fileName.lastIndexOf('.');
    if (dotIndex !== -1) {
      fileName = fileName.substring(0, dotIndex);
    }

    return fileName;
  }
}
