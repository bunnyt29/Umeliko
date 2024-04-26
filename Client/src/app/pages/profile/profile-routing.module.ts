import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DetailsComponent } from './components/details/details.component';
import { EditComponent } from './components/edit/edit.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DetailsMineComponent } from "./components/details-mine/details-mine.component";

const routes: Routes = [
  {
    path: '',
    component: DetailsComponent
  },
  {
    path: 'mine',
    component: DetailsMineComponent
  },
  {
    path: 'edit',
    component: EditComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
