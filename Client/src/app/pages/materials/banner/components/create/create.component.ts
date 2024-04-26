import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ToastrService } from "ngx-toastr";

import { BannerService } from "../../services/banner.service";
import { MaterialService } from "../../../services/material.service";
import { FileService } from "../../../../../core/services/file.service";
import { Banner } from "../../models/Banner";
import { CreateComponent as CreateKeywordsComponent } from "../../../elements/components/keywords/components/create/create.component";
import { KeywordsService } from "../../../elements/services/keywords/keywords.service";

@Component({
  selector: 'create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})

export class CreateComponent implements OnInit {
  @ViewChild(CreateKeywordsComponent) child: any;
  bannerForm!: FormGroup;
  selectedCategory: string = '';
  coverImageUrl: any = 'https://res.cloudinary.com/dxqy3jgj3/image/upload/v1708158184/banner-default-cover-image_npxap1.svg';
  materialData = { contentType: '' };
  bannerData = {};
  materialId = {};
  keywords: string[] = [];
  banner!: Banner;
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
    private bannerService: BannerService,
    private toastrService: ToastrService,
    private route: ActivatedRoute,
    private router: Router,
    private materialService: MaterialService,
    private fileService: FileService,
    private keywordsService: KeywordsService
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.materialData.contentType = params['contentType'];
      switch (this.materialData.contentType) {
        case "1":
          this.contentType = "статия";
          break;
        case "2":
          this.contentType = "урок";
          break;
        case "3":
          this.contentType = "курс";
          break;
      }
    })

    this.bannerForm = this.fb.group({
      'coverImageUrl': [this.coverImageUrl, Validators.required],
      'title': ['', [Validators.required, Validators.maxLength(50)]],
      'description': ['', [Validators.required, Validators.maxLength(300)]],
      'category': ['', Validators.required],
      'level': ['', Validators.required],
      'materialId': ['']
    })
  }

  isFormControlInvalid(controlName: string): boolean {
    const control = this.bannerForm.get(controlName);
    return !!(control && control.invalid && (control.dirty || control.touched));
  }

  create(): void {
    this.materialService.create(this.materialData).subscribe(res => {
      this.materialId = {...res};
      this.bannerData = {...this.bannerForm.value, ...res};

      this.bannerService.create(this.bannerData).subscribe( res => {
        let bannerId = res.bannerId;
        this.keywords = this.child.keywords;

        this.keywordsService.create(bannerId, this.keywords).subscribe( res => {
          this.toastrService.success("Успешно добавени ключови думи.");
        });

        this.navigateToMaterial(this.materialData.contentType);
      })
    })
  }

  navigateToMaterial(contentType: string) {
    switch (contentType) {
      case "1":
        this.materialData.contentType = 'article';
        break;
      case "2":
        this.materialData.contentType = 'lesson';
        break;
      case "3":
        this.materialData.contentType = 'course';
        break
    }

    let path = '/materials/' + this.materialData.contentType + '/create'
    this.router.navigate([path], { queryParams: this.materialId });
  }

  triggerInput(): void {
    const fileInput = document.getElementById('fileInput');
    if (fileInput) {
      fileInput.click();
    }
    else {
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
