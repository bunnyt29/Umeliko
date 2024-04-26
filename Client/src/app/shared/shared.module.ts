import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VgCoreModule } from '@videogular/ngx-videogular/core';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';
import { ReactiveFormsModule } from "@angular/forms";
import { RouterLink } from "@angular/router";

import { VgPlayerComponent } from './components/vg-player/vg-player.component';
import { NavigationMenuComponent } from './components/navigation-menu/navigation-menu.component';
import { CustomConfirmDialogComponent } from './components/custom-confirm-dialog/custom-confirm-dialog.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ModalComponent } from './components/modal/modal.component';
import { CreatedForComponent } from './components/created-for/created-for.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { LoaderComponent } from './components/loader/loader.component';

@NgModule({
  declarations: [
    VgPlayerComponent,
    NavigationMenuComponent,
    CustomConfirmDialogComponent,
    PageNotFoundComponent,
    ModalComponent,
    CreatedForComponent,
    AccessDeniedComponent,
    LoaderComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule,
    VgCoreModule,
    RouterLink
  ],
  exports: [
    VgPlayerComponent,
    NavigationMenuComponent,
    CustomConfirmDialogComponent,
    ModalComponent,
    CreatedForComponent,
    LoaderComponent
  ]
})
export class SharedModule { }
