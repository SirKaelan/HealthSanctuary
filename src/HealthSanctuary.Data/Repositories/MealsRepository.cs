using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthSanctuary.Data.Repositories
{
    public class MealsRepository : IMealsRepository
    {
        private readonly HealthSanctuaryContext _context;

        public MealsRepository(HealthSanctuaryContext context)
        {
            _context = context;
        }

        public IQueryable<Meal> GetQueryableMeals()
        {
            return _context.Meals.AsNoTracking();
        }

        public async Task<Meal> GetOne(int id)
        {
            return await _context.Meals.FirstOrDefaultAsync(x => x.MealId == id);
        }

        public async Task<List<Meal>> GetMany()
        {
            return await _context.Meals.ToListAsync();
        }

        public void CreateOne(Meal meal)
        {
            _context.Meals.Add(meal);
        }

        public void UpdateOne(Meal meal)
        {
            _context.Meals.Update(meal);
        }

        public void DeleteOne(int id)
        {
            var meal = new Meal { MealId = id };
            _context.Meals.Remove(meal);
        }

        public async Task<int> CountUses(int mealId)
        {
            return await _context.Workouts.CountAsync(x => x.MealId == mealId);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
