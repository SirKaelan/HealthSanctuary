using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.Exercises;

namespace HealthSanctuary.Web.Mappers.Exercises
{
    public interface IExerciseMapper
    {
        ExerciseResponse ToResponse(Exercise exercise);

        Exercise ToEntity(int exerciseId, ExerciseRequest exercise);

        Exercise ToEntity(ExerciseRequest exercise);
    }
}
