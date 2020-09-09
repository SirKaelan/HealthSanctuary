import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import buildQuery from 'odata-query';

import { environment } from 'src/environments/environment';
import { Exercise } from './exercise-models/Exercise';

export interface ExercisesODataResponse {
  '@odata.context': string;
  '@odata.count': number;
  value: Exercise[];
}

@Injectable({
  providedIn: 'root'
})
export class ExerciseService {
  private url = `${environment.healthSanctuaryApiRoot}/api/exercises`;

  constructor(private http: HttpClient) { }

  getExercises(name: string, top: number = 10): Observable<Exercise[]> {
    const query = this.buildNameQuery(name, top);
    return this.http.get<ExercisesODataResponse>(`${this.url}${query}`)
      .pipe(
        map(res => res.value)
      );
  }

  private buildNameQuery(name: string, top: number) {
    return buildQuery({
      top,
      filter: {
        Name: {
          contains: name
        }
      }
    });
  }

}
