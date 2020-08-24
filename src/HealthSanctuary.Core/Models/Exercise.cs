using System.Collections.Generic;

namespace HealthSanctuary.Core.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
