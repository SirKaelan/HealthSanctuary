import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators';
import buildQuery from 'odata-query';
import { environment } from '../../environments/environment';

import { Workout } from './workout-models/Workout';
import { Search } from './workout-models/Search';

interface ODataResponse {
  '@odata.context': string;
  '@odata.count': number;
  value: Workout[];
}

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {
  private url = `${environment.healthSanctuaryApiRoot}/api/workouts`;

  constructor(private http: HttpClient) { }

  getWorkouts(search: Search): Observable<Workout[]> {
    const query = this.buildWorkoutsQuery(search);
    return this.http.get<ODataResponse>(`${this.url}${query}`)
      .pipe(
        map(res => res.value)
      );
  }

  getWorkout(workoutId: number): Observable<Workout> {
    return this.http.get<Workout>(`${this.url}/${workoutId}`);
  }

  private buildWorkoutsQuery(search: Search) {
    return buildQuery({
      count: true,
      filter: {
        Title: {
          contains: search.term
        }
      }
    });
  }
}
