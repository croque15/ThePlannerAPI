using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePlannerAPI.Models;
using ThePlannerAPI.Services;

namespace ThePlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlannerController : ControllerBase
    {
        private readonly IPlannerService _plannerEventService;

        public PlannerController(IPlannerService plannerEventService)
        {
            _plannerEventService = plannerEventService;
        }

        
        [HttpGet("dhtmlx")]
        public async Task<IActionResult> GetEventsForDhtmlx()
        {
            var allEvents = await _plannerEventService.GetAllEventsAsync();

            var dhtmlxFormatted = allEvents.Select(e => new
            {
                id = e.Id,
                start_date = e.StartDate.ToString("s"), // ISO 8601
                end_date = e.EndDate.ToString("s"),
                text = e.Description
            });

            return Ok(dhtmlxFormatted);
        }
    }
}
