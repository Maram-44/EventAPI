using EventAPI.Models;
using EventAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveEvent([FromBody] Reservation model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var saved = await _reservationService.CreateAsync(model);
            return Ok(saved);
        }

        [HttpGet("reservations")]
        public async Task<IActionResult> GetAllReservations()
        {
            var result = await _reservationService.GetAllAsync();
            return Ok(result);
        }
    }
}
