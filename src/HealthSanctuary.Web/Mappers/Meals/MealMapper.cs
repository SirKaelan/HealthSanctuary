using AutoMapper;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.Meals;

namespace HealthSanctuary.Web.Mappers.Meals
{
    public class MealMapper : IMealMapper
    {
        private readonly IMapper _mapper;

        public MealMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Meal ToEntity(MealRequest meal)
        {
            return _mapper.Map<Meal>(meal);
        }

        public MealResponse ToResponse(Meal meal)
        {
            return _mapper.Map<MealResponse>(meal);
        }
    }
}
