using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePlannerAPI.Data;
using ThePlannerAPI.Models;

namespace ThePlannerAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly PlannerDbContext _context;

        public ResourcesController(PlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourcesController>>> GetResources()
        {
            var resources = await _context.Resources
                .Select(r => new
                {
                    key = r.Id,
                    label = r.namespace
                })
                .ToListAsync();

            return Ok(resources);
        }

    }
}