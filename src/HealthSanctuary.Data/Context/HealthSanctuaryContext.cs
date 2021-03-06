﻿using HealthSanctuary.Core.Models;
using HealthSanctuary.Data.Settings;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HealthSanctuary.Data.Context
{
    public class HealthSanctuaryContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly IDatabaseSettings _settings;

        public HealthSanctuaryContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IDatabaseSettings settings)
            : base(options, operationalStoreOptions)
        {
            _settings = settings;
        }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Meal> Meals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_settings.ConnectionString, b => b.MigrationsAssembly("HealthSanctuary.Data"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().Property(a => a.Id).ValueGeneratedNever();

            WorkoutConfiguration(modelBuilder);
            WorkoutExerciseConfiguration(modelBuilder);
            ExerciseConfiguration(modelBuilder);
            MealConfiguration(modelBuilder);
        }

        private void WorkoutConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Workout>()
                .Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Workout>()
                .Property(x => x.Duration)
                .IsRequired();

            modelBuilder.Entity<Workout>()
                .Property(x => x.VideoLink)
                .HasMaxLength(100);

            modelBuilder.Entity<Workout>()
                .Property(x => x.OwnerId)
                .IsRequired();

            modelBuilder.Entity<Workout>()
                .HasOne(x => x.Meal)
                .WithMany(x => x.Workouts)
                .HasForeignKey(x => x.MealId)
                .IsRequired(false);
        }

        private void WorkoutExerciseConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.WorkoutId, we.ExerciseId });

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId);

            modelBuilder.Entity<WorkoutExercise>()
                .Property(x => x.Reps)
                .IsRequired();

            modelBuilder.Entity<WorkoutExercise>()
                .Property(x => x.Sets)
                .IsRequired();
        }

        private void ExerciseConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Exercise>()
                .Property(x => x.VideoLink)
                .HasMaxLength(100);
        }

        private void MealConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Meal>()
                .Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}
