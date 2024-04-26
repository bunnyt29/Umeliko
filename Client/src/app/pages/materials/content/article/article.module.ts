import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ArticleRoutingModule } from './article-routing.module';
import { CreateComponent } from './components/create/create.component';
import { DetailsComponent } from './components/details/details.component';
import { EditComponent } from './components/edit/edit.component';
import { ElementsModule } from "../../elements/elements.module";
import { SharedModule } from "../../../../shared/shared.module";
import { PreviewComponent } from './components/preview/preview.component';


@NgModule({
  declarations: [
    CreateComponent,
    DetailsComponent,
    EditComponent,
    PreviewComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ArticleRoutingModule,
    SharedModule,
    ElementsModule
  ],
})
export class ArticleModule { }
