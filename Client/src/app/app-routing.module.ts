import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'
import {PageNotFoundComponent} from "./shared/components/page-not-found/page-not-found.component";
import {AuthGuardService} from "./core/services/auth-guard.service";
import {AccessDeniedComponent} from "./shared/components/access-denied/access-denied.component";

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadChildren: () => import('../app/pages/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'auth',
    loadChildren: () => import('../app/pages/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'profile',
    canActivate: [AuthGuardService],
    loadChildren: () => import('../app/pages/profile/profile.module').then(m => m.ProfileModule)
  },
  {
    path: 'materials',
    canActivate: [AuthGuardService],
    loadChildren: () => import('../app/pages/materials/materials.module').then(m => m.MaterialsModule)
  },
  {
    path: 'admin',
    canActivate: [AuthGuardService],
    data: { roles: ['Administrator'] },
    loadChildren: () => import('../app/pages/admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'helping-center',
    canActivate: [AuthGuardService],
    loadChildren: () => import('../app/pages/helping-center/helping-center.module').then(m => m.HelpingCenterModule)
  },
  {
    path: 'access-denied', component: AccessDeniedComponent
  },
  {
    path: '**', component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
