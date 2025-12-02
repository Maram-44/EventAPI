using EventAPI.Models;

namespace EventAPI.Services.IServices
{
    public interface IEventCategoryServices
    {
        Task<IEnumerable<EventCategory>> GetCategoriesAsync();
    }
}
