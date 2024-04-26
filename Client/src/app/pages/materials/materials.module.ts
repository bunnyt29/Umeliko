import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialsRoutingModule } from './materials-routing.module';
import { BannerModule } from "./banner/banner.module";
import { ArticleModule } from "./content/article/article.module";
import { AllComponent } from './components/all/all.component';
import { LessonModule } from "./content/lesson/lesson.module";
import { CourseModule } from "./content/course/course.module";
import { ElementsModule } from "./elements/elements.module";
import { SharedModule } from "../../shared/shared.module";


@NgModule({
  declarations: [
    AllComponent
  ],
  imports: [
    CommonModule,
    MaterialsRoutingModule,
    BannerModule,
    ArticleModule,
    LessonModule,
    CourseModule,
    ElementsModule,
    SharedModule
  ]
})

export class MaterialsModule { }
