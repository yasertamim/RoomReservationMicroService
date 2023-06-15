using RoomApi.Models;

namespace RoomApi.Interfaces
{
    public interface IRooms
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task AddRoom(Room room);
        Task UpdateRoom(int id,Room room);
        Task DeleteRoom(int id);
    }
}
