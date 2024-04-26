import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HeroComponent } from './components/hero/hero.component';
import { HomeComponent } from './components/home/home.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { FeaturesComponent } from './components/features/features.component';
import { PopularMaterialsComponent } from './components/popular-materials/popular-materials.component';
import { QuestionsAndAnswersComponent } from './components/questions-and-answers/questions-and-answers.component';
import { FooterComponent } from './components/footer/footer.component';
import { SharedModule } from "../../shared/shared.module";


@NgModule({
  declarations: [
    HomeComponent,
    HeroComponent,
    AboutUsComponent,
    FeaturesComponent,
    PopularMaterialsComponent,
    QuestionsAndAnswersComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ]
})
export class HomeModule { }
