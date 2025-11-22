using EventAPI.Models;
using EventAPI.Repositories.IRepositories;
using EventAPI.Services.IServices;

namespace EventAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IMainRepo<Event> _eventRepo;
        private readonly IMainRepo<EventCategory> _categoryRepo;

        public EventService(
            IMainRepo<Event> eventRepo,
            IMainRepo<EventCategory> categoryRepo)
        {
            _eventRepo = eventRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<Event>> GetEventsByCategoryNameAsync(string? name)
        {
            if (string.IsNullOrEmpty(name))
                return await _eventRepo.FindAllAsync();

            var category = await _categoryRepo
                .GetFirstOrDefaultAsync(c => c.CategoryName == name);

            if (category == null)
                return Enumerable.Empty<Event>();

            return await _eventRepo.FindAllAsync();
        }

        public async Task<Event?> GetEventWithCommentsAsync(int id)
        {
            return await _eventRepo
                .FindAllAsync("Comments", "Comments.User")
                .ContinueWith(t => t.Result.FirstOrDefault(e => e.Id == id));
        }

        public async Task<IEnumerable<object>> SearchEventsAsync(string searchTerm, string category)
        {
            var categoryEntity = await _categoryRepo
                .GetFirstOrDefaultAsync(c => c.CategoryName == category);

            int categoryId = categoryEntity?.Id ?? 0;

            var events = await _eventRepo.FindAllAsync();

            var filtered = events
                .Where(e =>
                    (string.IsNullOrEmpty(searchTerm) || e.Name.Contains(searchTerm)) &&
                    (string.IsNullOrEmpty(category) || e.Category == categoryId))
                .Select(e => new
                {
                    id = e.Id,
                    name = e.Name,
                    discription = e.Discription,
                    image = e.Image
                });

            return filtered;
        }
    }
}
