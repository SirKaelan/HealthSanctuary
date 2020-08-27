using System.Threading.Tasks;
using HealthSanctuary.Core.Services.Exercises;
using HealthSanctuary.Web.Mappers.Exercises;
using HealthSanctuary.Web.Models.Exercises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthSanctuary.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseMapper _exerciseMapper;
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService, IExerciseMapper exerciseMapper)
        {
            _exerciseService = exerciseService;
            _exerciseMapper = exerciseMapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetExercises()
        {
            var exercises = await _exerciseService.GetExercises();
            var response = _exerciseMapper.ToResponse(exercises);

            return Ok(response);
        }

        [HttpGet("{exerciseId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetExercise([FromRoute] int exerciseId)
        {
            var exercise = await _exerciseService.GetExercise(exerciseId);
            var response = _exerciseMapper.ToResponse(exercise);

            return Ok(response);
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] ExerciseRequest request)
        {
            var exercise = _exerciseMapper.ToEntity(request);
            var exerciseId = await _exerciseService.CreateExercise(exercise);

            var response = new ExerciseIdResponse(exerciseId);

            return Ok(response);
        }

        [Authorize("Admin")]
        [HttpPut("{exerciseId}")]
        public async Task<IActionResult> UpdateExercise([FromRoute] int exerciseId, [FromBody] ExerciseRequest request)
        {
            var exercise = _exerciseMapper.ToEntity(exerciseId, request);
            await _exerciseService.UpdateExercise(exercise);

            return Ok();
        }

        [Authorize("Admin")]
        [HttpDelete("{exerciseId}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int exerciseId)
        {
            await _exerciseService.DeleteExercise(exerciseId);

            return Ok();
        }
    }
}
