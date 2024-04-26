import {ChangeDetectorRef, Component, Input, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { FileService } from 'src/app/core/services/file.service';
import { Material } from 'src/app/pages/materials/models/Material';
import { ResourcesService } from '../../../../services/resources/resources.service';
import { ToastrService } from 'ngx-toastr';
import { Resource } from 'src/app/shared/models/Resource';

@Component({
  selector: 'edit-resources',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  @Input() uploadedResources: Array<Resource> = [];
  resources: FormData[] = [];
  resourceForm!: FormGroup;
  resourcesArrayToUpload: Array<Resource> = [];
  videoUrl!: string;

  constructor(
    private resourcesService: ResourcesService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.resourceForm = this.fb.group({
      'fileUrl': ['', Validators.required],
    })
  }

  extractFileName(url: string): string {
    const segments = url.split('/');
    const fileName = segments.pop() || '';

    return fileName;
  }

  deleteResource(resource: any){
    if (resource.articleId != null) {
      this.resourcesService.deleteToArticle(resource.articleId, resource.id).subscribe();
    } else if (resource.lessonId) {
      this.resourcesService.deleteToLesson(resource.lessonId, resource.id).subscribe();
    }
  }
}



