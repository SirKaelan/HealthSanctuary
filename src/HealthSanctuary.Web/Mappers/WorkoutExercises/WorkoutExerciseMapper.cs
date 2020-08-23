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
                Id = workoutExercise.Id,
                Reps = workoutExercise.Reps,
                Sets = workoutExercise.Sets,
                Exercise = _exerciseMapper.ToResponse(workoutExercise.Exercise)
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
