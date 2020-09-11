using FluentValidation;
using HealthSanctuary.Web.Models.Meals;

namespace HealthSanctuary.Web.Validators.Meals
{
    public class MealsValidator : AbstractValidator<MealRequest>
    {
        public MealsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.KCal).GreaterThan(0);
            RuleFor(x => x.Servings).GreaterThan(0);
            RuleFor(x => x.ReadyIn).GreaterThan(0);
        }
    }
}
