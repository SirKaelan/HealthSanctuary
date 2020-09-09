import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatAutocompleteModule, MatProgressSpinnerModule } from '@angular/material';

import { WorkoutsRoutingModule } from './workouts-routing.module';
import { WorkoutCardComponent } from './workout-card/workout-card.component';
import { WorkoutsShowComponent } from './workouts-show/workouts-show.component';
import { WorkoutSearchComponent } from './workout-search/workout-search.component';
import { WorkoutsLayoutComponent } from './workouts-layout/workouts-layout.component';
import { WorkoutCreateComponent } from './workout-create/workout-create.component';
import { EmbedPipe } from './embed.pipe';


@NgModule({
  declarations: [
    WorkoutCardComponent,
    WorkoutsShowComponent,
    WorkoutSearchComponent,
    WorkoutsLayoutComponent,
    WorkoutCreateComponent,
    EmbedPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatAutocompleteModule,
    MatProgressSpinnerModule,
    WorkoutsRoutingModule,
  ]
})
export class WorkoutsModule { }
