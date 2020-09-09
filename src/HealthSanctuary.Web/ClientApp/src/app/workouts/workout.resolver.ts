import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

import { Workout } from './workout-models/Workout';
import { WorkoutService } from './workout.service';

@Injectable({
  providedIn: 'root'
})
export class WorkoutResolver implements Resolve<Workout> {
  constructor(private workoutService: WorkoutService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Workout | Observable<Workout> | Promise<Workout> {
    const workoutId = parseInt(route.paramMap.get('workoutId'), 10);
    return this.workoutService.getWorkout(workoutId);
  }

}
