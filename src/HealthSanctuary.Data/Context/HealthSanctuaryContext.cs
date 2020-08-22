using HealthSanctuary.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthSanctuary.Data.Context
{
    public class HealthSanctuaryContext : DbContext
    {
        public HealthSanctuaryContext(DbContextOptions<HealthSanctuaryContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(we => we.Workout)
                .IsRequired();

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .IsRequired();

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.Exercises)
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.WorkoutExercises)
                .WithOne(we => we.Exercise)
                .IsRequired();
        }
    }
}
