namespace HealthSanctuary.Web.Models.Exercises
{
    public class ExerciseIdResponse
    {
        public ExerciseIdResponse(int exerciseId)
        {
            ExerciseId = exerciseId;
        }

        public int ExerciseId { get; set; }
    }
}
