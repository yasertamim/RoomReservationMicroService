using System.ComponentModel.DataAnnotations;

namespace ReservationApi.Models
{
    public class Room
    {
        [Key]
        public int Rid { get; set; }
        public int Id { get; set; }
        public double  Price { get; set; }
    }
}
