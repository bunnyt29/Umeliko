import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from "@angular/router";

import { Lesson } from '../../models/lesson';
import { LessonService } from '../../services/lesson.service';
import { EditorComponent } from "../../../../elements/components/editor/editor.component";
import { Material } from "../../../../models/Material";
import { FileService } from "../../../../../../core/services/file.service";
import { ResourcesService } from 'src/app/pages/materials/elements/services/resources/resources.service';
import { EditComponent as ЕditResourcesComponent } from 'src/app/pages/materials/elements/components/resources/components/edit/edit.component';
import { ToastrService } from 'ngx-toastr';
import { Resource } from 'src/app/shared/models/Resource';
import {
  CreateComponent as CreateResourcesComponent
} from "../../../../elements/components/resources/components/create/create.component";

@Component({
  selector: 'edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})

export class EditComponent implements OnInit {
  @ViewChild(EditorComponent) child: any;
  @ViewChild(CreateResourcesComponent) child1: any;

  id!:string;
  material!:Material;
  materialId!: string;
  lesson!: Lesson;
  lessonForm!: FormGroup;
  video: FormData = new FormData();
  videoUrl!: string;
  progress: number = 0;
  showProcessingMessage: boolean = false;
  uploadedResources!: Array<Resource>;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private lessonService: LessonService,
    private fileService: FileService,
    private resourcesService: ResourcesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.materialId = params['materialId'];
    });

    this.fetchLesson();
  }

  fetchLesson(): void {
    this.lessonService.getLesson(this.materialId).subscribe(res => {
      this.lesson = res;
      this.uploadedResources = res.resources;
      this.videoUrl = this.lesson.fileUrl;

      this.lessonForm = this.fb.group({
        "id": [this.lesson.id, Validators.required],
        "content": [this.lesson.content, Validators.required],
        "fileUrl": [this.lesson.fileUrl, Validators.required],
        "materialId": [this.materialId, Validators.required]
      });
    });
  }

  addVideo(event: any): void {
    let inputElement = event.target as HTMLInputElement;

    if (inputElement.files && inputElement.files[0]) {
      let file = inputElement.files[0];

      this.video.append('video', file);

      this.fileService.uploadVideo(this.video).subscribe(event => {
        if (event.status === 'progress') {
          this.progress = event.message;
          if(this.progress == 100){
            this.showProcessingMessage = true;
          }
        } else if (event.status === 'completed') {
          this.showProcessingMessage = false;
          this.videoUrl = event.responseBody.videoUrl;
          this.lessonForm.patchValue({
            fileUrl: this.videoUrl
          });
          this.progress = 100;
        }
      });
    }
  }

   editLesson(): void {
    this.lessonForm.patchValue({
      "content": this.child.htmlContent
    });

    this.lessonService.edit(this.lessonForm.value).subscribe(res => {
      for (let resource of this.child1.resourcesArray) {
        resource.containerId = this.lesson.id;
        resource.containerType = "Lesson";
        console.log('id'+this.lesson.id)
        this.resourcesService.create(resource).subscribe( () => {})
      }
    });
    
    this.router.navigate(['/profile/dashboard']);
  }
}
