using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Exceptions;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;

namespace HealthSanctuary.Core.Services.Meals
{
    public class MealService : IMealService
    {
        private readonly IMealsRepository _mealsRepository;

        public MealService(IMealsRepository mealsRepository)
        {
            _mealsRepository = mealsRepository;
        }

        public async Task<Meal> GetMeal(int mealId)
        {
            return await _mealsRepository.GetOne(mealId);
        }

        public async Task<List<Meal>> GetMeals()
        {
            return await _mealsRepository.GetMany();
        }

        public async Task<int> CreateMeal(Meal meal)
        {
            _mealsRepository.CreateOne(meal);
            await _mealsRepository.SaveChanges();

            return meal.MealId;
        }

        public async Task UpdateMeal(Meal meal)
        {
            _mealsRepository.UpdateOne(meal);
            await _mealsRepository.SaveChanges();
        }

        public async Task DeleteMeal(int mealId, string requesterUserId)
        {
            await ValidateMealIsNotUsed(mealId);

            _mealsRepository.DeleteOne(mealId);
            await _mealsRepository.SaveChanges();
        }

        private async Task ValidateMealIsNotUsed(int mealId)
        {
            var count = await _mealsRepository.CountUses(mealId);
            if (count > 0)
            {
                throw new MealUsedException();
            }
        }
    }
}
