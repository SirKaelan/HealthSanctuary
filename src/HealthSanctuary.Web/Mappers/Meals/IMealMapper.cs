using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.Meals;

namespace HealthSanctuary.Web.Mappers.Meals
{
    public interface IMealMapper
    {
        Meal ToEntity(MealRequest meal);

        MealResponse ToResponse(Meal meal);
    }
}
