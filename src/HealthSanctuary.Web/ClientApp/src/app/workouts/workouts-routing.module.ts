import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WorkoutsLayoutComponent } from './workouts-layout/workouts-layout.component';
import { WorkoutCreateComponent } from './workout-create/workout-create.component';
import { AuthGuard } from '../shared/auth.guard';

const routes: Routes = [
  { path: '', component: WorkoutsLayoutComponent },
  { path: 'workouts', component: WorkoutsLayoutComponent },
  { path: 'workout-create', component: WorkoutCreateComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkoutsRoutingModule { }
