import { Component, OnInit } from '@angular/core';

import { Search } from '../workout-models/Search';
import { Workout } from '../workout-models/Workout';
import { WorkoutService } from '../workout.service';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-workouts-layout',
  templateUrl: './workouts-layout.component.html',
  styleUrls: ['./workouts-layout.component.css']
})
export class WorkoutsLayoutComponent implements OnInit {
  private currentUserId = '';
  private workouts: Workout[] = [];
  private defaultSearch: Search = {
    term: '',
  };

  constructor(private workoutService: WorkoutService, private authService: AuthService) { }

  ngOnInit() {
    this.workoutService.getWorkouts(this.defaultSearch).subscribe(workouts => this.workouts = workouts);
    this.authService.userId$.subscribe(userId => this.currentUserId = userId);
  }

  onSearch(search: Search) {
    this.workoutService.getWorkouts(search).subscribe(workouts => this.workouts = workouts);
  }

  onRefresh() {
    this.workoutService.getWorkouts(this.defaultSearch).subscribe(workouts => this.workouts = workouts);
  }

}
