import { Component, OnInit, Input, Output } from '@angular/core';

import { Workout } from '../workout-models/Workout';
import { WorkoutService } from '../workout.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-workout-card',
  templateUrl: './workout-card.component.html',
  styleUrls: ['./workout-card.component.css']
})
export class WorkoutCardComponent implements OnInit {
  @Input() workout: Workout;
  @Input() currentUserId: string;
  @Output() refresh = new Subject();

  constructor(private workoutService: WorkoutService) { }

  ngOnInit() {
  }

  private isOwner() {
    return this.currentUserId && this.workout.ownerId === this.currentUserId;
  }

  private onDelete() {
    this.workoutService
      .deleteWorkout(this.workout.workoutId)
      .subscribe(_ => this.refresh.next());
  }

}
