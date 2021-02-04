using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Enum;
using CR.RoomBooking.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CR.RoomBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        //// GET: api/<RoomController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<RoomController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<RoomController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<RoomController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RoomController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        private IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> GetAllAsync([FromQuery(Name = "start_date")] string startDate = "", [FromQuery(Name = "end_date")] string endDate = "", [FromQuery(Name = "party_size")] int partySize = 0)
        {
            var rooms = await roomService.ListAsync(startDate, endDate, partySize);
            return rooms;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await roomService.SaveAsync(room);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            Result result = await roomService.DeleteAsync(id);

            if (result == Result.Failure)
            {
                return BadRequest("Post Error");
            }

            return Ok();

        }
        [HttpGet("{id:int}")]
        public async Task<Room> GetByIdAsync(int id)
        {
            var room = await roomService.FindIdAsync(id);
            return room;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await roomService.UpdateAsync(room);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }
    }
}
