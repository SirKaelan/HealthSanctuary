using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Web.Models.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace HealthSanctuary.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExercisesRepository _exercisesRepository;

        public ExercisesController(IExercisesRepository exercisesRepository)
        {
            _exercisesRepository = exercisesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetExercises()
        {
            var exercises = await _exercisesRepository.GetMany();
            var response = exercises.Select(x => MapToExerciseResponse(x)).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            var exercise = await _exercisesRepository.GetOne(id);
            var response = MapToExerciseResponse(exercise);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] ExerciseRequest request)
        {
            var exercise = MapToExercise(request);
            _exercisesRepository.CreateOne(exercise);
            await _exercisesRepository.SaveChanges();

            var response = new ExerciseIdResponse(exercise.Id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise([FromRoute] int id, [FromBody] ExerciseRequest request)
        {
            var exercise = new Exercise
            {
                Id = id,
                Description = request.Description,
                Name = request.Name,
                VideoLink = request.VideoLink
            };

            _exercisesRepository.UpdateOne(exercise);
            await _exercisesRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            _exercisesRepository.DeleteOne(id);
            await _exercisesRepository.SaveChanges();

            return Ok();
        }

        private ExerciseResponse MapToExerciseResponse(Exercise exercise)
        {
            return new ExerciseResponse
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                VideoLink = exercise.VideoLink
            };
        }

        private Exercise MapToExercise(ExerciseRequest exercise)
        {
            return new Exercise
            {
                Name = exercise.Name,
                Description = exercise.Description,
                VideoLink = exercise.VideoLink
            };
        }
    }
}
