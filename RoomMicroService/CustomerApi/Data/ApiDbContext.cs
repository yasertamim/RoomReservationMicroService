using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=CustomerApiDb");
        }
    }
}
