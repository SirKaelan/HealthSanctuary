import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { Search } from '../workout-models/Search';

@Component({
  selector: 'app-workout-search',
  templateUrl: './workout-search.component.html',
  styleUrls: ['./workout-search.component.css']
})
export class WorkoutSearchComponent implements OnInit {
  @Output() search = new EventEmitter<Search>();

  term = '';

  constructor() { }

  ngOnInit() {
  }

  onSearch() {
    this.search.next({
      term: this.term
    });
  }
}
