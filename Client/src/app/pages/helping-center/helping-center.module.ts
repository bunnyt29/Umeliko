import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { HelpingCenterRoutingModule } from './helping-center-routing.module';
import { WhoAreWeComponent } from './who-are-we/who-are-we.component';
import { WhatIsMaterialComponent } from './what-is-material/what-is-material.component';
import { WhatIsBannerComponent } from './what-is-banner/what-is-banner.component';
import { CreatorRoleComponent } from './creator-role/creator-role.component';
import { HelpingCenterLayoutComponent } from './helping-center-layout/helping-center-layout.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HomeModule } from '../home/home.module';


@NgModule({
  declarations: [
    WhoAreWeComponent,
    WhatIsMaterialComponent,
    WhatIsBannerComponent,
    CreatorRoleComponent,
    HelpingCenterLayoutComponent
  ],
  imports: [
    CommonModule,
    HelpingCenterRoutingModule,
    RouterModule,
    SharedModule,
    HomeModule
  ]
})
export class HelpingCenterModule { }
