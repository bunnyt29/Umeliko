import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularEditorModule } from "@kolkov/angular-editor";

import { ElementsRoutingModule } from './elements-routing.module';
import { MaterialTitleComponent } from './components/material-title/material-title.component';
import { HeroComponent } from './components/hero/hero.component';
import { InteractionToolbarComponent } from './components/interaction-toolbar/interaction-toolbar.component';
import { MaterialMetadataComponent } from './components/material-metadata/material-metadata.component';
import { CreateComponent as ResourcesCreateComponent } from './components/resources/components/create/create.component';
import { CreateComponent as KeywordsCreateComponent} from './components/keywords/components/create/create.component';
import { AllComponent as ResourcesAllComponent} from './components/resources/components/all/all.component';
import { AllComponent as KeywordsAllComponent} from './components/keywords/components/all/all.component';
import { EditComponent as EditResources } from './components/resources/components/edit/edit.component';
import { SharedModule } from "../../../shared/shared.module";
import { EditorComponent } from './components/editor/editor.component';
import { CommentsComponent } from './components/comments/comments.component';

@NgModule({
  declarations: [
    MaterialTitleComponent,
    HeroComponent,
    InteractionToolbarComponent,
    MaterialMetadataComponent,
    ResourcesCreateComponent,
    ResourcesAllComponent,
    KeywordsCreateComponent,
    KeywordsAllComponent,
    EditorComponent,
    CommentsComponent,
    EditResources
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ElementsRoutingModule,
    SharedModule,
    AngularEditorModule,
  ],
  exports: [
    MaterialTitleComponent,
    ResourcesCreateComponent,
    ResourcesAllComponent,
    KeywordsCreateComponent,
    KeywordsAllComponent,
    HeroComponent,
    InteractionToolbarComponent,
    MaterialMetadataComponent,
    EditorComponent,
    CommentsComponent,
    EditResources
  ]
})
export class ElementsModule { }
