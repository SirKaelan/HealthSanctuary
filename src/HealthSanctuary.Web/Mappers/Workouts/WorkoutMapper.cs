using AutoMapper;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.Workouts;

namespace HealthSanctuary.Web.Mappers.Workouts
{
    public class WorkoutMapper : IWorkoutMapper
    {
        private readonly IMapper _mapper;

        public WorkoutMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public WorkoutResponse ToResponse(Workout workout)
        {
            return _mapper.Map<WorkoutResponse>(workout);
        }

        public Workout ToEntity(int workoutId, WorkoutRequest workout, string ownerId)
        {
            return _mapper.Map<Workout>(workout, x =>
            {
                x.Items[nameof(workoutId).ToLower()] = workoutId;
                x.Items[nameof(ownerId).ToLower()] = ownerId;
            });
        }

        public Workout ToEntity(WorkoutRequest workout, string userId)
        {
            return ToEntity(workoutId: default, workout, userId);
        }
    }
}
