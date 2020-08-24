using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;

namespace HealthSanctuary.Core.Services.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExercisesRepository _exercisesRepository;

        public ExerciseService(IExercisesRepository exercisesRepository)
        {
            _exercisesRepository = exercisesRepository;
        }

        public async Task<List<Exercise>> GetExercises()
        {
            return await _exercisesRepository.GetMany();
        }

        public async Task<Exercise> GetExercise(int exerciseId)
        {
            return await _exercisesRepository.GetOne(exerciseId);
        }

        public async Task<int> CreateExercise(Exercise exercise)
        {
            _exercisesRepository.CreateOne(exercise);
            await _exercisesRepository.SaveChanges();

            return exercise.ExerciseId;
        }

        public async Task UpdateExercise(Exercise exercise)
        {
            _exercisesRepository.UpdateOne(exercise);
            await _exercisesRepository.SaveChanges();
        }

        public async Task DeleteExercise(int exerciseId)
        {
            _exercisesRepository.DeleteOne(exerciseId);
            await _exercisesRepository.SaveChanges();
        }
    }
}
