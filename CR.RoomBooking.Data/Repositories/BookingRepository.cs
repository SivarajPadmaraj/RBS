using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Data.Repositories
{
   public class BookingRepository : IBookingRepository
    {

        private RoomBookingsContext _Context;

        public BookingRepository(RoomBookingsContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await _Context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetFromIDAsync(int id)
        {
            return await _Context.Bookings.FindAsync(id);
        }

        public async Task AddAsync(Booking booking)
        {
            await _Context.Bookings.AddAsync(booking);
            await _Context.SaveChangesAsync();
        }

        public async Task<bool> CheckClashAsync(Booking booking)
        {
            // Get bookings for the same room and then compare with new booking to see if there are any clashes
            return !await _Context.Bookings
                .Where(b => b.RoomId == booking.RoomId)
                .Where(b => b.StartDate < booking.EndDate && booking.StartDate < b.EndDate)
                .AnyAsync();
        }

        public async Task<bool> CheckCapacityAsync(Booking booking)
        {
            Room room = await _Context.Rooms.FindAsync(booking.RoomId);
            return booking.PartySize <= 3;
        }

        public async Task DeleteAsync(int id)
        {

            Booking booking =await _Context.Bookings.FirstOrDefaultAsync(s => s.BookingId == id);
            if (booking.BookingId == id)
            {
                _Context.Bookings.Remove(booking);
                _Context.SaveChanges();
            }

        }
    }
}
