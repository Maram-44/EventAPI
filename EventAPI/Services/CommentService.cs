using EventAPI.Models;
using EventAPI.Repositories.IRepositories;
using EventAPI.Services.IServices;

namespace EventAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMainRepo<Comment> _repo;

        public CommentService(IMainRepo<Comment> repo)
        {
            _repo = repo;
        }

        public async Task AddCommentAsync(int eventId, string commentText)
        {
            Comment newComment = new Comment
            {
                EventId = eventId,
                UserId = 1,
                Comment1 = commentText
            };

            await _repo.AddOneAsync(newComment);
        }
    }
}
