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

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _repo.AddOneAsync(reservation);
        }
    }
}
