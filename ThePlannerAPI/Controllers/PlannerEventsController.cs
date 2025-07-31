using Microsoft.AspNetCore.Mvc;
using ThePlannerAPI.Services;
using ThePlannerAPI.DTOs;
using Microsoft.AspNetCore.SignalR;
using ThePlannerAPI.Hubs;

namespace ThePlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlannerEventsController : ControllerBase
    {
        private readonly IPlannerService _service;
        private readonly IHubContext<EventHub> _hubContext;

        public PlannerEventsController(IPlannerService service, IHubContext<EventHub> hubContext)
        {
            _service = service;
            _hubContext = hubContext;
        }

        private string GetConnectionId() =>
            Request.Headers.TryGetValue("X-Connection-Id", out var id) ? id.ToString() : null;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlannerEventDTO>>> GetEvents()
        {
            return Ok(await _service.GetAllEventsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlannerEventDTO>> GetEvent(int id)
        {
            var result = await _service.GetEventByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PlannerEventDTO>> CreateEvent(PlannerEventDTO dto)
        {
            var created = await _service.CreateEventAsync(dto);
            await _hubContext.Clients.AllExcept(GetConnectionId()).SendAsync("NewEventCreated", created);
            return CreatedAtAction(nameof(GetEvent), new { id = created.id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlannerEventDTO>> UpdateEvent(int id, PlannerEventDTO dto)
        {
            var updated = await _service.UpdateEventAsync(id, dto);
            if (updated == null) return NotFound();
            await _hubContext.Clients.AllExcept(GetConnectionId()).SendAsync("EventUpdated", updated);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deleted = await _service.DeleteEventAsync(id);
            if (!deleted) return NotFound();
            await _hubContext.Clients.AllExcept(GetConnectionId()).SendAsync("EventDeleted", id);
            return NoContent();
        }

        // DHTMLX-compatible GET
        [HttpGet("dhtmlx")]
        public async Task<IActionResult> GetForDhtmlx()
        {
            var events = await _service.GetAllEventsAsync();
            var formatted = events.Select(e => new
            {
                id = e.id,
                start_date = e.start_date.ToString("s"),
                end_date = e.end_date.ToString("s"),
                text = e.Name,
                section_id = e.Resource,

                // All other requested by Vlad
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

            return Ok(formatted);
        }

        [HttpPost("dhtmlx")]
        public async Task<IActionResult> CreateForDhtmlx([FromForm] PlannerEventDTO dto)
        {
            var created = await _service.CreateEventAsync(dto);
            await _hubContext.Clients.AllExcept(GetConnectionId()).SendAsync("NewEventCreated", created);
            return Ok(new { action = "inserted", tid = created.id });
        }

        [HttpPut("dhtmlx/{id}")]
        public async Task<IActionResult> UpdateForDhtmlx(int id, [FromForm] PlannerEventDTO dto)
        {
            var updated = await _service.UpdateEventAsync(id, dto);
            if (updated == null) return NotFound();
            await _hubContext.Clients.AllExcept(GetConnectionId()).SendAsync("EventUpdated", updated);
            return Ok(new { action = "updated" });
        }

        [HttpDelete("dhtmlx/{id}")]
        public async Task<IActionResult> DeleteForDhtmlx(int id)
        {
            var deleted = await _service.DeleteEventAsync(id);
            if (!deleted) return NotFound();
            await _hubContext.Clients.AllExcept(GetConnectionId()).SendAsync("EventDeleted", id);
            return Ok(new { action = "deleted" });
        }
    }
}
