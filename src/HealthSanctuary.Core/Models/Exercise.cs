using System;
using System.Collections.Generic;

namespace HealthSanctuary.Core.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public TimeSpan AverageDuration { get; set; }
        public int Likes { get; set; }
        public DateTime AddedOn { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
