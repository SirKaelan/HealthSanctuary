import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import buildQuery from 'odata-query';
import { environment } from '../../environments/environment';

import { Workout } from './workout-models/Workout';
import { Search } from './workout-models/Search';
import { AuthService } from '../auth/auth.service';

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

  constructor(private http: HttpClient, private authService: AuthService) { }

  createWorkout(workout: Workout): Observable<Workout> {
    return this.authService.accessToken$.pipe(
      switchMap(token => {
        const headers = {
          Authorization: `Bearer ${token}`
        };
        return this.http.post<Workout>(this.url, workout, { headers });
      })
    );
  }

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

  updateWorkout(workout: Workout): Observable<void> {
    return this.authService.accessToken$.pipe(
      switchMap(token => {
        const headers = {
          Authorization: `Bearer ${token}`
        };
        return this.http.put<void>(`${this.url}/${workout.workoutId}`, workout, { headers });
      })
    );
  }

  deleteWorkout(workoutId: number): Observable<void> {
    return this.authService.accessToken$.pipe(
      switchMap(token => {
        const headers = {
          Authorization: `Bearer ${token}`
        };
        return this.http.delete<void>(`${this.url}/${workoutId}`, { headers });
      })
    );
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
