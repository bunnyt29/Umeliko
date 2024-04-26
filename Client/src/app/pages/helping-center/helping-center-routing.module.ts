import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WhoAreWeComponent } from './who-are-we/who-are-we.component';
import { WhatIsMaterialComponent } from './what-is-material/what-is-material.component';
import { WhatIsBannerComponent } from './what-is-banner/what-is-banner.component';
import { CreatorRoleComponent } from './creator-role/creator-role.component';
import { HelpingCenterLayoutComponent } from './helping-center-layout/helping-center-layout.component';


const routes: Routes = [
  { 
    path: '', 
    component: HelpingCenterLayoutComponent,
    children: [
      { 
        path: '', 
        redirectTo: 'who-are-we', 
        pathMatch: 'full' 
      },
      { 
        path: 'who-are-we',
        component: WhoAreWeComponent
      },
      {
       path: 'creator-role', 
       component: CreatorRoleComponent 
      },
      {
        path: 'what-is-banner', 
        component: WhatIsBannerComponent 
       },
       {
        path: 'what-is-material', 
        component: WhatIsMaterialComponent 
       },
      
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HelpingCenterRoutingModule { }
