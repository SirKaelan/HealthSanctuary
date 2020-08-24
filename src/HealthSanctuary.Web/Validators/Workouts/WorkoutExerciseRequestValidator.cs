using FluentValidation;
using HealthSanctuary.Web.Models.WorkoutExercises;

namespace HealthSanctuary.Web.Validators.Workouts
{
    public class WorkoutExerciseRequestValidator : AbstractValidator<WorkoutExerciseRequest>
    {
        public WorkoutExerciseRequestValidator()
        {
            RuleFor(x => x.Sets).GreaterThan(0);
            RuleFor(x => x.Reps).GreaterThan(0);
            RuleFor(x => x.ExerciseId).GreaterThan(0);
        }
    }
}
