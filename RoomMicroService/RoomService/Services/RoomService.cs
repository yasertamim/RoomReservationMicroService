using Microsoft.EntityFrameworkCore;
using RoomApi.Data;
using RoomApi.Interfaces;
using RoomApi.Models;

namespace RoomApi.Services
{
    public class RoomService : IRooms
    {
        private ApiDbContext _context; 
        public RoomService()
        {
            _context = new ApiDbContext();
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            if (rooms == null)
            {
                return null;
            }
            return rooms;
        }
        public async Task AddRoom(Room room)
        {
           await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if(room != null)
            {
                 _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();

            }
            
        }

   

        public async Task<Room> GetRoomById(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                return room;
            }
            return null;
        }

        public async Task UpdateRoom(int id, Room room)
        {
            var roomById = await _context.Rooms.FindAsync(id);
            if (roomById != null)
            {
                roomById.Area = room.Area;
                roomById.Beds = room.Beds;
                roomById.Price = room.Price;
                roomById.Wifi = room.Wifi;
                roomById.Meals = room.Meals;

                await _context.SaveChangesAsync();
            }
        }
    }
}
