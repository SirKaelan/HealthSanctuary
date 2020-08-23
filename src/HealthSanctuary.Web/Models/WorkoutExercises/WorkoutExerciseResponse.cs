using HealthSanctuary.Web.Models.Exercises;

namespace HealthSanctuary.Web.Models.WorkoutExercises
{
    public class WorkoutExerciseResponse
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public ExerciseResponse Exercise{ get; set; }
    }
}
