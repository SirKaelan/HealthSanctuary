import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators';
import buildQuery from 'odata-query';

import { Workout } from './workout-models/Workout';

interface ODataResponse {
  '@odata.context': string;
  '@odata.count': number;
  value: Workout[];
}

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {
  private url = 'https://localhost:5001/api/workouts';

  constructor(private http: HttpClient) { }

  getWorkouts(): Observable<Workout[]> {
    const query = buildQuery({ });
    console.log('Query', query);
    return this.http.get<ODataResponse>(`${this.url}${query}`)
      .pipe(
        map(res => res.value)
      );
  }

  getWorkout(workoutId: number): Observable<Workout> {
    return this.http.get<Workout>(`${this.url}/${workoutId}`);
  }
}
