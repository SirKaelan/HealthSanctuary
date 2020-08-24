using FluentValidation;
using HealthSanctuary.Web.Models.Workouts;

namespace HealthSanctuary.Web.Validators.Workouts
{
    public class WorkoutRequestValidator : AbstractValidator<WorkoutRequest>
    {
        public WorkoutRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(500).When(x => x.Description != null);
            RuleFor(x => x.VideoLink).MaximumLength(100).When(x => x.VideoLink != null);
            RuleFor(x => x.Duration).GreaterThan(0);
            RuleFor(x => x.WorkoutExercises).NotEmpty();
            RuleForEach(x => x.WorkoutExercises).SetValidator(new WorkoutExerciseRequestValidator());
        }
    }
}
