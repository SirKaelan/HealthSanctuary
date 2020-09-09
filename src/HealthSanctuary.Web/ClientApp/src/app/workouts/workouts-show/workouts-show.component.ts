import { Component, OnInit, Input, Output } from '@angular/core';
import { Subject } from 'rxjs';

import { Workout } from '../workout-models/Workout';

@Component({
  selector: 'app-workouts-show',
  templateUrl: './workouts-show.component.html',
  styleUrls: ['./workouts-show.component.css']
})
export class WorkoutsShowComponent implements OnInit {
  @Input() private workouts: Workout[] = [];
  @Input() private currentUserId = '';
  @Output() refresh = new Subject();

  constructor() { }

  ngOnInit() {
  }

  onRefresh() {
    this.refresh.next();
  }

}
