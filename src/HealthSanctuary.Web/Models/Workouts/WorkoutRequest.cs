using System;
using System.Collections.Generic;
using HealthSanctuary.Web.Models.WorkoutExercises;

namespace HealthSanctuary.Web.Models.Workouts
{
    public class WorkoutRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string VideoLink { get; set; }
        public List<WorkoutExerciseRequest> Exercises { get; set; }
    }
}
