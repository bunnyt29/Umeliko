import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import { Article } from '../../models/Article';
import { MaterialService } from "../../../../services/material.service";
import { Material } from "../../../../models/Material";
import { Vote } from "../../../../../../shared/models/Vote";

@Component({
  selector: 'preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.scss']
})
export class PreviewComponent implements OnInit{
  id!:string;
  material!: Material;
  article!: Article;
  materialId = {};

  constructor(
    private materialService: MaterialService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    })

    this.materialService.preview(this.id).subscribe( res => {
      this.material = res;
    })
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
