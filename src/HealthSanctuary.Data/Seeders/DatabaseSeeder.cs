using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Services;
using HealthSanctuary.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace HealthSanctuary.Data.Seeders
{
    public class DatabaseSeeder : IStartupTask
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HealthSanctuaryContext _dbContext;

        public DatabaseSeeder(UserManager<ApplicationUser> userManager, HealthSanctuaryContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task Execute()
        {
            var isCreated = await _dbContext.Database.EnsureCreatedAsync();

            if (!isCreated)
            {
                return;
            }

            var userId = await CreateUser();

            var exercises = GetExercises();
            _dbContext.Exercises.AddRange(exercises);

            var meals = GetMeals();
            _dbContext.Meals.AddRange(meals);

            var workouts = GetWorkouts(userId);
            _dbContext.Workouts.AddRange(workouts);

            await _dbContext.SaveChangesAsync();
        }

        private async Task<string> CreateUser()
        {
            var user = new ApplicationUser("Kalin");
            await _userManager.CreateAsync(user, "Password1!");
            await _userManager.AddClaimAsync(user, new Claim("admin", "admin"));

            return user.Id;
        }

        private List<Exercise> GetExercises()
        {
            return new List<Exercise>
            {
                new Exercise
                {
                    Name = "Push-Up",
                    Description = "Get on the ground and give me twenty!",
                    VideoLink = "https://www.youtube.com/watch?v=7wblGkVQx3U",
                    Likes = 200,
                    AddedOn = new DateTime(2020, 5, 12),
                },
                new Exercise
                {
                    Name = "Pull-Up",
                    Description = "Jump and fly to the bar!",
                    VideoLink = "https://www.youtube.com/watch?v=tB3X4TjTIes",
                    Likes = 120,
                    AddedOn = new DateTime(2020, 6, 17),
                },
                new Exercise
                {
                    Name = "Squat",
                    Description = "Bend your knees to 90 degrees.",
                    VideoLink = "https://www.youtube.com/watch?v=tB3X4TjTIes",
                    Likes = 57,
                    AddedOn = new DateTime(2020, 5, 24),
                },
                new Exercise
                {
                    Name = "Hand Stand",
                    Description = "Fly like Superman, but but in the wrong direction.",
                    VideoLink = "https://www.youtube.com/watch?v=KNC5lkoE2Fs",
                    Likes = 265,
                    AddedOn = new DateTime(2020, 6, 18),
                },
                new Exercise
                {
                    Name = "Planche",
                    Description = "How do you even do it, man?",
                    VideoLink = "https://www.youtube.com/watch?v=OmKfROtB45Q",
                    Likes = 222,
                    AddedOn = new DateTime(2020, 7, 2),
                },
                new Exercise
                {
                    Name = "Front Lever",
                    Description = "Hold the scales, be the scales, love the scales.",
                    VideoLink = "https://www.youtube.com/watch?v=Ev2caBjnwRo",
                    Likes = 24,
                    AddedOn = new DateTime(2020, 2, 13),
                },
                new Exercise
                {
                    Name = "Pistol Squat",
                    Description = "Pretend you only have one leg.",
                    VideoLink = "https://www.youtube.com/watch?v=flQVCWBuVgk",
                    Likes = 67,
                    AddedOn = new DateTime(2020, 8, 5),
                },
                new Exercise
                {
                    Name = "Deadlift",
                    Description = "Keep that back straight.",
                    VideoLink = "https://www.youtube.com/watch?v=SPSKGFbs1aQ",
                    Likes = 99,
                    AddedOn = new DateTime(2020, 9, 3),
                }
            };
        }

        private List<Workout> GetWorkouts(string ownerId)
        {
            return new List<Workout>
            {
                new Workout
                {
                    Title = "Upper Body Workout",
                    Description = "The best Home chest workout to achieve real results that you can do anywhere.",
                    Duration = TimeSpan.FromMinutes(35),
                    OwnerId = ownerId,
                    MealId = 1,
                    Likes = 200,
                    AddedOn = new DateTime(2020, 5, 12),
                    VideoLink = "https://www.youtube.com/watch?v=BkS1-El_WlE",
                    WorkoutExercises = new List<WorkoutExercise>
                    {
                        new WorkoutExercise
                        {
                            ExerciseId = 1,
                            Reps = 20,
                            Sets = 4,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 2,
                            Reps = 10,
                            Sets = 3,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 4,
                            Reps = 12,
                            Sets = 4,
                        },
                    }
                },
                new Workout
                {
                    Title = "Lower Body Workout",
                    Description = "This Home leg Workout will have you building muscle with only your body weight.",
                    Duration = TimeSpan.FromMinutes(25),
                    OwnerId = ownerId,
                    MealId = 2,
                    Likes = 17,
                    AddedOn = new DateTime(2020, 7, 25),
                    VideoLink = "https://www.youtube.com/watch?v=Jbvb_MMGc8s",
                    WorkoutExercises = new List<WorkoutExercise>
                    {
                        new WorkoutExercise
                        {
                            ExerciseId = 3,
                            Reps = 30,
                            Sets = 4,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 7,
                            Reps = 15,
                            Sets = 3,
                        },
                    }
                },
                new Workout
                {
                    Title = "Back Workout",
                    Description = "Gotta build that back like a gate.",
                    Duration = TimeSpan.FromMinutes(45),
                    OwnerId = ownerId,
                    MealId = 3,
                    Likes = 256,
                    AddedOn = new DateTime(2020, 3, 9),
                    VideoLink = "https://www.youtube.com/watch?v=ClzTDsQDC0E",
                    WorkoutExercises = new List<WorkoutExercise>
                    {
                        new WorkoutExercise
                        {
                            ExerciseId = 2,
                            Reps = 12,
                            Sets = 5,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 8,
                            Reps = 7,
                            Sets = 4,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 6,
                            Reps = 3,
                            Sets = 4,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 5,
                            Reps = 4,
                            Sets = 3,
                        },
                    }
                },
                new Workout
                {
                    Title = "Upper Body Workout (Beginner)",
                    Description = "The best Home chest workout to achieve real results that you can do anywhere.",
                    Duration = TimeSpan.FromMinutes(35),
                    OwnerId = ownerId,
                    MealId = 3,
                    Likes = 523,
                    AddedOn = new DateTime(2020, 1, 13),
                    VideoLink = "https://www.youtube.com/watch?v=BkS1-El_WlE",
                    WorkoutExercises = new List<WorkoutExercise>
                    {
                        new WorkoutExercise
                        {
                            ExerciseId = 1,
                            Reps = 10,
                            Sets = 2,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 2,
                            Reps = 5,
                            Sets = 3,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 4,
                            Reps = 6,
                            Sets = 3,
                        },
                    }
                },
                new Workout
                {
                    Title = "Lower Body Workout (Beginner)",
                    Description = "This Home leg Workout will have you building muscle with only your body weight.",
                    Duration = TimeSpan.FromMinutes(25),
                    OwnerId = ownerId,
                    MealId = 1,
                    Likes = 136,
                    AddedOn = new DateTime(2020, 8, 10),
                    VideoLink = "https://www.youtube.com/watch?v=Jbvb_MMGc8s",
                    WorkoutExercises = new List<WorkoutExercise>
                    {
                        new WorkoutExercise
                        {
                            ExerciseId = 3,
                            Reps = 15,
                            Sets = 4,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 7,
                            Reps = 7,
                            Sets = 3,
                        },
                    }
                },
                new Workout
                {
                    Title = "Back Workout (Beginner)",
                    Description = "Gotta build that back like a gate.",
                    Duration = TimeSpan.FromMinutes(45),
                    OwnerId = ownerId,
                    MealId = 2,
                    Likes = 189,
                    AddedOn = new DateTime(2020, 6, 12),
                    VideoLink = "https://www.youtube.com/watch?v=ClzTDsQDC0E",
                    WorkoutExercises = new List<WorkoutExercise>
                    {
                        new WorkoutExercise
                        {
                            ExerciseId = 2,
                            Reps = 6,
                            Sets = 3,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 8,
                            Reps = 4,
                            Sets = 2,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 6,
                            Reps = 3,
                            Sets = 1,
                        },
                        new WorkoutExercise
                        {
                            ExerciseId = 5,
                            Reps = 2,
                            Sets = 1,
                        },
                    }
                },
            };
        }

        private List<Meal> GetMeals()
        {
            return new List<Meal>
            {
                new Meal
                {
                    Name = "Broccoli with cheeses",
                    Description = "Steamed broccoli with 4 different kinds of cheeses",
                    KCal = 870,
                    Servings = 6,
                    ReadyIn = TimeSpan.FromMinutes(35),
                    AddedOn = new DateTime(2020, 4, 21),
                },
                new Meal
                {
                    Name = "Steak with tomatoe sauce",
                    Description = "Juicy stake with sour-sweet tomatoe sauce",
                    KCal = 650,
                    Servings = 2,
                    ReadyIn = TimeSpan.FromMinutes(65),
                    AddedOn = new DateTime(2020, 9, 4),
                },
                new Meal
                {
                    Name = "Ramen",
                    Description = "The trade-mark Japanese dish",
                    KCal = 720,
                    Servings = 6,
                    ReadyIn = TimeSpan.FromMinutes(120),
                    AddedOn = new DateTime(2020, 9, 4),
                },
            };
        }
    }
}
