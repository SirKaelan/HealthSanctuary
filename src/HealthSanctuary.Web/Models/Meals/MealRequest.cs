using System;

namespace HealthSanctuary.Web.Models.Meals
{
    public class MealRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Servings { get; set; }
        public double KCal { get; set; }
        public int ReadyIn { get; set; }
    }
}
