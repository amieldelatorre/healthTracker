using healthTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace healthTracker.Data
{
    public class HealthTrackerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<Height> Heights { get; set; }
        public DbSet<BodyFat> BodyFats { get; set; }
        public DbSet<Sleep> Sleeps { get; set; }
        public HealthTrackerContext(DbContextOptions<HealthTrackerContext> options) : base(options) { }
    }
}
