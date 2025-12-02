using EventAPI.Models;
using EventAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(
            IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var events = await  _eventService.GetEventsByCategoryId(categoryId);

            if(events == null)
                return NotFound();

            return Ok(events);
            
        }

        // GET: api/event/details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var ev = await _eventService.GetEventWithCommentsAsync(id);
            if (ev == null)
                return NotFound();

            return Ok(ev);
        }



        //

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var data = await _eventService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var ev = await _eventService.GetByIdAsync(id);
            if (ev == null) return NotFound();

            return Ok(ev);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] Event model)
        {
            var created = await _eventService.CreateAsync(model);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event model)
        {
            var updated = await _eventService.UpdateAsync(id, model);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            bool deleted = await _eventService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return Ok(new { message = "Deleted successfully" });
        }

    }
}
