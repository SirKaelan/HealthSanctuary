import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-workout-create',
  templateUrl: './workout-create.component.html',
  styleUrls: ['./workout-create.component.css']
})
export class WorkoutCreateComponent implements OnInit {
  workout = new FormGroup({
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

  constructor() { }

  ngOnInit() {
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

  onSubmit() {
    console.log(this.workout);
  }

}
