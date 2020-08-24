using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Mappers.Exercises;
using HealthSanctuary.Web.Models.WorkoutExercises;

namespace HealthSanctuary.Web.Mappers.WorkoutExercises
{
    public class WorkoutExerciseMapper : IWorkoutExerciseMapper
    {
        private readonly IExerciseMapper _exerciseMapper;

        public WorkoutExerciseMapper(IExerciseMapper exerciseMapper)
        {
            _exerciseMapper = exerciseMapper;
        }

        public WorkoutExerciseResponse ToResponse(WorkoutExercise workoutExercise)
        {
            return new WorkoutExerciseResponse
            {
                Reps = workoutExercise.Reps,
                Sets = workoutExercise.Sets,
                Exercise = _exerciseMapper.ToResponse(workoutExercise.Exercise)
            };
        }

        public WorkoutExercise ToEntity(int workoutId, int exerciseId, WorkoutExerciseRequest workoutExercise)
        {
            return new WorkoutExercise
            {
                WorkoutId = workoutId,
                ExerciseId = exerciseId,
                Reps = workoutExercise.Reps,
                Sets = workoutExercise.Sets,
            };
        }

        public WorkoutExercise ToEntity(WorkoutExerciseRequest workoutExercise)
        {
            return ToEntity(workoutId: default, exerciseId: default, workoutExercise);
        }
    }
}
