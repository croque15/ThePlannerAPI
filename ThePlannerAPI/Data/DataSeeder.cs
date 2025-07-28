using ThePlannerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ThePlannerAPI.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed planner event types
            modelBuilder.Entity<PlannerEventType>().HasData(
                new PlannerEventType { Id = 1, Description = "Working" },
                new PlannerEventType { Id = 2, Description = "Break" },
                new PlannerEventType { Id = 3, Description = "Meeting" },
                new PlannerEventType { Id = 4, Description = "Training" },
                new PlannerEventType { Id = 5, Description = "Travel" }
            );

            // Seed realistic resources (based on mockupResources by Vlad)
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Id = 1, FirstName = "Elizabeth", LastName = "Taylor", Sector = "cruise", MedCert = new DateTime(2026, 07, 30), Hours = 50, ResourceType = "Supervisor" },
                new Resource { Id = 2, FirstName = "Linda", LastName = "Brown", Sector = "oil & gas", MedCert = new DateTime(2024, 06, 07), Hours = 77, ResourceType = "Supervisor" },
                new Resource { Id = 3, FirstName = "George", LastName = "Lucas", Sector = "cargo", MedCert = new DateTime(2026, 01, 04), Hours = 90, ResourceType = "Supervisor" },
                new Resource { Id = 4, FirstName = "Emily", LastName = "Clark", Sector = "cruise", MedCert = new DateTime(2026, 08, 30), Hours = 34, ResourceType = "Supervisor" },
                new Resource { Id = 5, FirstName = "Michael", LastName = "Scott", Sector = "oil & gas", MedCert = new DateTime(2025, 07, 25), Hours = 2, ResourceType = "Supervisor" },
                new Resource { Id = 6, FirstName = "Kate", LastName = "Moss", Sector = "cruise", MedCert = new DateTime(2027, 07, 30), Hours = 78, ResourceType = "Technician" },
                new Resource { Id = 7, FirstName = "Dian", LastName = "Fossey", Sector = "oil & gas", MedCert = new DateTime(2025, 07, 30), Hours = 85, ResourceType = "Technician" },
                new Resource { Id = 8, FirstName = "Leonardo", LastName = "DiCaprio", Sector = "cargo", MedCert = null, Hours = 96, ResourceType = "Technician" },
                new Resource { Id = 9, FirstName = "Grace", LastName = "Hopper", Sector = "cruise", MedCert = new DateTime(2026, 12, 30), Hours = 73, ResourceType = "Technician" },
                new Resource { Id = 10, FirstName = "Ada", LastName = "Lovelace", Sector = "cargo", MedCert = new DateTime(2026, 02, 27), Hours = 58, ResourceType = "Technician" },
                new Resource { Id = 11, FirstName = "Mario", LastName = "Rossi", Sector = "cargo", MedCert = new DateTime(2026, 04, 30), Hours = 50, ResourceType = "Trainee" },
                new Resource { Id = 12, FirstName = "Luca", LastName = "Verdi", Sector = "oil & gas", MedCert = new DateTime(2026, 05, 30), Hours = 542, ResourceType = "Trainee" }
            );

            // Seed 10 planner events tied to new resource IDs
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<PlannerEvent>().HasData(new PlannerEvent
                {
                    Id = i,
                    Name = $"Event {i}",
                    StartDate = DateTime.Today.AddDays(i),
                    EndDate = DateTime.Today.AddDays(i).AddDays(i % 7 + 1),
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
