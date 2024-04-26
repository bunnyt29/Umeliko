import {Component, Input, OnInit, ChangeDetectorRef, AfterViewInit} from '@angular/core';

import { Material } from '../../../models/Material';

@Component({
  selector: 'hero',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.scss']
})

export class HeroComponent implements AfterViewInit {

  @Input() material!: Material;

  constructor (private cd: ChangeDetectorRef) {}

  ngAfterViewInit(): void {
    this.cd.detectChanges();
    
  }
}
