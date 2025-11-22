using EventAPI.Models;

namespace EventAPI.Services.IServices
{
    public interface IReservationService
    {
        //Task AddReservationAsync(Reservation reservation);

        //my events
        Task<IEnumerable<Reservation>> GetAllAsync();
        //Task<Reservation?> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(Reservation model);
    }
}
