using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Repositories
{
    public interface IWorkoutsRepository
    {
        Task<List<Workout>> GetWorkouts();

        Task<Workout> GetWorkout(int workoutId);

        void AddWorkout(Workout workout);

        void UpdateWorkout(Workout workout);

        void DeleteWorkout(int workoutId);

        Task SaveChanges();
    }
}
