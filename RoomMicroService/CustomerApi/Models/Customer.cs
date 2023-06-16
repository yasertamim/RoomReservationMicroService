﻿namespace CustomerApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Tlf { get; set; }
        public int RommId { get; set; }
        public Room Room { get; set; }
    }
}
