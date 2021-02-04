using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Enum;
using CR.RoomBooking.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CR.RoomBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {

        private IBookingService bookingService;

        public RoomBookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IEnumerable<Booking>> GetAllAsync([FromQuery]int id = -1)
        {
            var bookings = await bookingService.ListAsync(id);
            return bookings;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await bookingService.SaveAsync(booking);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            Result result = await bookingService.DeleteAsync(id);

            if (result == Result.Failure)
            {
                return BadRequest("Post Error");
            }

            return Ok();

        }
    }
}
