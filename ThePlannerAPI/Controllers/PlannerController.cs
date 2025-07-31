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
                id = e.id,
                start_date = e.start_date.ToString("s"), // ISO 8601
                end_date = e.end_date.ToString("s"),
                text = e.Name,
                section_id = e.Resource,

                // All other DTO properties
                name = e.Name,
                details = e.text,
                color = e.Color,
                jobID = e.JobID,
                shipName = e.ShipName,
                jobCode = e.JobCode,
                clientName = e.ClientName,
                departurePort = e.DeparturePort,
                arrivalPort = e.ArrivalPort,
                editBy = e.EditBy,
                plannerEventType = e.PlannerEventType,
                travelDays = e.TravelDays
            });

            return Ok(dhtmlxFormatted);
        }
    }
}
