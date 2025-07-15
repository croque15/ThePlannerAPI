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

            // Notifys the frontend through SignalR
            await _hubContext.Clients.All.SendAsync("NewEventCreated", created);

            return CreatedAtAction(nameof(GetEvent), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlannerEventDTO>> UpdateEvent(int id, PlannerEventDTO dto)
        {
            var updated = await _service.UpdateEventAsync(id, dto);
            if (updated == null) return NotFound();
            await _hubContext.Clients.All.SendAsync("EventUpdated", updated);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deleted = await _service.DeleteEventAsync(id);
            if (!deleted) return NotFound();
            await _hubContext.Clients.All.SendAsync("EventDeleted", id);
            return NoContent();
        }


    }
}
