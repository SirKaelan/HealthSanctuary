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
            if (workout == null)
            {
                return null;
            }

            return new WorkoutResponse
            {
                WorkoutId = workout.WorkoutId,
                Title = workout.Title,
                Description = workout.Description,
                Duration = workout.Duration.TotalMinutes,
                VideoLink = workout.VideoLink,
                WorkoutExercises = workout.WorkoutExercises.Select(x => _workoutExerciseMapper.ToResponse(x)).ToList(),
            };
        }

        public Workout ToEntity(int workoutId, WorkoutRequest workout, string userId)
        {
            return new Workout
            {
                WorkoutId = workoutId,
                Title = workout.Title,
                Description = workout.Description,
                Duration = TimeSpan.FromMinutes(workout.Duration),
                VideoLink = workout.VideoLink,
                OwnerId = userId,
                WorkoutExercises = workout.WorkoutExercises.Select(x => _workoutExerciseMapper.ToEntity(workoutId, x.ExerciseId, x)).ToList(),
            };
        }

        public Workout ToEntity(WorkoutRequest workout, string userId)
        {
            return ToEntity(workoutId: default, workout, userId);
        }
    }
}
