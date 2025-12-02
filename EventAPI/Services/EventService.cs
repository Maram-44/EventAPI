using EventAPI.Models;
using EventAPI.Repositories.IRepositories;
using EventAPI.Services.IServices;

namespace EventAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IMainRepo<Event> _eventRepo;

        public EventService(
            IMainRepo<Event> eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public async Task<IEnumerable<Event>> GetEventsByCategoryId(int CategoryId)
        {
            var all = await _eventRepo.FindAllAsync();
            return all.Where(e => e.Category == CategoryId);
        }

        public async Task<Event?> GetEventWithCommentsAsync(int id)
        {
            return await _eventRepo
                .FindAllAsync("Comments", "Comments.User")
                .ContinueWith(t => t.Result.FirstOrDefault(e => e.Id == id));
        }

        //my event

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _eventRepo.FindAllAsync("CategoryNavigation");
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _eventRepo.GetFirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event> CreateAsync(Event model)
        {
            await _eventRepo.AddOneAsync(model);
            return model;
        }

        public async Task<Event?> UpdateAsync(int id, Event model)
        {
            var old = await _eventRepo.FindByIdAsync(id);
            if (old == null)
                return null;

            // اي تحديثات إضافية حسب حقل معين
            old.Name = model.Name;
            old.PlaceName = model.PlaceName;
            old.City = model.City;
            old.Category = model.Category;
            old.Discription = model.Discription;
            old.Price = model.Price;
            old.StartDate = model.StartDate;
            old.FinishDate = model.FinishDate;
            old.StartTime = model.StartTime;
            old.FineshTime = model.FineshTime;
            old.ConstraintAge = model.ConstraintAge;
            old.Image = model.Image;

            await _eventRepo.UpdateOneAsync(old);
            return old;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _eventRepo.FindByIdAsync(id);
            if (obj == null)
                return false;

            await _eventRepo.DeleteOneAsync(obj);
            return true;
        }

        public async Task<IEnumerable<object>> GetCalendarAsync()
        {
            var events = await _eventRepo.FindAllAsync();

            var result = events.Select(e => new
            {
                e.Id,
                e.Name,
                e.PlaceName,
                e.Discription,
                e.StartDate,
                e.StartTime
            });

            return result;
        }
    }
}
