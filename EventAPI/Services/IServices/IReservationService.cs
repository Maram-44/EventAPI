using EventAPI.Models;

namespace EventAPI.Services.IServices
{
    public interface IReservationService
    {
        Task AddReservationAsync(Reservation reservation);
    }
}
