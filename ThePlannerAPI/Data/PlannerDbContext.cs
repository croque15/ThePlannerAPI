using Microsoft.EntityFrameworkCore;
using ThePlannerAPI.Models;

namespace ThePlannerAPI.Data
{
    public class PlannerDbContext : DbContext
    {
        public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options) {}

        public DbSet<PlannerEvent> PlannerEvents { get; set; }
        public DbSet<PlannerEventType> PlannerEventTypes { get; set; }
    }
}
