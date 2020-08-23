using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Services.Exercises
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetExercises();

        Task<Exercise> GetExercise(int exerciseId);

        Task<int> CreateExercise(Exercise exercise);

        Task UpdateExercise(Exercise exercise);

        Task DeleteExercise(int exerciseId);
    }
}
