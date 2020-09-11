import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Workout } from '../workout-models/Workout';
import { AuthService } from 'src/app/auth/auth.service';
import { WorkoutService } from '../workout.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-workout-show',
  templateUrl: './workout-show.component.html',
  styleUrls: ['./workout-show.component.css']
})
export class WorkoutShowComponent implements OnInit, OnDestroy {
  workout: Workout;
  currentUserId: string;

  userIdSubscription: Subscription;

  constructor(
    private authService: AuthService,
    private workoutService: WorkoutService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.activatedRoute.data.subscribe(({ workout }: { workout: Workout }) => this.workout = workout);

    this.userIdSubscription = this.authService.userId$.subscribe(userId => this.currentUserId = userId);
  }

  ngOnDestroy() {
    this.userIdSubscription.unsubscribe();
  }

  isOwner() {
    console.log('userId', this.currentUserId);
    console.log('ownerId', this.workout.ownerId);
    return this.currentUserId && this.workout.ownerId === this.currentUserId;
  }

  onEdit() {
    this.router.navigateByUrl(`workouts/${this.workout.workoutId}/edit`);
  }

  onDelete() {
    this.workoutService
      .deleteWorkout(this.workout.workoutId)
      .subscribe(_ => this.router.navigateByUrl('workouts'));
  }

}
