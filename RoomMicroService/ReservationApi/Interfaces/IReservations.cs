using ReservationApi.Models;

namespace ReservationApi.Interfaces
{
    public interface IReservations
    {
        Task<List<Reservation>> GetAllReservations();
    }
}
