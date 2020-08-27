using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Repositories
{
    public interface IWorkoutsRepository
    {
        IQueryable<Workout> GetQueryableWorkouts();

        Task<List<Workout>> GetWorkouts();

        Task<Workout> GetWorkout(int workoutId);

        void AddWorkout(Workout workout);

        void UpdateWorkout(Workout workout);

        void DeleteWorkout(int workoutId);

        Task SaveChanges();
    }
}
