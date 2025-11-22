using EventAPI.Models;
using EventAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("add-comment")]
        public async Task<IActionResult> AddComment([FromBody] Comment model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var saved = await _commentService.AddCommentAsync(model);
            return Ok(saved);
        }


    }
}
