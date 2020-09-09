using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Exceptions;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;

namespace HealthSanctuary.Core.Services.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutsRepository _workoutsRepository;

        public WorkoutService(IWorkoutsRepository workoutsRepository)
        {
            _workoutsRepository = workoutsRepository;
        }

        public async Task<List<Workout>> GetWorkouts()
        {
            return await _workoutsRepository.GetReadOnlyWorkouts();
        }

        public async Task<Workout> GetWorkout(int workoutId)
        {
            return await _workoutsRepository.GetWorkout(workoutId);
        }

        public async Task<int> CreateWorkout(Workout workout)
        {
            _workoutsRepository.AddWorkout(workout);
            await _workoutsRepository.SaveChanges();

            return workout.WorkoutId;
        }

        public async Task UpdateWorkout(Workout workout)
        {
            var workoutEntity = await _workoutsRepository.GetReadOnlyWorkout(workout.WorkoutId);
            ValidateWorkoutOwner(workoutEntity, workout.OwnerId);

            var oldWorkoutExerciseIds = workoutEntity.WorkoutExercises.Select(x => x.ExerciseId).ToList();
            var newWorkoutExercises = workout
                .WorkoutExercises
                .Where(x => !oldWorkoutExerciseIds.Contains(x.ExerciseId))
                .ToList();

            _workoutsRepository.AddWorkoutExercises(newWorkoutExercises);
            _workoutsRepository.UpdateWorkout(workout);
            await _workoutsRepository.SaveChanges();
        }

        public async Task DeleteWorkout(int workoutId, string requesterUserId)
        {
            var workoutEntity = await _workoutsRepository.GetReadOnlyWorkout(workoutId);
            ValidateWorkoutOwner(workoutEntity, requesterUserId);

            _workoutsRepository.DeleteWorkout(workoutId);
            await _workoutsRepository.SaveChanges();
        }

        private void ValidateWorkoutOwner(Workout workout, string requesterUserId)
        {
            if (workout.OwnerId != requesterUserId)
            {
                throw new WorkoutOwnerException();
            }
        }
    }
}
