﻿using System;
using System.Collections.Generic;

namespace HealthSanctuary.Core.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string VideoLink { get; set; }
        public ICollection<WorkoutExercise> Exercises { get; set; }
    }
}
