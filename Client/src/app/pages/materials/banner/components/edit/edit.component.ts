import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Banner } from '../../models/Banner';
import { BannerService } from '../../services/banner.service';
import { FileService } from "../../../../../core/services/file.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})

export class EditComponent implements OnInit {
  bannerForm!: FormGroup;
  banner!: Banner;
  coverImageUrl!: string;
  materialId!: string;
  contentType!: string;
  hover: boolean = false;
  categories: string[] = [
    "Здраве",
    "Продуктивност",
    "Спорт",
    "Технологии",
    "Софтуерна разработка",
    "Изкуствен интелект",
    "Образование",
    "История",
    "Изкуство",
    "Наука",
    "Култура",
    "Природа",
    "Животни",
    "Икономика",
    "Туризъм",
    "Политика"
  ]

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private bannerService: BannerService,
    private fileService: FileService,
    private toastrService: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void{
    this.route.queryParams.subscribe(params => {
      this.contentType = params['contentType'];
      this.materialId = params['materialId'];
    });

    this.fetchData();
  }

  fetchData(): void {
    this.bannerService.get(this.materialId).subscribe(res => {
      this.banner = res;
      this.bannerForm = this.fb.group({
        'id': [this.banner.id],
        'coverImageUrl': [this.banner.coverImageUrl],
        'title': [this.banner.title, Validators.maxLength(50)],
        'description': [this.banner.description, Validators.maxLength(300)],
        'category': [this.banner.category],
        'level': [this.banner.level],
        'materialId': [this.banner.materialId]
      })
    })
  }

  editBanner(): void {
    this.bannerService.edit(this.bannerForm.value).subscribe(() => {
      let path = '/materials/' + this.contentType.toLowerCase() + '/edit';
      this.router.navigate([path] ,{ queryParams: {materialId: this.materialId } });
    });
  }

  triggerInput(): void {
    const fileInput = document.getElementById('fileInput');

    if (fileInput) {
      fileInput.click();
    }
  }

  uploadImage(event: any): void {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement.files && inputElement.files[0]) {
      const file = inputElement.files[0];
      if (event.target.files && event.target.files[0]) {
        const formData = this.fileService.readURL(event, file);
        this.fileService.uploadImage(formData).subscribe( res => {
          this.coverImageUrl = res.imageUrl;
          this.bannerForm.patchValue({
            coverImageUrl: this.coverImageUrl
          });

          this.toastrService.success('Успешно качен файл!');
        })
      }
    }

    inputElement.value = "";
  }

  get title() {
    return this.bannerForm.get('title');
  }

  get description() {
    return this.bannerForm.get('description');
  }

  get category() {
    return this.bannerForm.get('category');
  }

  get level() {
    return this.bannerForm.get('level');
  }
}
