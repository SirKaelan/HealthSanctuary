using System;
using System.Linq;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Mappers.WorkoutExercises;
using HealthSanctuary.Web.Models.Workouts;

namespace HealthSanctuary.Web.Mappers.Workouts
{
    public class WorkoutMapper : IWorkoutMapper
    {
        private readonly IWorkoutExerciseMapper _workoutExerciseMapper;

        public WorkoutMapper(IWorkoutExerciseMapper workoutExerciseMapper)
        {
            _workoutExerciseMapper = workoutExerciseMapper;
        }

        public WorkoutResponse ToResponse(Workout workout)
        {
            return new WorkoutResponse
            {
                Id = workout.Id,
                Title = workout.Title,
                Description = workout.Description,
                Duration = workout.Duration.TotalMinutes,
                VideoLink = workout.VideoLink,
                Exercises = workout.Exercises.Select(x => _workoutExerciseMapper.ToResponse(x)).ToList(),
            };
        }

        public Workout ToEntity(int workoutId, WorkoutRequest workout)
        {
            return new Workout
            {
                Id = workoutId,
                Title = workout.Title,
                Description = workout.Description,
                Duration = TimeSpan.FromMinutes(workout.Duration),
                VideoLink = workout.VideoLink,
                Exercises = workout.Exercises.Select(x => _workoutExerciseMapper.ToEntity(x)).ToList(),
            };
        }

        public Workout ToEntity(WorkoutRequest workout)
        {
            return ToEntity(workoutId: default, workout);
        }
    }
}
