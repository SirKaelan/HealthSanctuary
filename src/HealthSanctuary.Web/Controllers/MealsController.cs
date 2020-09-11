using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Core.Services.Meals;
using HealthSanctuary.Web.Extensions;
using HealthSanctuary.Web.Mappers.Meals;
using HealthSanctuary.Web.Models.Meals;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthSanctuary.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealsController : ControllerBase
    {
        private readonly IMealService _mealService;
        private readonly IMealsRepository _mealsRepository;
        private readonly IMealMapper _mealMapper;

        public MealsController(IMealService mealService, IMealsRepository mealsRepository, IMealMapper mealMapper)
        {
            _mealService = mealService;
            _mealsRepository = mealsRepository;
            _mealMapper = mealMapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [EnableQuery]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public IQueryable<Meal> GetMeals()
        {
            return _mealsRepository.GetQueryableMeals();
        }

        [HttpGet("{mealId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMeal([FromRoute] int mealId)
        {
            var meal = await _mealService.GetMeal(mealId);
            var response = _mealMapper.ToResponse(meal);

            return Ok(response);
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateMeal([FromBody] MealRequest request)
        {
            var meal = _mealMapper.ToEntity(request);
            var mealId = await _mealService.CreateMeal(meal);
            var response = new MealIdResponse(mealId);

            return Ok(response);
        }

        [Authorize("Admin")]
        [HttpPut("{mealId}")]
        public async Task<IActionResult> UpdateMeal([FromRoute] int mealId, [FromBody] MealRequest request)
        {
            var meal = _mealMapper.ToEntity(request);
            await _mealService.UpdateMeal(meal);

            return Ok();
        }

        [Authorize("Admin")]
        [HttpDelete("{mealId}")]
        public async Task<IActionResult> ActionResult([FromRoute] int mealId)
        {
            var userId = HttpContext.GetUserId();
            await _mealService.DeleteMeal(mealId, userId);

            return Ok();
        }
    }
}
