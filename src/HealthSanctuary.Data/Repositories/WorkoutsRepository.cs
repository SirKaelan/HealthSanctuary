using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Workout> GetQueryableWorkouts()
        {
            return _context.Workouts.AsNoTracking();
        }

        public async Task<List<Workout>> GetReadOnlyWorkouts()
        {
            return await _context
                .Workouts
                .AsNoTracking()
                .Include(x => x.WorkoutExercises)
                .ThenInclude(x => x.Exercise)
                .ToListAsync();
        }

        public async Task<Workout> GetWorkout(int workoutId)
        {
            return await _context
                .Workouts
                .Include(x => x.WorkoutExercises)
                .ThenInclude(x => x.Exercise)
                .FirstOrDefaultAsync(x => x.WorkoutId == workoutId);
        }

        public async Task<Workout> GetReadOnlyWorkout(int workoutId)
        {
            return await _context                
                .Workouts
                .AsNoTracking()
                .Include(x => x.WorkoutExercises)
                .ThenInclude(x => x.Exercise)
                .FirstOrDefaultAsync(x => x.WorkoutId == workoutId);
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
                WorkoutId = workoutId
            };

            _context.Workouts.Remove(workout);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
