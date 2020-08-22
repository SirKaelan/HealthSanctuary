namespace HealthSanctuary.Core.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public Exercise Exercise { get; set; }
        public Workout Workout { get; set; }
    }
}
