namespace RoomApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public double Area { get; set; }

        public int Beds { get; set; }
        public double Price { get; set; }
        public bool Wifi { get; set; }

        public bool Meals { get; set; }
    }
}
