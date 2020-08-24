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
    }
}
