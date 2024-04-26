import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { BannerRoutingModule } from './banner-routing.module';
import { CreateComponent } from "./components/create/create.component";
import { EditComponent } from "./components/edit/edit.component";
import { BannerService } from "./services/banner.service";
import { ElementsModule } from "../elements/elements.module";
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    CreateComponent,
    EditComponent
  ],
    imports: [
      CommonModule,
      RouterModule,
      BannerRoutingModule,
      FormsModule,
      ReactiveFormsModule,
      SharedModule,
      ElementsModule
    ],
  providers: [
    BannerService
  ]
})
export class BannerModule { }
