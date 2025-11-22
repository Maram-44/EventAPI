using EventAPI.Models;
using EventAPI.Repositories.IRepositories;
using EventAPI.Services.IServices;

namespace EventAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMainRepo<Reservation> _repo;

        public ReservationService(IMainRepo<Reservation> repo)
        {
            _repo = repo;
        }

        //public async Task AddReservationAsync(Reservation reservation)
        //{
        //    await _repo.AddOneAsync(reservation);
        //}

        //my event

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _repo.FindAllAsync("Event", "User");
        }

        //public async Task<Reservation?> GetByIdAsync(int id)
        //{
        //    return await _repo.GetFirstOrDefaultAsync(r => r.IdNumber == id);
        //}

        public async Task<Reservation> CreateAsync(Reservation model)
        {
            model.BookingDate = DateTime.Now;

            await _repo.AddOneAsync(model);
            return model;
        }
    }
}
