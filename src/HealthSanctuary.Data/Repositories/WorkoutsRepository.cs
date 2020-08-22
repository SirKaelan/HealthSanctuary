using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthSanctuary.Data.Repositories
{
    public class WorkoutsRepository : IWorkoutsRepository
    {
        private readonly HealthSanctuaryContext _context;

        public WorkoutsRepository(HealthSanctuaryContext context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout> GetWorkout(int workoutId)
        {
            return await _context.Workouts.FirstOrDefaultAsync(x => x.Id == workoutId);
        }

        public void AddWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
        }

        public void UpdateWorkout(Workout workout)
        {
            _context.Workouts.Update(workout);
        }

        public void DeleteWorkout(int workoutId)
        {
            var workout = new Workout
            {
                Id = workoutId
            };

            _context.Workouts.Remove(workout);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
