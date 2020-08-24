using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.WorkoutExercises;

namespace HealthSanctuary.Web.Mappers.WorkoutExercises
{
    public interface IWorkoutExerciseMapper
    {
        WorkoutExerciseResponse ToResponse(WorkoutExercise workoutExercise);

        WorkoutExercise ToEntity(int workoutId, int exerciseId, WorkoutExerciseRequest workoutExercise);

        WorkoutExercise ToEntity(WorkoutExerciseRequest workoutExercise);
    }
}
