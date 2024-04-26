import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AllComponent } from "./components/all/all.component";
import { AuthGuardService } from "../../core/services/auth-guard.service";

const routes: Routes = [
  {
    path: 'all',
    canActivate: [AuthGuardService],
    component: AllComponent,
  },
  {
    path: 'banner',
    canActivate: [AuthGuardService],
    loadChildren: () => import('../../../app/pages/materials/banner/banner.module').then(m => m.BannerModule)
  },
  {
    path: 'article',
    canActivate: [AuthGuardService],
    loadChildren: () => import('../../../app/pages/materials/content/article/article.module').then(m => m.ArticleModule)
  },
  {
    path: 'lesson',
    canActivate: [AuthGuardService],
    loadChildren: () => import('../../../app/pages/materials/content/lesson/lesson.module').then(m => m.LessonModule)
  },
  {
    path: 'course',
    canActivate: [AuthGuardService],
    loadChildren: () => import('../../../app/pages/materials/content/course/course.module').then(m => m.CourseModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MaterialsRoutingModule { }
