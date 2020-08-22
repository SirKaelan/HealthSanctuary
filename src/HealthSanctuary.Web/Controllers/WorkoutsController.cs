using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Web.Models.Workouts;
using Microsoft.AspNetCore.Mvc;

namespace HealthSanctuary.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutsRepository _workoutsRepository;

        public WorkoutsController(IWorkoutsRepository workoutsRepository)
        {
            _workoutsRepository = workoutsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkouts()
        {
            var workouts = await _workoutsRepository.GetWorkouts();
            var response = workouts.Select(x => MapToWorkoutResponse(x)).ToList();

            return Ok(response);
        }

        [HttpGet("{workoutId}")]
        public async Task<IActionResult> GetWorkout([FromRoute] int workoutId)
        {
            var workout = await _workoutsRepository.GetWorkout(workoutId);
            var response = MapToWorkoutResponse(workout);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutRequest request)
        {
            var workout = new Workout { Title = request.Title };
            _workoutsRepository.AddWorkout(workout);
            await _workoutsRepository.SaveChanges();

            var response = new WorkoutIdResponse(workout.Id);

            return Ok(response);
        }

        [HttpPut("{workoutId}")]
        public async Task<IActionResult> UpdateWorkout([FromRoute] int workoutId, [FromBody] WorkoutRequest request)
        {
            var workout = new Workout
            {
                Id = workoutId,
                Title = request.Title
            };

            _workoutsRepository.UpdateWorkout(workout);
            await _workoutsRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{workoutId}")]
        public async Task<IActionResult> DeleteWorkout([FromRoute] int workoutId)
        {
            _workoutsRepository.DeleteWorkout(workoutId);
            await _workoutsRepository.SaveChanges();

            return Ok();
        }

        private WorkoutResponse MapToWorkoutResponse(Workout workout)
        {
            return new WorkoutResponse
            {
                Id = workout.Id,
                Name = workout.Title,
            };
        }
    }
}
