import { WorkoutExercise } from './WorkoutExercise';

export interface Workout {
  workoutId: number;
  title: string;
  description: string;
  duration: number;
  videoLink: string;
  ownerId: string;
  workoutExercises: WorkoutExercise[];
}
