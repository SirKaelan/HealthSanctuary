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
    }
}
