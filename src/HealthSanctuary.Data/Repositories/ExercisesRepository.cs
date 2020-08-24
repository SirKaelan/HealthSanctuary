using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthSanctuary.Data.Repositories
{
    public class ExercisesRepository : IExercisesRepository
    {
        private readonly HealthSanctuaryContext _context;

        public ExercisesRepository(HealthSanctuaryContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetMany()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetOne(int id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(x => x.ExerciseId == id);
        }

        public void CreateOne(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
        }

        public void UpdateOne(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
        }

        public void DeleteOne(int id)
        {
            var exercise = new Exercise
            {
                ExerciseId = id
            };

            _context.Exercises.Remove(exercise);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
