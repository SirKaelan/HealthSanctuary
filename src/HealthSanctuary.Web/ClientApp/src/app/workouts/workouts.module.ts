import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { WorkoutsRoutingModule } from './workouts-routing.module';
import { WorkoutCardComponent } from './workout-card/workout-card.component';
import { WorkoutsShowComponent } from './workouts-show/workouts-show.component';
import { WorkoutSearchComponent } from './workout-search/workout-search.component';
import { WorkoutsLayoutComponent } from './workouts-layout/workouts-layout.component';


@NgModule({
  declarations: [WorkoutCardComponent, WorkoutsShowComponent, WorkoutSearchComponent, WorkoutsLayoutComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    NoopAnimationsModule,
    WorkoutsRoutingModule,
  ]
})
export class WorkoutsModule { }
