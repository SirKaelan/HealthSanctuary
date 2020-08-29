import { Component, OnInit, Input } from '@angular/core';
import { Workout } from '../workout-models/Workout';

@Component({
  selector: 'app-workout-card',
  templateUrl: './workout-card.component.html',
  styleUrls: ['./workout-card.component.css']
})
export class WorkoutCardComponent implements OnInit {
  @Input() workout: Workout;

  constructor() { }

  ngOnInit() {
    console.log(this.workout);
  }

}
