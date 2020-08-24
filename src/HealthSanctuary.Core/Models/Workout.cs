using System;
using System.Collections.Generic;

namespace HealthSanctuary.Core.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string VideoLink { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
