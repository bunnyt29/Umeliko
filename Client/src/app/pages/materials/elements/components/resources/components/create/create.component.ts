import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { FileService } from "../../../../../../../core/services/file.service";
import { ResourcesService } from '../../../../services/resources/resources.service';
import {Resource} from "../../../../../../../shared/models/Resource";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'create-resources',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})

export class CreateComponent implements OnInit  {
  resources: FormData[] = [];
  resourceForm!: FormGroup;
  resourcesArray: Array<Resource> = [];
  videoUrl!: string;

  constructor(
    private fileService: FileService,
    private resourcesService: ResourcesService,
    private toastrService: ToastrService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.resourceForm = this.fb.group({
      'fileUrl': ['', Validators.required],
    })
  }

  addResources(event: any): void {
    let inputElement = event.target as HTMLInputElement;
    if (inputElement.files && inputElement.files.length > 0) {
      let file;
      for (let i = 0; i < inputElement.files.length; i++) {
        file = inputElement.files[i];
        let formData = new FormData();
        const modifiedFileName = this.modifyFileName(file.name);

        this.toastrService.info('Файлът се качва...');

        formData.append('raw', file, modifiedFileName);

        this.resources.push(formData);
      }

      for (let resource of this.resources) {
        this.fileService.uploadRaw(resource).subscribe(res => {
          this.resourceForm.patchValue({
            'fileUrl': res.rawUrl,
          });

          this.toastrService.success('Успешно качен файл!');

          this.resourcesArray.push(this.resourceForm.value);
        })
      }
    }
  }

  modifyFileName(fileName: string): string {
    return fileName.replace(/\s+/g, '-');
  }

  extractFileName(url: string): string {
    const segments = url.split('/');
    let fileName = segments.pop() || '';
    return fileName;
  }

  deleteResource(index: number): void {
    this.resourcesArray.splice(index, 1);
  }
}
