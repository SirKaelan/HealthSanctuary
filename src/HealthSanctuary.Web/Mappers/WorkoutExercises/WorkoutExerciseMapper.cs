using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.WorkoutExercises;

namespace HealthSanctuary.Web.Mappers.WorkoutExercises
{
    public class WorkoutExerciseMapper : IWorkoutExerciseMapper
    {
        public WorkoutExerciseResponse ToResponse(WorkoutExercise workoutExercise)
        {
            return new WorkoutExerciseResponse
            {
                Id = workoutExercise.Id,
                Reps = workoutExercise.Reps,
                Sets = workoutExercise.Sets,
            };
        }

        public WorkoutExercise ToEntity(WorkoutExerciseRequest workoutExercise)
        {
            return new WorkoutExercise
            {
                Reps = workoutExercise.Reps,
                Sets = workoutExercise.Sets,
            };
        }
    }
}
