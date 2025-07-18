using ThePlannerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ThePlannerAPI.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // seed planner event types
            modelBuilder.Entity<PlannerEventType>().HasData(
                new PlannerEventType { Id = 1, Description = "Working" },
                new PlannerEventType { Id = 2, Description = "Break" },
                new PlannerEventType { Id = 3, Description = "Meeting" },
                new PlannerEventType { Id = 4, Description = "Training" },
                new PlannerEventType { Id = 5, Description = "Travel" }
            );

            // seed 12 resources
             for (int i = 1; i <= 12; i++)
            {
                modelBuilder.Entity<Resource>().HasData(new Resource
                {
                    Id = i,
                    Name = $"Resource {i}",
                    ResourceType = i <= 9 ? "Person" : "Vehicle"
                });
            }

            // seed 10 PlannerEvents
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<PlannerEvent>().HasData(new PlannerEvent
                {
                    Id = i,
                    Name = $"Event {i}",
                    StartDate = DateTime.Today.AddDays(i),
                    EndDate = DateTime.Today.AddDays(i).AddHours(2),
                    ResourceId = (i % 12) + 1,
                    Color = "#FFCC00",
                    JobID = 1000 + i,
                    ShipName = $"Ship {i}",
                    JobCode = $"J{i:000}",
                    Description = $"Description for Event {i}",
                    ClientName = $"Client {i}",
                    DeparturePort = "Port A",
                    ArrivalPort = "Port B",
                    EditBy = "System",
                    PlannerEventTypeId = (i % 5) + 1,
                    TravelDays = i % 3,
                    IsCTS = i % 2 == 0
                });
            }
        }
    }
}