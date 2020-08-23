﻿using System.Collections.Generic;
using HealthSanctuary.Web.Models.WorkoutExercises;

namespace HealthSanctuary.Web.Models.Workouts
{
    public class WorkoutResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string VideoLink { get; set; }
        public List<WorkoutExerciseResponse> Exercises { get; set; }
    }
}
