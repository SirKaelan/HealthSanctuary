using HealthSanctuary.Data.Context;
using HealthSanctuary.Data.Entities;
using HealthSanctuary.Web.Models.Workouts;
using Microsoft.AspNetCore.Mvc;

namespace HealthSanctuary.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly WorkoutContext _workoutContext;

        public WorkoutsController(WorkoutContext workoutContext)
        {
            _workoutContext = workoutContext;
        }

        [HttpGet]
        public IActionResult GetWorkouts()
        {
            var workout = new Workout
            {
                Name = "asd"
            };

            _workoutContext.Workouts.Add(workout);
            _workoutContext.SaveChanges();

            return Ok();
        }

        [HttpGet("{workoutId}")]
        public IActionResult GetWorkout([FromRoute] string workoutId)
        {
            var workout = new WorkoutResponse
            {
                Name = "Full body workout",
                Time = 5
            };

            return Ok(workout);
        }

        [HttpPost]
        public IActionResult CreateWorkout([FromBody] WorkoutRequest workout)
        {
            return Ok();
        }

        [HttpPut("{workoutId}")]
        public IActionResult UpdateWorkout([FromRoute] string workoutId, [FromBody] WorkoutRequest workout)
        {
            return Ok();
        }

        [HttpDelete("{workoutId}")]
        public IActionResult DeleteWorkout([FromRoute] string workoutId)
        {
            return Ok();
        }
    }
}
