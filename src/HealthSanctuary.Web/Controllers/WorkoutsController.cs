using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Core.Services.Workouts;
using HealthSanctuary.Web.Extensions;
using HealthSanctuary.Web.Mappers.Workouts;
using HealthSanctuary.Web.Models.Workouts;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthSanctuary.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ODataController
    {
        private readonly IWorkoutService _workoutService;
        private readonly IWorkoutMapper _workoutMapper;
        private readonly IWorkoutsRepository _workoutsRepository;

        public WorkoutsController(IWorkoutService workoutService, IWorkoutMapper workoutMapper, IWorkoutsRepository workoutsRepository)
        {
            _workoutService = workoutService;
            _workoutMapper = workoutMapper;
            _workoutsRepository = workoutsRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        [EnableQuery]
        public IQueryable<Workout> GetWorkouts()
        {
            return _workoutsRepository.GetQueryableWorkouts();
        }

        [HttpGet("{workoutId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetWorkout([FromRoute] int workoutId)
        {
            var workout = await _workoutService.GetWorkout(workoutId);
            var response = _workoutMapper.ToResponse(workout);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutRequest request)
        {
            var userId = HttpContext.GetUserId();
            var workout = _workoutMapper.ToEntity(request, userId);
            var workoutId = await _workoutService.CreateWorkout(workout);

            var response = new WorkoutIdResponse(workoutId);

            return Ok(response);
        }

        [HttpPut("{workoutId}")]
        public async Task<IActionResult> UpdateWorkout([FromRoute] int workoutId, [FromBody] WorkoutRequest request)
        {
            var userId = HttpContext.GetUserId();
            var workout = _workoutMapper.ToEntity(workoutId, request, userId);

            await _workoutService.UpdateWorkout(workout);

            return Ok();
        }

        [HttpDelete("{workoutId}")]
        public async Task<IActionResult> DeleteWorkout([FromRoute] int workoutId)
        {
            var userId = HttpContext.GetUserId();
            await _workoutService.DeleteWorkout(workoutId, userId);

            return Ok();
        }
    }
}
