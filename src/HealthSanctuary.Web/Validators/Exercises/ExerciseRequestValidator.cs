using FluentValidation;
using HealthSanctuary.Web.Models.Exercises;

namespace HealthSanctuary.Web.Validators.Exercises
{
    public class ExerciseRequestValidator : AbstractValidator<ExerciseRequest>
    {
        public ExerciseRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.VideoLink).MaximumLength(100);
        }
    }
}
