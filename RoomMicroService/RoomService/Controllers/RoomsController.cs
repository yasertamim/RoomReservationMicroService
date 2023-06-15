using Microsoft.AspNetCore.Mvc;
using RoomApi.Interfaces;
using RoomApi.Models;
using RoomApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRooms roomService;

        public RoomsController(IRooms roomService)
        {
            this.roomService = roomService;
        }



        // GET: api/<RoomsController>
        [HttpGet]
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await roomService.GetAllRooms();
            return rooms;
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public async Task<Room> GetRoomById(int id)
        {
            var room = await roomService.GetRoomById(id);
            return room;
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task Post([FromBody] Room room)
        {
           await roomService.AddRoom(room);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Room room)
        {
            await roomService.UpdateRoom(id, room);
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await roomService.DeleteRoom(id);
        }
    }
}
