import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { ProfileRoutingModule } from './profile-routing.module';
import { DetailsComponent } from "./components/details/details.component";
import { EditComponent } from "./components/edit/edit.component";
import { ProfileService } from "./services/profile.service";
import { AuthModule } from '../auth/auth.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { OptionsComponent } from './components/dashboard/options/options.component';
import { BannerModule } from '../materials/banner/banner.module';
import { MaterialsModule } from '../materials/materials.module';
import { ProfileMaterialsComponent } from './components/dashboard/profile-materials/profile-materials.component';
import { SharedModule } from "../../shared/shared.module";
import { AuthGuardService } from "../../core/services/auth-guard.service";
import { DetailsMineComponent } from './components/details-mine/details-mine.component';
import { StateTypeToStringPipe } from './pipes/state-type-to-string.pipe';
import { ContentTypeToStringPipe } from './pipes/content-type-to-string.pipe';
import { ApprovedMaterialsComponent } from './components/dashboard/approved-materials/approved-materials.component';

@NgModule({
  declarations: [
    DetailsComponent,
    EditComponent,
    DashboardComponent,
    OptionsComponent,
    ProfileMaterialsComponent,
    DetailsMineComponent,
    StateTypeToStringPipe,
    ContentTypeToStringPipe,
    ApprovedMaterialsComponent,
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    AuthModule,
    FormsModule,
    ReactiveFormsModule,
    BannerModule,
    MaterialsModule,
    SharedModule
  ],
  providers: [
    ProfileService,
    AuthGuardService
  ]
})

export class ProfileModule { }
