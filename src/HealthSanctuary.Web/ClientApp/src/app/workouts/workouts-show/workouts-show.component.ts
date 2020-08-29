import { Component, OnInit } from '@angular/core';

import { WorkoutService } from '../workout.service';
import { Workout } from '../workout-models/Workout';

@Component({
  selector: 'app-workouts-show',
  templateUrl: './workouts-show.component.html',
  styleUrls: ['./workouts-show.component.css']
})
export class WorkoutsShowComponent implements OnInit {
  private workouts: Workout[] = [];

  constructor(private workoutService: WorkoutService) { }

  ngOnInit() {
    this.workoutService.getWorkouts().subscribe(workouts => {
      console.log(workouts);
      this.workouts = workouts;
    });
  }

}
