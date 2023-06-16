using Microsoft.AspNetCore.Mvc;
using ReservationApi.Interfaces;
using ReservationApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservations reservationService;

        public ReservationsController(IReservations reservationService)
        {
            this.reservationService = reservationService;
        }



        // GET: api/<ReservationsController>
        [HttpGet]
        public async  Task<IEnumerable<Reservation>> Get()
        {
            return await reservationService.GetAllReservations();
        }

    }
}
