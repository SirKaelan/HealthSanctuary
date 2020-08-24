namespace HealthSanctuary.Web.Models.Workouts
{
    public class WorkoutIdResponse
    {
        public WorkoutIdResponse(int workoutId)
        {
            WorkoutId = workoutId;
        }

        public int WorkoutId { get; set; }
    }
}
