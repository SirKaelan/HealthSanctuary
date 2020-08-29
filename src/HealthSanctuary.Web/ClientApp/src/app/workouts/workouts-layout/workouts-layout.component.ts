import { Component, OnInit } from '@angular/core';

import { Search } from '../workout-models/Search';
import { Workout } from '../workout-models/Workout';
import { WorkoutService } from '../workout.service';

@Component({
  selector: 'app-workouts-layout',
  templateUrl: './workouts-layout.component.html',
  styleUrls: ['./workouts-layout.component.css']
})
export class WorkoutsLayoutComponent implements OnInit {
  private workouts: Workout[] = [];
  private defaultSearch: Search = {
    term: '',
  };

  constructor(private workoutService: WorkoutService) { }

  ngOnInit() {
    this.workoutService.getWorkouts(this.defaultSearch).subscribe(workouts => this.workouts = workouts);
  }

  onSearch(search: Search) {
    this.workoutService.getWorkouts(search).subscribe(workouts => this.workouts = workouts);
  }

}
