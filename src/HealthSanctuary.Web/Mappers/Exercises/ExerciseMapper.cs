﻿using HealthSanctuary.Core.Models;
using HealthSanctuary.Web.Models.Exercises;

namespace HealthSanctuary.Web.Mappers.Exercises
{
    public class ExerciseMapper : IExerciseMapper
    {
        public ExerciseResponse ToResponse(Exercise exercise)
        {
            return new ExerciseResponse
            {
                ExerciseId = exercise.ExerciseId,
                Name = exercise.Name,
                Description = exercise.Description,
                VideoLink = exercise.VideoLink
            };
        }

        public Exercise ToEntity(int exerciseId, ExerciseRequest exercise)
        {
            return new Exercise
            {
                ExerciseId = exerciseId,
                Name = exercise.Name,
                Description = exercise.Description,
                VideoLink = exercise.VideoLink
            };
        }

        public Exercise ToEntity(ExerciseRequest exercise)
        {
            return ToEntity(exerciseId: default, exercise);
        }
    }
}