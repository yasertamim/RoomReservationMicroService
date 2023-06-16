using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservationApi.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Tlf { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
