import {Component, OnInit} from '@angular/core';
import {Lesson} from "../../models/lesson";
import {Material} from "../../../../models/Material";
import {Vote} from "../../../../../../shared/models/Vote";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {MaterialService} from "../../../../services/material.service";
import {switchMap, tap} from "rxjs/operators";

@Component({
  selector: 'preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.scss']
})
export class PreviewComponent implements OnInit{
  id!: string;
  lesson!: Lesson;
  material!: Material;
  videoUrl!: string;

  constructor(
    private route: ActivatedRoute,
    private materialService: MaterialService
  ) { }

  ngOnInit(): void {
    this.fetchData();

    console.log(this.material.lesson.resources)
  }

  fetchData(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    })

    this.materialService.getMaterial(this.id).subscribe( res => {
      this.material = res;
      this.videoUrl = res.lesson.fileUrl;
    })
  }
}
