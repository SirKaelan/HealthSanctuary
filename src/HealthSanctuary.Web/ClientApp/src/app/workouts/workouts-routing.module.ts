import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WorkoutsLayoutComponent } from './workouts-layout/workouts-layout.component';

const routes: Routes = [
  { path: '', component: WorkoutsLayoutComponent },
  { path: 'workouts', component: WorkoutsLayoutComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkoutsRoutingModule { }
