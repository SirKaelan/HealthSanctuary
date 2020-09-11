using System;

namespace HealthSanctuary.Web.Models.Meals
{
    public class MealResponse
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Servings { get; set; }
        public double KCal { get; set; }
        public int ReadyIn { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
