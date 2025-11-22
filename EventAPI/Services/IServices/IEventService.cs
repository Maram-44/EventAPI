using EventAPI.Models;

namespace EventAPI.Services.IServices
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsByCategoryNameAsync(string? name);
        Task<Event?> GetEventWithCommentsAsync(int id);
        Task<IEnumerable<object>> SearchEventsAsync(string searchTerm, string category);
    }
}
