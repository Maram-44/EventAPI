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
        private readonly IReservationService _reservationService;
        private readonly ICommentService _commentService;

        public EventController(
            IEventService eventService,
            IReservationService reservationService,
            ICommentService commentService)
        {
            _eventService = eventService;
            _reservationService = reservationService;
            _commentService = commentService;
        }

        // GET: api/event?category=Sports
        [HttpGet]
        public async Task<IActionResult> GetByCategory(string? name)
        {
            var events = await _eventService.GetEventsByCategoryNameAsync(name);
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

        // POST: api/event/book
        [HttpPost("book")]
        public async Task<IActionResult> BookEvent(Reservation reservation)
        {
            if (reservation == null)
                return BadRequest();

            await _reservationService.AddReservationAsync(reservation);

            return Ok(new { message = "Reservation saved successfully" });
        }

        // GET: api/event/search?searchTerm=x&category=Sports
        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchTerm, string category)
        {
            var result = await _eventService.SearchEventsAsync(searchTerm, category);
            return Ok(result);
        }

        // POST: api/event/add-comment
        [HttpPost("add-comment")]
        public async Task<IActionResult> AddComment(int eventId, string commentText)
        {
            if (string.IsNullOrWhiteSpace(commentText))
                return BadRequest("Empty comment");

            await _commentService.AddCommentAsync(eventId, commentText);

            return Ok(new { message = "Comment added" });
        }
    }
}
