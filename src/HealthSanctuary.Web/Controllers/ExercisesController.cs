using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Services.Exercises;
using HealthSanctuary.Web.Mappers.Exercises;
using HealthSanctuary.Web.Models.Exercises;
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
        public async Task<IActionResult> GetExercises()
        {
            var exercises = await _exerciseService.GetExercises();
            var response = exercises.Select(x => _exerciseMapper.ToResponse(x)).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            var exercise = await _exerciseService.GetExercise(id);
            var response = _exerciseMapper.ToResponse(exercise);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] ExerciseRequest request)
        {
            var exercise = _exerciseMapper.ToEntity(request);

            var exerciseId = await _exerciseService.CreateExercise(exercise);

            var response = new ExerciseIdResponse(exerciseId);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise([FromRoute] int id, [FromBody] ExerciseRequest request)
        {
            var exercise = _exerciseMapper.ToEntity(id, request);

            await _exerciseService.UpdateExercise(exercise);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            await _exerciseService.DeleteExercise(id);

            return Ok();
        }
    }
}
