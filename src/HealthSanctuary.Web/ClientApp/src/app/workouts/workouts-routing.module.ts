import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WorkoutsLayoutComponent } from './workouts-layout/workouts-layout.component';
import { WorkoutCreateComponent } from './workout-create/workout-create.component';
import { AuthGuard } from '../shared/auth.guard';
import { WorkoutEditComponent } from './workout-edit/workout-edit.component';
import { WorkoutResolver } from './workout.resolver';
import { WorkoutShowComponent } from './workout-show/workout-show.component';

const routes: Routes = [
  { path: '', component: WorkoutsLayoutComponent },
  { path: 'workouts', component: WorkoutsLayoutComponent },
  { path: 'workout-create', component: WorkoutCreateComponent, canActivate: [AuthGuard] },
  { path: 'workouts/:workoutId', component: WorkoutShowComponent, resolve: { workout: WorkoutResolver } },
  { path: 'workouts/:workoutId/edit', component: WorkoutEditComponent, canActivate: [AuthGuard], resolve: { workout: WorkoutResolver} },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkoutsRoutingModule { }
