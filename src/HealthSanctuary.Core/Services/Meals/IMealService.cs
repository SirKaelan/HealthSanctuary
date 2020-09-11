using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Services.Meals
{
    public interface IMealService
    {
        Task<List<Meal>> GetMeals();

        Task<Meal> GetMeal(int mealId);

        Task<int> CreateMeal(Meal meal);

        Task UpdateMeal(Meal meal);

        Task DeleteMeal(int mealId, string requesterUserId);
    }
}
