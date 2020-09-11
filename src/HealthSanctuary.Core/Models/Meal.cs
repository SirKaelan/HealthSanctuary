using System;
using System.Collections.Generic;

namespace HealthSanctuary.Core.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Servings { get; set; }
        public double KCal { get; set; }
        public TimeSpan ReadyIn { get; set; }
        public DateTime AddedOn { get; set; }

        public List<Workout> Workouts { get; set; }
    }
}
