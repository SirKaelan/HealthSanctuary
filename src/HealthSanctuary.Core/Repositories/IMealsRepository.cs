using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Repositories
{
    public interface IMealsRepository
    {
        IQueryable<Meal> GetQueryableMeals();

        Task<List<Meal>> GetMany();

        Task<Meal> GetOne(int id);

        void CreateOne(Meal meal);

        void UpdateOne(Meal meal);

        void DeleteOne(int id);

        Task<int> CountUses(int mealId);

        Task SaveChanges();
    }
}
