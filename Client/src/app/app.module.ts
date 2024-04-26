import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AngularEditorModule } from "@kolkov/angular-editor";

import { CoreModule } from "./core/core.module";
import { AuthModule } from "./pages/auth/auth.module";
import { ProfileModule } from "./pages/profile/profile.module";
import { SharedModule } from './shared/shared.module';
import { HomeModule } from './pages/home/home.module';
import { MaterialsModule } from "./pages/materials/materials.module";
import { HelpingCenterModule } from './pages/helping-center/helping-center.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NoopAnimationsModule,
    BrowserAnimationsModule,
    FormsModule,
    AngularEditorModule,
    CoreModule,
    AuthModule,
    ProfileModule,
    ToastrModule.forRoot(),
    SharedModule,
    HomeModule,
    MaterialsModule,
    HelpingCenterModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
