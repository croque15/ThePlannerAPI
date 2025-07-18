using Microsoft.EntityFrameworkCore;
using ThePlannerAPI.Models;

namespace ThePlannerAPI.Data
{
    public class PlannerDbContext : DbContext
    {
        public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options) { }

        public DbSet<PlannerEvent> PlannerEvents { get; set; }
        public DbSet<PlannerEventType> PlannerEventTypes { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed mock data
            DataSeeder.Seed(modelBuilder);
        }
    }
}
