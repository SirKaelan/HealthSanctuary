using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.Workouts;

namespace HealthSanctuary.Web.Mappers.Workouts
{
    public interface IWorkoutMapper
    {
        WorkoutResponse ToResponse(Workout workout);

        Workout ToEntity(WorkoutRequest workout, string userId);

        Workout ToEntity(int workoutId, WorkoutRequest workout, string userId);
    }
}
