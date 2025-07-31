using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePlannerAPI.Data;
using ThePlannerAPI.Models;
using ThePlannerAPI.DTOs;

namespace ThePlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly PlannerDbContext _context;

        public ResourcesController(PlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetResources()
        {
            var resources = await _context.Resources
                .Select(r => new
                {
                    Key = r.Id,
                    Label = $"{r.FirstName} {r.LastName}",
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    Sector = r.Sector,
                    MedCert = r.MedCert,
                    Days = r.Hours,
                    ResourceType = r.ResourceType
                })

                .ToListAsync();

            return Ok(resources);
        }

    }
}