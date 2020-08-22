using System.Collections;
using System.Collections.Generic;

namespace HealthSanctuary.Core.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
