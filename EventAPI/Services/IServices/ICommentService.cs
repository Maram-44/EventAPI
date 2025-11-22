using EventAPI.Models;

namespace EventAPI.Services.IServices
{
    public interface ICommentService
    {
        //Task AddCommentAsync(int eventId, string commentText);

        //my event
        Task<Comment> AddCommentAsync(Comment model);
        //Task<IEnumerable<Comment>> GetCommentsByEventIdAsync(int eventId);
    }
}
