﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;

namespace HealthSanctuary.Core.Services.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutsRepository _workoutsRepository;

        public WorkoutService(IWorkoutsRepository workoutsRepository)
        {
            _workoutsRepository = workoutsRepository;
        }

        public async Task<List<Workout>> GetWorkouts()
        {
            // Filter only current user workouts
            return await _workoutsRepository.GetWorkouts();
        }

        public async Task<Workout> GetWorkout(int workoutId)
        {
            return await _workoutsRepository.GetWorkout(workoutId);
        }

        public async Task<int> CreateWorkout(Workout workout)
        {
            _workoutsRepository.AddWorkout(workout);
            await _workoutsRepository.SaveChanges();

            return workout.Id;
        }

        public async Task UpdateWorkout(Workout workout)
        {
            // Validate owner
            _workoutsRepository.UpdateWorkout(workout);
            await _workoutsRepository.SaveChanges();
        }

        public async Task DeleteWorkout(int workoutId)
        {
            _workoutsRepository.DeleteWorkout(workoutId);
            await _workoutsRepository.SaveChanges();
        }
    }
}
