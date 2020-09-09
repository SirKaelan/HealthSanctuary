import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, merge } from 'rxjs';
import { debounceTime, map, switchMap, distinctUntilChanged, tap } from 'rxjs/operators';

import { ExerciseService } from 'src/app/exercises/exercise.service';
import { Exercise } from '../workout-models/Exercise';
import { WorkoutService } from '../workout.service';
import { Workout } from '../workout-models/Workout';

@Component({
  selector: 'app-workout-create',
  templateUrl: './workout-create.component.html',
  styleUrls: ['./workout-create.component.css']
})
export class WorkoutCreateComponent implements OnInit {
  private exercises: Observable<Exercise[]>;
  private workout = new FormGroup({
    title: new FormControl('', [Validators.required]),
    duration: new FormControl('', [Validators.required, Validators.min(1)]),
    description: new FormControl('', [Validators.maxLength(500)]),
    videoLink: new FormControl('', [Validators.maxLength(100)]),
    exercises: new FormArray([
      new FormGroup({
        exerciseId: new FormControl(''),
        name: new FormControl('', [Validators.required, Validators.maxLength(50)]),
        sets: new FormControl('', [Validators.required, Validators.min(1)]),
        reps: new FormControl('', [Validators.required, Validators.min(1)]),
      })
    ]),
  });

  constructor(private workoutService: WorkoutService, private exerciseService: ExerciseService, private router: Router) { }

  ngOnInit() {
    this.exercises = merge(
      this.exerciseService.getExercises('', 10),
      (this.workout.get('exercises') as FormArray)
      .valueChanges
      .pipe(
        map((arr: Exercise[]) => arr.length),
        distinctUntilChanged(),
        switchMap(_ => merge(...(this.workout.get('exercises') as FormArray)
            .controls
            .map(control => control.valueChanges))
          .pipe(
            debounceTime(100),
            map(value => {
              const exercise = value.name;
              if (typeof exercise === 'string') {
                return exercise;
              } else {
                return '';
              }
            }),
            switchMap(name => this.exerciseService.getExercises(name, 10))
          ))
      )
    );
  }

  onAddExercise() {
    const exercises = this.workout.get('exercises') as FormArray;
    exercises.push(new FormGroup({
      exerciseId: new FormControl(''),
      name: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      sets: new FormControl('', [Validators.required, Validators.min(1)]),
      reps: new FormControl('', [Validators.required, Validators.min(1)]),
    }));
  }

  onExerciseDelete(index: number) {
    const exercises = this.workout.get('exercises') as FormArray;
    exercises.removeAt(index);
  }

  displayExercise(exercise: Exercise) {
    if (exercise) {
      return exercise.name;
    }
  }

  onSubmit() {
    const formValue = this.workout.value;
    const workout: Workout = {
      workoutId: 0,
      title: formValue.title,
      description: formValue.description,
      duration: formValue.duration,
      videoLink: formValue.videoLink,
      workoutExercises: formValue
        .exercises
        .filter(x => typeof x.name !== 'string')
        .map(x => ({
          exerciseId: x.name.exerciseId,
          sets: x.sets,
          reps: x.reps,
        }))
    };

    this.workoutService
      .createWorkout(workout)
      .subscribe(res => this.router.navigateByUrl('/workouts'));
  }

}
