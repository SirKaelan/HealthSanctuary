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
        public string OwnerId { get; set; }
        public int Likes { get; set; }
        public DateTime AddedOn { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; }

        public int? MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
