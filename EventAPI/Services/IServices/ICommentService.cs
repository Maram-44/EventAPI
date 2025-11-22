namespace EventAPI.Services.IServices
{
    public interface ICommentService
    {
        Task AddCommentAsync(int eventId, string commentText);
    }
}
