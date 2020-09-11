namespace HealthSanctuary.Web.Models.Meals
{
    public class MealIdResponse
    {
        public MealIdResponse(int mealId)
        {
            MealId = mealId;
        }

        public int MealId { get; set; }
    }
}
