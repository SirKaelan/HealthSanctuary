using System.Collections.Generic;
using AutoMapper;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.Exercises;

namespace HealthSanctuary.Web.Mappers.Exercises
{
    public class ExerciseMapper : IExerciseMapper
    {
        private readonly IMapper _mapper;

        public ExerciseMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ExerciseResponse ToResponse(Exercise exercise)
        {
            return _mapper.Map<ExerciseResponse>(exercise);
        }

        public List<ExerciseResponse> ToResponse(List<Exercise> exercises)
        {
            return _mapper.Map<List<ExerciseResponse>>(exercises);
        }

        public Exercise ToEntity(int exerciseId, ExerciseRequest exercise)
        {
            return _mapper.Map<Exercise>(exercise, x => x.Items[nameof(exerciseId).ToLower()] = exerciseId);
        }

        public Exercise ToEntity(ExerciseRequest exercise)
        {
            return ToEntity(exerciseId: default, exercise);
        }
    }
}
