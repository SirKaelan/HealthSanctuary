import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

import { WorkoutsRoutingModule } from './workouts-routing.module';
import { WorkoutCardComponent } from './workout-card/workout-card.component';
import { WorkoutsShowComponent } from './workouts-show/workouts-show.component';


@NgModule({
  declarations: [WorkoutCardComponent, WorkoutsShowComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    WorkoutsRoutingModule,
  ]
})
export class WorkoutsModule { }
