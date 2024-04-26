import { Component, HostListener, Input, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { Material } from "../../models/Material";
import { Banner } from "../../banner/models/Banner";
import { MaterialService } from "../../services/material.service";
import { ProfileService } from "../../../profile/services/profile.service";
import { Creator } from "../../../../shared/models/Creator";
import { FollowService } from "../../../../shared/services/follow-activity/follow.service";

@Component({
  selector: 'all',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.scss']
})

export class AllComponent implements OnInit {
  @Input() material!: Material;
  materials: Array<Material> = [];
  creators: Array<Creator> = [];
  creator!: Creator;
  creatorId: any;
  banner!: Banner;
  level!: string;
  contentType!: string;
  public navigationMenuStyles: any;

  constructor(
    private router: Router,
    private materialService: MaterialService,
    private profileService: ProfileService,
    private followService: FollowService
  ){
    this.updateMyStyles(window.innerWidth);
  }

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

  ngOnInit(): void{
    this.fetchMaterials();
    this.fetchCreators();
  }

  fetchMaterials(category?: string): void {
    let queryParams = category ? `?category=${category}` : '';

    this.materialService.getMaterials(queryParams).subscribe(data => {
      this.materials = data.materials;

      for (const material of this.materials) {

        if (material.banner.level == 'option1') {
          material.banner.level = 'За всеки';
        }
        else if (material.banner.level == 'option2') {
          material.banner.level = 'Имат малки познания';
        }
        else {
          material.banner.level = 'За професионалисти';
        }

        if (material.contentType == 'Article') {
          this.contentType = 'статия';
        }
        else if (material.contentType == 'Lesson') {
          this.contentType = 'урок';
        }
        else {
          this.contentType = 'курс';
        }
      }
    })
  }

  fetchCreators(): void {
    this.profileService.getProfiles().subscribe( res => {
      this.creators = res.creators;
      // this.materialsByCreator = res.materials.filter((m: Material) => m.id !== this.id);
    })
  }

  getDetails(contentType: string, materialId: string): void {
    let path: string = '/materials/' + contentType.toLowerCase();
    this.router.navigate([path, materialId]);
  }

  viewCreatorProfile(creatorId: string): void {
    this.creatorId = creatorId;
    this.profileService.getProfile(creatorId).subscribe( () => {
      this.router.navigate(['/profile'], { queryParams: { creatorId: creatorId } })
    })
  }

  follow(creatorId: string): void {
    let data = { 'creatorId': creatorId };
    this.followService.create(data).subscribe( () => {
      this.creator.isFollowed = true;
    });
  }

  unfollow(creatorId: string): void {
    this.followService.delete(creatorId).subscribe( () => {
    });
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any): void  {
    this.updateMyStyles(event.target.innerWidth);
  }

  updateMyStyles(innerWidth: number): void  {
    if (innerWidth < 768) {
      this.navigationMenuStyles = {
        'position': 'fixed',
        'top': '0',
        'left': '0',
        'z-index': '1000'
      };
    }
    else if(innerWidth > 768 && innerWidth < 1200){
      this.navigationMenuStyles = {
        'position': 'fixed',
        'top': '0',
        'left': '220px',
        'z-index': '1000'
      };
    }
    else if(innerWidth > 1200 && innerWidth < 1500){
      this.navigationMenuStyles = {
        'position': 'fixed',
        'top': '0',
        'left': '350px',
        'z-index': '1000'
      };
    }
    else if(innerWidth > 1500 && innerWidth < 1800){
      this.navigationMenuStyles = {
        'position': 'fixed',
        'top': '0',
        'left': '420px',
        'z-index': '1000'
      };
    }
    else {
      this.navigationMenuStyles = {
        'position': 'fixed',
        'top': '0',
        'left': '550px',
        'z-index': '1000'
      };
    }
  }
}
