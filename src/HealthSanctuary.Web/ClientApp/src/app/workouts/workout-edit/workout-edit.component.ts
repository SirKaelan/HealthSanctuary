import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable, merge } from 'rxjs';
import { debounceTime, map, switchMap, distinctUntilChanged, tap } from 'rxjs/operators';

import { ExerciseService } from 'src/app/exercises/exercise.service';
import { Exercise } from '../workout-models/Exercise';
import { WorkoutService } from '../workout.service';
import { Workout } from '../workout-models/Workout';
import { WorkoutExercise } from '../workout-models/WorkoutExercise';

@Component({
  selector: 'app-workout-edit',
  templateUrl: './workout-edit.component.html',
  styleUrls: ['./workout-edit.component.css']
})
export class WorkoutEditComponent implements OnInit {
  private exercises: Observable<Exercise[]>;
  private workout: FormGroup;

  constructor(
    private workoutService: WorkoutService,
    private exerciseService: ExerciseService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.data.subscribe(({ workout }: { workout: Workout }) => {
      this.workout = new FormGroup({
        workoutId: new FormControl(workout.workoutId),
        title: new FormControl(workout.title || '', [Validators.required]),
        duration: new FormControl(workout.duration || '', [Validators.required, Validators.min(1)]),
        description: new FormControl(workout.description || '', [Validators.maxLength(500)]),
        videoLink: new FormControl(workout.videoLink || '', [Validators.maxLength(100)]),
        exercises: new FormArray(workout.workoutExercises.map(exercise => this.createExerciseGroup(exercise))),
      });
    });

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

  createExerciseGroup(exercise: WorkoutExercise) {
    return new FormGroup({
      exercise: new FormControl(exercise.exercise),
      name: new FormControl(exercise.exercise.name, [Validators.required, Validators.maxLength(50)]),
      sets: new FormControl(exercise.sets, [Validators.required, Validators.min(1)]),
      reps: new FormControl(exercise.reps, [Validators.required, Validators.min(1)]),
    });
  }

  onAddExercise() {
    const exercises = this.workout.get('exercises') as FormArray;
    exercises.push(new FormGroup({
      exercise: new FormControl(''),
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
    console.log(formValue);
    const workout: Workout = {
      workoutId: formValue.workoutId,
      ownerId: '',
      title: formValue.title,
      description: formValue.description,
      duration: formValue.duration,
      videoLink: formValue.videoLink,
      workoutExercises: formValue
        .exercises
        .filter(x => typeof x.name !== 'string' || x.exercise != null)
        .map(x => {
          const exerciseId = x.exercise ? x.exercise.exerciseId : x.name.exerciseId;
          return {
            exerciseId,
            sets: x.sets,
            reps: x.reps,
          };
        })
    };

    this.workoutService
      .updateWorkout(workout)
      .subscribe(res => this.router.navigateByUrl(`workouts/${this.workout.get('workoutId').value}`));
  }
}
