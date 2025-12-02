using EventAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly IEventCategoryServices _eventCategoryServices;

        public EventCategoryController(IEventCategoryServices eventCategoryServices)
        {
            _eventCategoryServices = eventCategoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _eventCategoryServices.GetCategoriesAsync();

            if(categories == null)
                return NotFound();

            return Ok(categories);
        }
    }
}
