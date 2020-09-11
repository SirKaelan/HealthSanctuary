using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Services.Workouts
{
    public interface IWorkoutService
    {
        Task<List<Workout>> GetWorkouts();

        Task<Workout> GetWorkout(int workoutId);

        Task<int> CreateWorkout(Workout workout);

        Task UpdateWorkout(Workout workout);

        Task DeleteWorkout(int workoutId, string requesterUserId);

        Task AddMeal(int workoutId, int mealId, string requesterUserId);

        Task RemoveMeal(int workoutId, string requesterUserId);
    }
}
