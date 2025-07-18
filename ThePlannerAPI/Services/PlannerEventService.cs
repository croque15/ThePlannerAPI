using ThePlannerAPI.Models;
using ThePlannerAPI.DTOs;
using ThePlannerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ThePlannerAPI.Services
{
    public class PlannerEventService : IPlannerService
    {
        private readonly PlannerDbContext _context;

        public PlannerEventService(PlannerDbContext context)
        {
            _context = context;
        }

       public async Task<IEnumerable<PlannerEventDTO>> GetAllEventsAsync()  
       { 
            try
            { 
                if (_context?.PlannerEvents == null)
                {
                    Console.WriteLine("PlannerEvents DbSet is null.");
                    return Enumerable.Empty<PlannerEventDTO>();
                }

                var events = await _context.PlannerEvents
                    .Select(e => new PlannerEventDTO
                    {   
                        Id = e.Id,
                        Name = e.Name,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        Resource = e.ResourceId,
                        Color = e.Color,
                        JobID = e.JobID,
                        ShipName = e.ShipName,
                        JobCode = e.JobCode,
                        Description = e.Description,
                        ClientName = e.ClientName,
                        DeparturePort = e.DeparturePort,
                        ArrivalPort = e.ArrivalPort,
                        EditBy = e.EditBy,
                        PlannerEventType = e.PlannerEventTypeId,
                        TravelDays = e.TravelDays,
                        IsCTS = e.IsCTS
                    }).ToListAsync();

                return events;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllEventsAsync: {ex.Message}");
                return Enumerable.Empty<PlannerEventDTO>();
            }
        }


        public async Task<PlannerEventDTO> GetEventByIdAsync(int id)
        {
            var e = await _context.PlannerEvents.FindAsync(id);
            if (e == null) return null;

            return new PlannerEventDTO
            {
                Id = e.Id,
                Name = e.Name,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Resource = e.ResourceId,
                Color = e.Color,
                JobID = e.JobID,
                ShipName = e.ShipName,
                JobCode = e.JobCode,
                Description = e.Description,
                ClientName = e.ClientName,
                DeparturePort = e.DeparturePort,
                ArrivalPort = e.ArrivalPort,
                EditBy = e.EditBy,
                PlannerEventType = e.PlannerEventTypeId,
                TravelDays = e.TravelDays,
                IsCTS = e.IsCTS
            };
        }

        public async Task<PlannerEventDTO> CreateEventAsync(PlannerEventDTO dto)
        {
            if (dto.PlannerEventType == 1 && dto.Name != dto.JobCode)
            {
                throw new Exception("For Job Events, Name must equal JobCode.");
            }

            if (dto.PlannerEventType != 1)
            {
                dto.JobID = 0;
                dto.ShipName = "-";
                dto.JobCode = "-";
                dto.ClientName = "-";
            }

            var entity = new PlannerEvent
            {
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ResourceId = dto.Resource,
                Color = dto.Color,
                JobID = dto.JobID,
                ShipName = dto.ShipName,
                JobCode = dto.JobCode,
                Description = dto.Description,
                ClientName = dto.ClientName,
                DeparturePort = dto.DeparturePort,
                ArrivalPort = dto.ArrivalPort,
                EditBy = dto.EditBy,
                PlannerEventTypeId = dto.PlannerEventType,
                TravelDays = dto.TravelDays,
                IsCTS = dto.IsCTS
            };

            _context.PlannerEvents.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<PlannerEventDTO> UpdateEventAsync(int id, PlannerEventDTO dto)
        {
            var entity = await _context.PlannerEvents.FindAsync(id);
            if (entity == null) return null;

            entity.Name = dto.Name;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.ResourceId = dto.Resource;
            entity.Color = dto.Color;
            entity.JobID = dto.JobID;
            entity.ShipName = dto.ShipName;
            entity.JobCode = dto.JobCode;
            entity.Description = dto.Description;
            entity.ClientName = dto.ClientName;
            entity.DeparturePort = dto.DeparturePort;
            entity.ArrivalPort = dto.ArrivalPort;
            entity.EditBy = dto.EditBy;
            entity.PlannerEventTypeId = dto.PlannerEventType;
            entity.TravelDays = dto.TravelDays;
            entity.IsCTS = dto.IsCTS;

            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var entity = await _context.PlannerEvents.FindAsync(id);
            if (entity == null) return false;

            _context.PlannerEvents.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
