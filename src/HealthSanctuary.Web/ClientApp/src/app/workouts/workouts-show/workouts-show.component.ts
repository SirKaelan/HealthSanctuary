import { Component, OnInit, Input } from '@angular/core';

import { Workout } from '../workout-models/Workout';

@Component({
  selector: 'app-workouts-show',
  templateUrl: './workouts-show.component.html',
  styleUrls: ['./workouts-show.component.css']
})
export class WorkoutsShowComponent implements OnInit {
  @Input() private workouts: Workout[] = [];

  constructor() { }

  ngOnInit() {
  }

}
