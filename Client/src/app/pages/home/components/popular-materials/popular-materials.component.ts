import { Component, OnInit } from '@angular/core';

import { Material } from 'src/app/pages/materials/models/Material';
import { MaterialService } from 'src/app/pages/materials/services/material.service';

@Component({
  selector: 'popular-materials',
  templateUrl: './popular-materials.component.html',
  styleUrls: ['./popular-materials.component.scss']
})

export class PopularMaterialsComponent implements OnInit {
  materials: Array<Material> = [];
  constructor(
    private materialService: MaterialService
  ) { }

  ngOnInit(): void {
    this.fetchMaterials();
  }

  fetchMaterials(): void{
    this.materialService.getMaterials('').subscribe(data => {
      this.materials = data.materials;
    })
  }
}
