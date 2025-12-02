using EventAPI.Models;

namespace EventAPI.Services.IServices
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsByCategoryId(int CategoryId);
        Task<Event?> GetEventWithCommentsAsync(int id);

        //myEvents

        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
        Task<Event> CreateAsync(Event model);
        Task<Event?> UpdateAsync(int id, Event model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<object>> GetCalendarAsync();
    }
}
