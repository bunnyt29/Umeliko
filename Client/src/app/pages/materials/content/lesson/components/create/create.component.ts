import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';

import { LessonService } from '../../services/lesson.service';
import { EditorComponent } from "../../../../elements/components/editor/editor.component";
import { FileService } from "../../../../../../core/services/file.service";
import { CreateComponent as CreateResourcesComponent } from "../../../../elements/components/resources/components/create/create.component";
import { ResourcesService } from "../../../../elements/services/resources/resources.service";

@Component({
  selector: 'create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})

export class CreateComponent implements OnInit {
  @ViewChild(EditorComponent) child: any;
  @ViewChild(CreateResourcesComponent) child1: any;
  materialId!: string;
  lessonForm!: FormGroup;
  materialData!: {};
  video: FormData = new FormData();
  videoUrl!: string;
  lessonId!: string;
  progress: number = 0;
  showProcessingMessage: boolean = false;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private lessonService: LessonService,
    private fileService: FileService,
    private resourcesService: ResourcesService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.materialId = params['materialId'];
    })

    this.lessonForm = this.fb.group({
      'content': [''],
      'fileUrl': ['', Validators.required]
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
          console.log(this.video)
          this.lessonForm.patchValue({
            fileUrl: this.videoUrl
          });
          this.progress = 100;
        }
      });
    }
  }

  create(): void {
    this.lessonForm.patchValue({
      content: this.child.htmlContent
    });

    let materialId: string = this.materialId;
    this.materialData = { ...this.lessonForm.value, materialId };

    this.lessonService.create(this.materialData).subscribe(res =>{
      this.lessonId = res.lessonId;

      for (let resource of this.child1.resourcesArray) {
        resource.containerId = this.lessonId;
        resource.containerType = "Lesson";
        this.resourcesService.create(resource).subscribe( () => {})
      }

      this.toastr.success("Урокът е успешно създаден!");

      this.router.navigate(["/profile/dashboard"]);
    })
  }
}
