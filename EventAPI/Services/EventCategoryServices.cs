using EventAPI.Models;
using EventAPI.Repositories.IRepositories;
using EventAPI.Services.IServices;

namespace EventAPI.Services
{
    public class EventCategoryServices : IEventCategoryServices
    {
        private readonly IMainRepo<EventCategory> _repo;

        public EventCategoryServices(IMainRepo<EventCategory> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<EventCategory>> GetCategoriesAsync()
        {
            return await _repo.FindAllAsync();
        }
    }
}
