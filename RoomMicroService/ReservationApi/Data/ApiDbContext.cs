using Microsoft.EntityFrameworkCore;
using ReservationApi.Models;

namespace ReservationApi.Data
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=BookingApiDb");
        }
    }
}
