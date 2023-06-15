using Microsoft.EntityFrameworkCore;
using RoomApi.Models;

namespace RoomApi.Data
{
    public class ApiDbContext :DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RoomsApiDb;");
        }

    }
}
