using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Enum;
using CR.RoomBooking.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Test
{
   public class BookingServiceFake : IBookingService
    {

        private readonly List<Booking> bookings;

        public BookingServiceFake()
        {
            bookings = new List<Booking>()
            {
                new Booking() { BookingId = 1, RoomId = 1, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 0 },
                new Booking() { BookingId = 2, RoomId = 4, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 0 },
                new Booking() { BookingId = 5, RoomId = 8, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 0},
            };
        }

        public async Task<Result> DeleteAsync(int id)
        {
            Booking booking = bookings.Where(a => a.BookingId == id).FirstOrDefault();
            if (booking.BookingId == id)
            {
                bookings.Remove(booking);
                return Result.Success;
            }

            return Result.Failure;
        }

        public async Task<IEnumerable<Booking>> ListAsync(int id)
        {
            if (id > -1)
            {
                return bookings.Where(b => b.BookingId == id);
            }
            return bookings;
        }

        public async Task<Result> SaveAsync(Booking booking)
        {
            bookings.Add(booking);
            return Result.Success;
        }


    }
}
